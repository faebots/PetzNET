using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public class LNZFile
    {
        public LNZFile(byte[] data) 
        {
            RawData = data;
        }
        public byte[] RawData { get; set; }
    }
}
