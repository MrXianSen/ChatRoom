using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

namespace ChatRoom.Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            showMsg = new ShowMsg(appendMsg);
            addItem = new AddItem(addItemToComboBox);
            deleteItem = new DeleteItem(deleteItemFromComboBox);
            InitializeComponent();
        }

        #region -----------------------1. Socket处理
        IPAddress address = null;
        Socket clientSocket = null;
        IPEndPoint endPoint = null;
        private void connecToServer()
        {
            try
            {
                //创建客户端套接字
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                address = IPAddress.Parse("127.0.0.1");
                endPoint = new IPEndPoint(address, 9000);
                //连接服务器
                clientSocket.Connect(endPoint);
            }
            catch (Exception e)
            {
                string errStr = string.Format("系统提示：出现了错误！\r\n错误信息：{0}\r\n", e.Message);
                textBox_CLIENT_MSG.AppendText(errStr);
                return;
            }
        }
        /// <summary>
        /// 获取服务器发送过来的数据
        /// </summary>
        private string recvMsg()
        {
            try
            {
                byte[] receveMsg = new byte[1024 * 1024 * 2];
                int length = clientSocket.Receive(receveMsg);
                return Encoding.UTF8.GetString(receveMsg, 0, length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// 描述：发送数据到服务器进行处理
        /// </summary>
        /// <param name="msg"></param>
        private void sendMsg(string msg)
        {
            try
            {
                clientSocket.Send(Encoding.UTF8.GetBytes(msg));
            }
            catch (Exception ex)
            {
                showDialog("Error:"+ex.Message);
            }
        }
        #endregion 

        #region -----------------------2. 发送消息
        /// --------------------------------------------
        /// <summary>
        /// 描述：发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// --------------------------------------------
        private void button_SEND_Click(object sender, EventArgs e)
        {
            try
            {
                //连接服务器成功发送消息
                string msg = textBox_CLIENT_SEND_MSG.Text.ToString();
                string logininUser = textBox_hide.Text;
                if (string.IsNullOrEmpty(logininUser))
                {
                    showDialog("您还没登录");
                    return;
                }
                if (string.IsNullOrEmpty(msg))
                {
                    showDialog("发送内容不能为空");
                    return;
                }
                string toUser = comboBox_USER_LIST.Text.ToString();
                if (string.IsNullOrEmpty(toUser))
                {
                    showDialog("请选择发送对象！");
                    return;
                }
                string sendStrMsg = "Talk|" + textBox_hide.Text.ToString() + "|" + toUser + "|" + msg;
                sendMsg(sendStrMsg);
                textBox_CLIENT_SEND_MSG.Text = "";
                textBox_CLIENT_MSG.AppendText("你对" + toUser + "说:" + msg + "\n");
            }
            catch (Exception ex)
            {
                //出现异常，如：没有连接到服务器
                string errorMsg = string.Format(@"发送失败：{0}", ex.Message);
                textBox_CLIENT_MSG.AppendText(errorMsg + "\r\n");
            }
        }
        #endregion

        #region -----------------------3. 登录
        /// --------------------------------------------
        /// <summary>
        /// 描述：登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// --------------------------------------------
        private void button_Login_Click(object sender, EventArgs e)
        {

            string username = textBox_UserName.Text.ToString();
            string pwd = textBox_Pwd.Text.ToString();
            if (!checkInput(username, pwd)) return;
            connecToServer();
            string requestLoginMsg = string.Format(@"Login|{0}|{1}", username, pwd);
            try
            {
                sendMsg(requestLoginMsg);
                //初始化登录
                initLogin();
            }
            catch (Exception ex)
            {
                showDialog("登录失败");
                return;
            }
        }
        private void initLogin()
        {
            string strRecvMsg = recvMsg();
            string[] strArray = strRecvMsg.Split('|');
            switch (strArray[0])
            { 
                case "login":
                    if (strArray[1].Equals("succeed"))
                    {
                        string user = textBox_UserName.Text;
                        button_Login.Dispose();
                        button_Register.Dispose();
                        textBox_Pwd.Dispose();
                        textBox_UserName.Dispose();
                        label2.Dispose();
                        label3.Dispose();
                        label_hide.Show();
                        textBox_hide.Text = user;
                        textBox_hide.Show();
                        //启动客户端与服务器的连接服务
                        new ClientService(clientSocket, this);
                        string strSendMsg = "Init|online";
                        sendMsg(strSendMsg);
                    }
                    break;
                case "warning":
                    string warningMsg = this.recvMsg();
                    showDialog(warningMsg.Split('|')[1]);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    clientSocket = null;
                    break;
            }
        }
        #endregion

        #region -----------------------4. 注册
        /// --------------------------------------------
        /// <summary>
        /// 描述：注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// --------------------------------------------
        private void button_Register_Click(object sender, EventArgs e)
        {
            string username = textBox_UserName.Text.ToString();
            string pwd = textBox_Pwd.Text.ToString();
            if (!checkInput(username, pwd)) return;
            connecToServer();
            string requestRegMsg = string.Format(@"Reg|{0}|{1}", username, pwd);
            try
            {
                sendMsg(requestRegMsg);
                initLogin();
            }
            catch (Exception ex)
            {
                showDialog("注册失败");
                return;
            }
        }
        #endregion

        #region -----------------------5. 退出
        /// --------------------------------------------
        /// <summary>
        /// 描述：退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// --------------------------------------------
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            string msg = "Close|" + textBox_hide.Text;
            sendMsg(msg);
            Application.Exit();
        }
        #endregion

        public void addItemToComboBox(string str)
        {
            //首先移除所有的列表
            comboBox_USER_LIST.Items.Clear();
            comboBox_USER_LIST.Items.Add("All");
            string[] strArray = str.Split('|');
            for (int i = 1; i < strArray.Length; i++)
            {
                if (strArray[1].Equals("0")) return;
                comboBox_USER_LIST.Items.Add(strArray[i]);
            }
        }
        public void deleteItemFromComboBox(string who)
        {
            comboBox_USER_LIST.Items.Remove(who);
        }

        #region -----------------------6. 定义委托，子线程中能够像消息列表中添加信息
        delegate void ShowMsg(string msg);
        delegate void AddItem(string msg);
        delegate void DeleteItem(string who);
        ShowMsg showMsg;
        AddItem addItem;
        DeleteItem deleteItem;
        public void DisplayMsg(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(showMsg, msg);
                }
            }
            catch (Exception e) { }
        }
        public void addItemToList(string msg)
        {
            try
            {
                if(this.InvokeRequired)
                {
                    this.Invoke(addItem, msg);
                }
            }
            catch (Exception e)
            {}
        }
        public void removeFromToList(string who)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(deleteItem, who);
                }
            }
            catch (Exception e) { }
        }
        private void appendMsg(string msg)
        {
            textBox_CLIENT_MSG.AppendText(msg + "\n");
        }
        /// --------------------------------------------
        /// <summary>
        /// 描述：显示弹出框
        /// </summary>
        /// <param name="msg"></param>
        /// --------------------------------------------
        private void showDialog(string msg)
        {
            MessageBox.Show(msg);
        }
        #endregion

        #region -----------------------8. 工具方法
        private bool checkInput(string username, string pwd)
        {
            if (string.IsNullOrEmpty(username))
            {
                showDialog("用户名不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                showDialog("密码不能为空");
                return false;
            }
            return true;
        }
        #endregion
    }
}
