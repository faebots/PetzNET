using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class HeadShotAttribute : LNZDataItem
    {
        public HeadShotAttribute(string str) : base(str) 
        { 
            str = SetComment(str);
            var line = str.Split("  ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (line.Length > 1)
                Label = line[0];
            line = line[0].Split([' ', '\t', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Col1 = int.Parse(line[0]);
            if (line.Length > 1 && int.TryParse(line[1], out int x))
                Col2 = x;
        }

        public int Col1 { get; set; }
        public int Col2 { get; set; }
        public string Label { get; set; }
    }
}
