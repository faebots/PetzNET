using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET
{
    public class RCData
    {
        public RCData(byte[] data)
        {
            var spriteName = data[4..36];
            var displayName = data[36..68];
            var id = data[68..72];
            var tag = data[72..];

            SpriteName = Encoding.ASCII.GetString(spriteName).Trim('\0');
            DisplayName = Encoding.ASCII.GetString(displayName).Trim('\0');
            HexId = BitConverter.ToInt32(id);
            Tag = BitConverter.ToInt32(tag);
            RawData = data;
        }
        public string SpriteName { get; set; }
        public string DisplayName { get; set; }
        public int HexId { get; set; }
        public int Tag { get; set; }
        public byte[] RawData { get; set; }
    }
}
