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
            var offset = cols[1].Trim().Split(',').Select(i => float.Parse(i)).ToArray();
            X = offset[0];
            Y = offset[1];
            Z = offset[2];
            Scale = float.Parse(cols[2].Trim());
        }

        public string Kind { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Scale { get; set; }

        public override string ToString()
        {
            var str = $"{Kind}     {X},{Y},{Z}     {Scale}";
            if (Comment != null)
                str += $"; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Kind", Kind },
                { "X", X.ToString() },
                { "Y", Y.ToString() },
                { "Z", Z.ToString() },
                { "Scale", Scale.ToString() }
            };
            return base.GetFields();
        }
    }
}
