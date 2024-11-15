using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class LabeledBall : LNZDataItem
    {
        public LabeledBall(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split(["  ", "\t"], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BallNumber = int.Parse(line[0]);
            if (line.Length > 1)
                Label = line[1];
        }

        public int BallNumber { get; set; }
        public string Label { get; set; }
    }
}
