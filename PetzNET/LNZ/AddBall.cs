using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class AddBall : LNZDataItem
    {
        public AddBall(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split([',', ' ', '\t'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BaseBall = int.Parse(line[0]);
            X = float.Parse(line[1]);
            Y = float.Parse(line[2]);
            Z = float.Parse(line[3]);
            Color = int.Parse(line[4]);
            OutlineColor = int.Parse(line[5]);
            Fuzz = int.Parse(line[6]);
            Group = int.Parse(line[7]);
            Outline = int.Parse(line[8]);
            Size = int.Parse(line[9]);
            BodyArea = int.Parse(line[10]);
            AddGroup = int.Parse(line[11]);
            Texture = int.Parse(line[12]);
            if (line.Length > 13)
                RelativeTo = int.Parse(line[13]);
        }

        public int BaseBall { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Color { get; set; }
        public int OutlineColor { get; set; }
        public int Fuzz { get; set; }
        public int Group { get; set; }
        public int Outline { get; set; }
        public int Size { get; set; }
        public int BodyArea { get; set; }
        public int AddGroup { get; set; }
        public int Texture { get; set; }
        public int RelativeTo { get; set; } = -1;

        public override string ToString()
        {
            var str = $"{BaseBall},\t{X},\t{Y},\t{Z},\t{Color},\t{OutlineColor},\t{Fuzz},\t{Group},\t{Outline},\t{Size},\t{BodyArea},\t{AddGroup},\t{Texture}";
            if (RelativeTo > -1)
                str += $",\t{RelativeTo}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var relativeTo = RelativeTo > -1 ? RelativeTo.ToString() : string.Empty;
            var dict = new Dictionary<string, string>
            {
                { "BaseBall", BaseBall.ToString() },
                { "X", X.ToString() },
                { "Y", Y.ToString() },
                { "Z", Z.ToString() },
                { "Color", Color.ToString() },
                { "OutlineColor", OutlineColor.ToString() },
                { "Fuzz", Fuzz.ToString() },
                { "Group", Group.ToString() },
                { "Outline", Outline.ToString() },
                { "Size", Size.ToString() },
                { "BodyArea", BodyArea.ToString() },
                { "AddGroup", AddGroup.ToString() },
                { "Texture", Texture.ToString() },
                { "RelativeTo", relativeTo }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
