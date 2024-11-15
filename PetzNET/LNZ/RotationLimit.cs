using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class RotationLimit : LNZDataItem
    {
        public RotationLimit(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', ',', '\t'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            LowerLimit = int.Parse(line[0]);
            UpperLimit = int.Parse(line[1]);
        }

        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
    }
}
