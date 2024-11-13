using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public class BreedFile : IPetzFile
    {
        public PetzVersion Version { get; set; }
        public FileType FileType { get; private set; } = FileType.Breed;
        public Dictionary<string, LNZFile> LNZFiles { get; private set; } = new Dictionary<string, LNZFile>();
        public Dictionary<int, Dictionary<int, string>> StringTables { get; private set; } = new Dictionary<int, Dictionary<int, string>>();
        public RCData RCData { get; set; }
    }
}
