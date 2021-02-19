using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tv_api.Entities
{
    interface ICommand
    {
        public static ArraySegment<byte> Request { get; set; }
        public static byte[] Response { get; set; }
    }
}