using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class Linez : LNZDataItem
    {
        public Linez(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', ',', '\t'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            StartBall = int.Parse(line[0]);
            EndBall = int.Parse(line[1]);
            Fuzz = int.Parse(line[2]);
            Color = int.Parse(line[3]);
            LeftOutlineColor = int.Parse(line[4]);
            RightOutlineColor = int.Parse(line[5]);
            StartThick = int.Parse(line[6]);
            EndThick = int.Parse(line[7]);
            if (line.Length > 8)
                OutlineFlag = int.Parse(line[8]);
            if (line.Length > 9)
                LineOutside = int.Parse(line[9]);
        }

        public int StartBall { get; set; }
        public int EndBall { get; set; }
        public int Fuzz { get; set; }
        public int Color { get; set; }
        public int LeftOutlineColor { get; set; }
        public int RightOutlineColor { get; set; }
        public int StartThick { get; set; }
        public int EndThick { get; set; }
        public int OutlineFlag { get; set; } = -1;
        public int LineOutside { get; set; } = -1;
        public override string ToString()
        {
            var str = $"{StartBall}, {EndBall},\t{Fuzz},\t{Color},\t{LeftOutlineColor},\t{RightOutlineColor},\t{StartThick},\t{EndThick}";
            if (OutlineFlag > -1)
                str += $",\t{OutlineFlag}";
            if (LineOutside > -1)
                str += $",\t{LineOutside}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var outlineFlag = OutlineFlag > -1 ? OutlineFlag.ToString() : "";
            var lineOutside = LineOutside > -1 ? LineOutside.ToString() : "";
            var dict = new Dictionary<string, string>
            {
                { "StartBall", StartBall.ToString() },
                { "EndBall", EndBall.ToString() },
                { "Fuzz", Fuzz.ToString() },
                { "Color", Color.ToString() },
                { "LeftOutlineColor", LeftOutlineColor.ToString() },
                { "RightOutlineColor", RightOutlineColor.ToString() },
                { "StartThick", StartThick.ToString() },
                { "EndThick", EndThick.ToString() },
                { "OutlineFlag", outlineFlag },
                { "LineOutside", lineOutside }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
