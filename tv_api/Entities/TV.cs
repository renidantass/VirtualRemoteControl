using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace tv_api.Entities
{
    abstract class TV
    {
        protected string Ip { get; set; }
        protected int Port { get; set; }

        public TV(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        public abstract ClientWebSocket GetConnection();
    }
}
