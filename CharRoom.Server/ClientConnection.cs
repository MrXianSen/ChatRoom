using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace ChatRoom.Server
{
    public class ClientConnection
    {
        Thread threadClient = null;
        Socket socket = null;
        ServerForm serverForm = null;
        //在线用户的用户名集合和Socket集合
        public static List<string> onlineUserName = new List<string>();
        public static List<Socket> onlineSocket = new List<Socket>();
        public ClientConnection(ServerForm serverForm, Socket socket)
        {
            this.serverForm = serverForm;
            this.socket = socket;
            threadClient = new Thread(watchMsg);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        #region -------------------------------------1. 实现服务器与客户端的通信
        private void watchMsg()
        {
            try
            {
                while (true)
                {
                    if (socket == null) break;
                    byte[] byteMsgRec = new byte[1024 * 1024 * 4];
                    int length = socket.Receive(byteMsgRec, byteMsgRec.Length, SocketFlags.None);
                    if (length > 0)
                    {
                        string strMsgRec = Encoding.UTF8.GetString(byteMsgRec, 0, length);
                        handleMsg(strMsgRec);
                    }
                }
            }
            catch (Exception e)
            {
                ShowMsg("出现异常：" + e.Message + "\n");
                return;
            }
        }
        //服务器端向客户端发送消息
        public void SendMsg(string msg)
        {
            try
            {
                byte[] msgSendByte = Encoding.UTF8.GetBytes(msg);
                socket.Send(msgSendByte);
            }
            catch (Exception ex)
            {
                ShowMsg("发送消息错误：" + ex.Message + "\n");
                return;
            }
        }
        #endregion
        #region ----------------------------------------2. 处理转发用户消息
        //处理收到的请求，进行转发
        private void handleMsg(string msg)
        {
            string[] strArray = msg.Split('|');
            switch (strArray[0])
            {
                case "Login":
                    login(msg);
                    break;
                case "Init":
                    notifyAll();
                    break;
                case "Reg":
                    register(msg);
                    break;
                case "Talk":
                    talk(msg);
                    break;
                case "Close":
                    close(msg);
                    break;
                default:

                    break;
            }
        }
        //登录
        private void login(string msg)
        {
            string[] strArray = msg.Split('|');
            string userInfo = "";
            for (int i = 1; i < strArray.Length; i++)
            {
                userInfo += strArray[i] + "|";
            }
            userInfo = userInfo.Remove(userInfo.LastIndexOf('|'), 1);
            if (isLoginSucceed(userInfo))
            {
                string username = userInfo.Split('|')[0];
                onlineUserName.Add(username);
                onlineSocket.Add(this.socket);
                ShowMsg(username + ":加入房间" + "\n");
                string feedBack = "login|succeed";
                SendMsg(feedBack);
            }
            else
            {
                string errorMsg = "warning|登录失败";
                SendMsg(errorMsg);
                this.closeSocket();
            }
        }
        //注册
        private void register(string msg)
        {
            string[] strArray = msg.Split('|');
            string userInfo = "";
            for (int i = 1; i < strArray.Length; i++)
            {
                userInfo += strArray[i] + "|";
            }
            userInfo = userInfo.Remove(userInfo.LastIndexOf('|'), 1);
            if (isRegisterSucceed(userInfo))
            {
                string username = userInfo.Split('|')[0];
                onlineUserName.Add(username);
                onlineSocket.Add(this.socket);
                ShowMsg(username + ":加入房间" + "\n");
                string feedBack = "login|succeed";
                SendMsg(feedBack);
            }
            else
            {
                string feedBack = string.Format(@"warning|登录失败！");
                SendMsg(feedBack);
                this.closeSocket();
            }
        }
        //请求在线用户
        private void notifyAll()
        {
            string feedBack = "online";
            if (onlineUserName.Count > 0)
            {
                for (int i = 0; i < onlineUserName.Count; i++)
                {
                    feedBack += "|" + onlineUserName[i];
                }
            }
            else
            {
                feedBack += "|0";
            }

            if (onlineSocket.Count > 0 && onlineUserName.Count > 0)
            {
                for (int i = 0; i < onlineSocket.Count; i++)
                {
                    onlineSocket[i].Send(Encoding.UTF8.GetBytes(feedBack));
                }
            }
        }
        //聊天
        private void talk(string msg)
        {
            string[] strArray = msg.Split('|');
            //消息来自
            string fromUser = strArray[1];
            //消息发送给
            string toUser = strArray[2];
            string msgInfo = strArray[3];
            if (toUser.Equals("All"))
                sendToAll(fromUser, msgInfo);
            else
                sendToUserByName(fromUser, toUser, msgInfo);
        }
        //关闭
        private void close(string msg)
        {
            int length = onlineSocket.Count;
            string[] strArray = msg.Split('|');
            //消息来自
            string fromUser = strArray[1];
            for (int i = 0; i < length; i++)
            {
                if (fromUser.Equals(onlineUserName[i]))
                {
                    onlineUserName.Remove(fromUser);
                    Socket scoket = onlineSocket[i];
                    onlineSocket.Remove(scoket);
                    break;
                }
            }
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
            ShowMsg("提示："+fromUser+"离开聊天室");
            length = onlineSocket.Count;
            if (onlineSocket.Count > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string sendMsg = string.Format(@"Close|{0}", fromUser);
                    onlineSocket[i].Send(Encoding.UTF8.GetBytes(sendMsg));
                }
            }
        }

        private void sendToAll(string fromUser, string msg)
        {
            if (onlineUserName.Count > 0 && onlineSocket.Count > 0)
            {
                for (int i = 0; i < onlineSocket.Count; i++)
                {
                    string sendMsg = string.Format("talk|{0}：{1}", fromUser, msg);
                    onlineSocket[i].Send(Encoding.UTF8.GetBytes(sendMsg));
                }
            }
        }
        private void sendToUserByName(string fromUser, string toUser, string msg)
        {
            string sendMsg = string.Format(@"talk|{0}：{1}", fromUser, msg);
            if (onlineSocket.Count > 0 && onlineUserName.Count > 0)
            {
                for (int i = 0; i < onlineUserName.Count; i++)
                {
                    if (toUser.Equals(onlineUserName[i]))
                    {
                        onlineSocket[i].Send(Encoding.UTF8.GetBytes(sendMsg));
                        return;
                    }
                }
            }
        }
        private bool isRegisterSucceed(string strInfo)
        {
            StreamReader streamReader = new StreamReader("User.txt");
            String line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Equals(strInfo)) return false;
            }
            streamReader.Close();
            FileStream fileStream = new FileStream("User.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(strInfo);
            writer.Close();
            fileStream.Close();
            return true;
        }
        private bool isLoginSucceed(string userInfo)
        {
            StreamReader streamReader = new StreamReader("User.txt");
            string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == userInfo && !onlineUserName.Contains(userInfo.Split('|')[0]))
                    return true;
            }
            streamReader.Close();
            return false;
        }
        private void closeSocket()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }
        #endregion
        #region --------------------------------------2. 显示异常信息
        private void ShowMsg(string msg)
        {
            this.serverForm.AppendMsg(msg);
        }
        #endregion
    }
}
