using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace ChatRoom.Server
{
    public partial class ServerForm : Form
    {
        //委托对象
        delegate void ShowMsg(string msg);

        #region --------------------------------1. 窗体操作
        public ServerForm()
        {
            //初始化委托
            showMsg = new ShowMsg(AppendMsgToPanel);
            InitializeComponent();
            textBox_SERVER_IP.Text = "127.0.0.1";
            try
            {
                address = IPAddress.Parse("127.0.0.1");
                endPoint = new IPEndPoint(address, 9000);
                //创建服务器端线程
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //将服务器套接字绑定在endPoint上面
                serverSocket.Bind(endPoint);
                //此时线程挂起等待客户端接入
                serverSocket.Listen(10);
                AppendMsgToPanel("服务器启动成功...");
                //新线程获取客户端
                Thread acceptClientThread = new Thread(acceptClient);
                acceptClientThread.IsBackground = true;
                acceptClientThread.Start();
            }
            catch (Exception e)
            {
                AppendMsgToPanel("服务器启动失败：" + e.Message + "\n");
            }
        }
        public void AppendMsgToPanel(string msg)
        {
            textBox_MSG.AppendText(msg + "\n");
        }
        #endregion

        #region --------------------------------2. 套接字操作
        Socket serverSocket = null;
        IPAddress address = null;
        IPEndPoint endPoint = null;
        private void acceptClient()
        {
            while (true)
            {
                try
                {
                    Socket socket = serverSocket.Accept();
                    ClientConnection conn = new ClientConnection(this, socket);
                }
                catch (Exception e)
                {
                    AppendMsg("客户端连入错误：" + e.Message + "\n");
                }
            }
        }
        #endregion 

        #region --------------------------------3. 委托
        ShowMsg showMsg;
        public void AppendMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(showMsg, msg);
            }
        }
        #endregion 
    }
}
