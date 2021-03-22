using System;

namespace tv_api.Entities
{
    public class ICommand
    {
        public virtual ArraySegment<byte> Request { get; set; } = new ArraySegment<byte>();
        public byte[] Response { get; set; } = new byte[1024];
    }
}
