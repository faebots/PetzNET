using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PetzNET.LNZ
{
    public class TextureItem : LNZDataItem
    {
        public TextureItem(string str) : base(str)
        {
            str = SetComment(str);

            var re = @"(?<texture>.+\.\w{1,3})\s+(?<colorFlag>\d+)(\s+(?<transparencyFactor>\d+))?(\s+(?<textureAdjust>\d+))?";
            var match = Regex.Match(str, re);

            Texture = match.Groups["texture"].Value;
            ColorFlag = int.Parse(match.Groups["colorFlag"].Value);
            var transparencyFactor = match.Groups["transparencyFactor"].Value;
            if (int.TryParse(transparencyFactor, out int x))
                TransparencyFactor = x;
            var textureAdjust = match.Groups["textureAdjust"].Value;
            if (int.TryParse(textureAdjust, out x))
                TextureAdjust = x;
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

        public override IDictionary<string, string> GetFields()
        {
            var transparencyFactor = TransparencyFactor > -1 ? TransparencyFactor.ToString() : "";
            var textureAdjust = TextureAdjust > -1 ? TextureAdjust.ToString() : "";
            var dict = new Dictionary<string, string>
            {
                { "Texture", Texture },
                { "ColorFlag", ColorFlag.ToString() },
                { "TransparencyFactor", transparencyFactor },
                { "TextureAdjust", textureAdjust }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
