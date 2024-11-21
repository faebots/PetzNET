using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public class BreedFile : IPetzFile
    {
        public PetzVersion Version { get; set; }
        public FileType FileType { get; private set; } = FileType.Breed;
        public string BreedName { get; set; }
        public string DefaultPetName { get; set; }
        public Dictionary<string, LNZFile> LNZFiles { get; private set; } = new Dictionary<string, LNZFile>();
        public Dictionary<ushort, Dictionary<ushort, string>> StringTables { get; private set; } = new Dictionary<ushort, Dictionary<ushort, string>>();
        public RCData RCData { get; set; }
        public Dictionary<string, Bitmap> Bitmaps { get; private set; } = new Dictionary<string, Bitmap>();
        public SCPFile SCP { get; set; }

    }
}
