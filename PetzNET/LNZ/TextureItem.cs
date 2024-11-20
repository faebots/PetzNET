using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class TextureItem : LNZDataItem
    {
        public TextureItem(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split("  ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            Texture = line[0];
            ColorFlag = int.Parse(line[1]);
            if (line.Length > 2)
                TransparencyFactor = int.Parse(line[2]);
            if (line.Length > 3)
                TextureAdjust = int.Parse(line[3]);
        }

        public string Texture { get; set; }
        public int ColorFlag { get; set; }
        public int TransparencyFactor { get; set; } = -1;
        public int TextureAdjust { get; set; } = -1;
        public override string ToString()
        {
            var str = $"{Texture}     {ColorFlag}";
            if (TransparencyFactor > -1)
                str += $"     {TransparencyFactor}";
            if (TextureAdjust > -1)
                str += $"     {TextureAdjust}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
