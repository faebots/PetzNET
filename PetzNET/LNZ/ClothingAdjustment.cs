using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class ClothingAdjustment : LNZDataItem
    {
        public ClothingAdjustment(string str) : base(str)
        {
            str = SetComment(str);
            var cols = str.Split(['\t', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Kind = cols[0];
            Offset = cols[1].Trim().Split(',').Select(i => float.Parse(i)).ToArray();
            Scale = float.Parse(cols[2].Trim());
        }

        public string Kind { get; set; }
        public float[] Offset { get; set; }
        public float Scale { get; set; }

        public override string ToString()
        {
            var str = $"{Kind}     {Offset[0]},{Offset[1]},{Offset[2]}     {Scale}";
            if (Comment != null)
                str += $"; {Comment}";
            return str;
        }
    }
}
