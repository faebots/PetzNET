using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class EyeDefinition : LNZDataItem
    {
        public EyeDefinition(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ','\t',','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Right = int.Parse(line[0]);
            Left = int.Parse(line[1]);
        }

        public int Right { get; set; }
        public int Left { get; set; }
        public override string ToString()
        {
            var str = $"{Right}, {Left}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Right", Right.ToString() },
                { "Left", Left.ToString() }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
