using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class PaintBall : LNZDataItem
    {
        public PaintBall(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', '\t', ','], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BallNumber = int.Parse(line[0]);
            Diameter = int.Parse(line[1]);
            X = float.Parse(line[2]);
            Y = float.Parse(line[3]);
            Z = float.Parse(line[4]);
            Color = int.Parse(line[5]);
            OutlineColor = int.Parse(line[6]);
            Fuzz = int.Parse(line[7]);
            Outline = int.Parse(line[8]);
            Group = int.Parse(line[9]);
            Texture = int.Parse(line[10]);
            if (line.Length > 11)
                ScaleTweak = int.Parse(line[11]);
        }

        public int BallNumber { get; set; }
        public int Diameter { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Color { get; set; }
        public int OutlineColor { get; set; }
        public int Fuzz { get; set; }
        public int Outline { get; set; }
        public int Group { get; set; }
        public int Texture { get; set; }
        public int ScaleTweak { get; set; } = -1;
        public override string ToString()
        {
            var str = $"{BallNumber},\t{Diameter},\t{X}, {Y}, {Z},\t{Color},\t{OutlineColor},\t{Fuzz},\t{Outline},\t{Group},\t{Texture}";
            if (ScaleTweak > -1)
                str += $",\t{ScaleTweak}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
