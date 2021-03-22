using Newtonsoft.Json;
using System;
using System.Text;

namespace tv_api.Entities
{
    class CommandLG : ICommand
    {
        public override ArraySegment<byte> Request 
        {
            get {
                object msg = new
                {
                    id = $"Command_{typeof(LG).Name}_{Uri}",
                    type = Type,
                    uri = $"ssap://{Uri}",
                    payload = Payload
                };

                return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(msg));
            }
        }
        public string Uri { get; set; }
        public string Type { get; set; }
        public dynamic Payload { get; set; }

        public CommandLG(string uri, string type = "request", dynamic payload = null)
        {
            Uri = uri;
            Type = type;
            Payload = payload == null ?  new { } : payload;
        }
    }
}
