using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallPosition : LNZDataItem
    {
        public BallPosition(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', ',', '\t'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BallNumber = int.Parse(line[0]);
            X = float.Parse(line[1]);
            Y = float.Parse(line[2]);
            Z = float.Parse(line[3]);
            if (line.Length > 4)
                Anchor = int.Parse(line[4]);
        }

        public int BallNumber { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Anchor { get; set; } = -1;
        public override string ToString()
        {
            var str = $"{BallNumber},\t{X},\t{Y},\t{Z}";
            if (Anchor > -1)
                str += $",\t{Anchor}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
