using System;
using System.Net.WebSockets;

namespace tv_api.Entities
{
    class Samsung : TV
    {
        public Samsung(string ip, int port) : base(ip, port)
        {
        }

        public override ClientWebSocket GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
