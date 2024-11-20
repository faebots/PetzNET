using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallInfo : LNZDataItem
    {
        public BallInfo(string str) : base(str) 
        { 
            str = SetComment(str);
            var line = str.Split([' ','\t',','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            Color = int.Parse(line[0]);
            OutlineColor = int.Parse(line[1]);
            SpeckleColor = int.Parse(line[2]);
            Fuzz = int.Parse(line[3]);
            OutlineType = int.Parse(line[4]);
            SizeDif = int.Parse(line[5]);
            Texture = int.Parse(line[6]);
            if (line.Length > 7)
                BallNumber = int.Parse(line[7]);
        }

        public int Color { get; set; }
        public int OutlineColor { get; set; }
        public int SpeckleColor { get; set; }
        public int Fuzz {  get; set; }
        public int OutlineType {  get; set; }
        public int SizeDif { get; set; }
        public int Texture {  get; set; }
        public int BallNumber { get; set; } = -1;
        public override string ToString()
        {
            var str = $"{Color},\t{OutlineColor},\t{SpeckleColor},\t{Fuzz},\t{OutlineType},\t{SizeDif},\t{Texture}";
            if (BallNumber > -1)
                str += $",\t{BallNumber}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
