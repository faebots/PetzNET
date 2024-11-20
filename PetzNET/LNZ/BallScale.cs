using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallScale : LNZDataItem
    {
        public BallScale(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split([' ', '\t', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Scale = int.Parse(line[0]);
            if (line.Length > 1)
                Label = line[1];
        } 

        public int Scale { get; set; }
        public string? Label {  get; set; }
        public override string ToString()
        {
            var str = Scale.ToString();
            if (Label != null)
                str += $",\t{Label}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
