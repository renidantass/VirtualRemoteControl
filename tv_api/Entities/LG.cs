using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tv_api.Entities
{
    class LG : TV
    {
        private static ClientWebSocket _connection {get;set;}
        private string Filename { get; set; }
        private dynamic _handshake_msg { get; set; }

        public LG(string ip) : base(ip, 3000)
        {
            Filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "hello.json");
            ReadHandshake();
        }

        public override ClientWebSocket GetConnection()
        {
            return Connect().Result;
        }

        private async Task<ClientWebSocket> Connect()
        {
            byte[] buffer = new byte[1024];
            ClientWebSocket ws = null;

            try
            {
                ws = new ClientWebSocket();
                await ws.ConnectAsync(new Uri($"ws://{Ip}:{Port}"), CancellationToken.None);
                await MakeHandshake(ws);
                return ws;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task MakeHandshake(ClientWebSocket ws)
        {
            byte[] buffer = new byte[1024];
            try
            {
                await ws.SendAsync(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(_handshake_msg)), WebSocketMessageType.Text, true, CancellationToken.None);
                await ws.ReceiveAsync(buffer, CancellationToken.None);
                dynamic res = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer));

                if (res.type == "registered")
                {
                    SaveHandshake();
                    return;
                }

                await ws.ReceiveAsync(buffer, CancellationToken.None);
                res = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer));

                if (res.type == "registered")
                {
                    _handshake_msg.payload["client-key"] = res.payload["client-key"];
                    SaveHandshake();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReadHandshake()
        {
            _handshake_msg = JsonConvert.DeserializeObject(string.Concat(File.ReadAllLines(Filename)));
        }

        public void SaveHandshake()
        {
            File.WriteAllText(Filename, JsonConvert.SerializeObject(_handshake_msg));
        }
    }
}
