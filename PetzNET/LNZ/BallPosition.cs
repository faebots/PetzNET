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
        }

        public int BallNumber { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; } 
    }
}
