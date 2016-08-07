using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ChatRoom.Client
{
    public class ClientService
    {
        private Socket socket;
        private Thread talkThread;
        private ClientForm clientForm = null;
        public ClientService(Socket socket, ClientForm clientForm)
        {
            this.socket = socket;
            this.clientForm = clientForm;
            talkThread = new Thread(watchMsg);
            talkThread.IsBackground = true;
            talkThread.Start();
        }
        private void watchMsg()
        {
            try
            {
                while (true)
                {
                    byte[] recvMsgByte = new byte[1024 * 1024 * 2];
                    int length = socket.Receive(recvMsgByte);
                    if (length > 0)
                    {
                        string strRecvMsg = Encoding.UTF8.GetString(recvMsgByte, 0, length);
                        handleMsg(strRecvMsg);
                    }
                }
            }
            catch (Exception e)
            {
                appendMsg("错误：" + e.Message + "\n");
                return;
            }
        }
        private void handleMsg(string msg)
        {
            string recvMsgStr = msg.ToString();
            string[] recvArray = recvMsgStr.Split('|');
            switch (recvArray[0])
            {
                case "talk":
                    //发送给聊天
                    appendMsg(recvArray[1] + "\n");
                    break;
                case "online":
                    addToComboBox(recvMsgStr);
                    break;
                case "Close":
                    clientLeave(recvArray[1]);
                    break;
                case "warning":
                    appendMsg("错误提示：" + recvArray[1] + "\n");
                    break;
            }
        }
        private void clientLeave(string who)
        {
            this.clientForm.removeFromToList(who);
        }
        #region ----------------------------调用委托向界面中添加消息
        private void addToComboBox(string str)
        {
            this.clientForm.addItemToList(str);
        }
        private void appendMsg(string msg)
        {
            this.clientForm.DisplayMsg(msg);
        }
        #endregion
    }
}
