using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ChatRoom.Model
{
    public class Client
    {
        private string _Username;
        private Socket _ClientSocket;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        public Socket ClientSocket
        {
            get { return _ClientSocket; }
            set { _ClientSocket = value; }
        }
    }
}
