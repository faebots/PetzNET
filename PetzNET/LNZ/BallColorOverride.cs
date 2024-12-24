using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallColorOverride : LNZDataItem
    {
        public BallColorOverride(string str) : base(str)
        {
            str = SetComment(str);
            var cols = str.Split(['\t', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            BallNumber = int.Parse(cols[0]);
            Color = int.Parse(cols[1]);
            if (cols.Length > 2)
                Group = int.Parse(cols[2]);
            if (cols.Length > 3)
                Texture = int.Parse(cols[3]);
        }

        public int BallNumber { get; set; }
        public int Color { get; set; }
        public int Group { get; set; } = -1;
        public int Texture { get; set; } = -1;

        public override string ToString()
        {
            var str = $"{BallNumber},\t{Color}";
            if (Group > -1)
            {
                str += $",\t{Group}";
                if (Texture > -1)
                    str += $",\t{Texture}";
            }
            if (Comment != null)
            {
                str += $"\t; {Comment}";
            }
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "BallNumber", BallNumber.ToString() },
                { "Color", Color.ToString() },
                { "Group", Group.ToString() },
                { "Texture", Texture.ToString() }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
