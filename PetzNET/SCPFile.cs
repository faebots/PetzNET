using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public class SCPFile
    {
        public SCPFile(byte[] data)
        {
            Data = data;
        }
        public byte[] Data { get; set; }
    }
}
