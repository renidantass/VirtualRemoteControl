using Newtonsoft.Json;
using System;
using System.Text;

namespace tv_api.Entities
{
    class Command : ICommand
    {
        public ArraySegment<byte> Request { get; set; }
        public byte[] Response { get; set; }

        public Command(string uri, string type = "request", dynamic payload = null)
        {
            payload = payload == null ?  new { } : payload;

            object msg = new
            {
                id = $"Command_{typeof(LG).Name}_{uri}",
                type = type,
                uri = $"ssap://{uri}",
                payload = payload
            };

            Request = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(msg));
            Response = new byte[1024];
        }
    }
}
