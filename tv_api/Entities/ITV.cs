using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace tv_api.Entities
{
    interface ITV
    {
        public ClientWebSocket GetConnection();
    }
}
