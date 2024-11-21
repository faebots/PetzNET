using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public interface IPetzFile
    {
        public PetzVersion Version { get; set; }
        public FileType FileType { get; }
        public Dictionary<ushort, Dictionary<ushort, string>> StringTables { get; }
        public RCData RCData { get; set; }
    }
}
