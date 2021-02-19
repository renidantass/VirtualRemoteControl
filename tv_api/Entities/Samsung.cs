using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

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
