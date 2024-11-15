using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class EyelidColor : LNZDataItem
    {
        public EyelidColor(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split([' ','\t',','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Color = int.Parse(line[0]);
            if (line.Length > 1 )
                Group = int.Parse(line[1]);
        }

        public int Color { get; set; }
        public int Group { get; set; }
    }
}
