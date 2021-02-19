using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tv_api.Entities;

namespace tv_api.Services
{
    class RemoteControl<T> : IDisposable where T : TV
    {
        private static ClientWebSocket _connection { get; set; }
        public List<Command> Commands { get; set; }

        public RemoteControl(T api)
        {
            _connection = api.GetConnection();
        }

        public async Task<dynamic> SendCommand(Command command)
        {
            try
            {
                await _connection.SendAsync(command.Request, WebSocketMessageType.Text, true, CancellationToken.None);
                await _connection.ReceiveAsync(command.Response, CancellationToken.None);
            } catch (WebSocketException)
            {
                throw;
            }
            return JsonConvert.DeserializeObject(Encoding.ASCII.GetString(command.Response));
        }

        public void Dispose()
        {
            _connection.CloseAsync(WebSocketCloseStatus.NormalClosure, "WebSocket encerrado", CancellationToken.None);
        }
    }
}
