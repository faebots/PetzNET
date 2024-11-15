using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class FurPatternGroup : LNZDataItem
    {
        public FurPatternGroup(string str) : base(str)
        {
            str = SetComment(str);
            str = str.Remove(0, 9);
            var list = str.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            AddBalls = list.Select(s => int.Parse(s)).ToList();
        }

        public List<int> AddBalls { get; private set; } = new List<int>();

        public override string ToString()
        {
            return $"addballs:\t{String.Join(", ", AddBalls)}\t; {Comment}\n";
        }
    }
}
