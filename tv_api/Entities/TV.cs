using System.Net.WebSockets;

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
