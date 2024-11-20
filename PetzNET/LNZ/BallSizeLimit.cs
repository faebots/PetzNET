using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallSizeLimit : LNZDataItem
    {
        public BallSizeLimit(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split([',', ' ', '\t'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BallNumber = int.Parse(line[0]);
            Thin = int.Parse(line[1]);
            Fat = int.Parse(line[2]);
        }

        public int BallNumber { get; set; }
        public int Thin { get; set; }
        public int Fat { get; set; }
        public override string ToString()
        {
            var str = $"{BallNumber},\t{Thin},\t{Fat}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }
    }
}
