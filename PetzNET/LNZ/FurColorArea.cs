using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class FurColorArea : LNZDataItem
    {
        public FurColorArea(string str) : base(str) 
        {
            str = SetComment(str);
            var cols = str.Split('\t', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            FurColorTrait = Int32.Parse(cols[0]);
            BallWithBaseColor = Int32.Parse(cols[1]);
            if (cols[2].StartsWith("rampbase:"))
            {
                var x = Int32.Parse(cols[2].Split(':')[1].Trim());
                var y = Int32.Parse(cols[3]);
                Rampbase = (x, y);
            }
            else
            {
                ColorAreas = cols[2].Split(",").Select(i => Int32.Parse(i.Trim())).ToList();
            }
        }

        public int FurColorTrait { get; set; }
        public int BallWithBaseColor { get; set; }
        public IList<int> ColorAreas { get; private set; } = new List<int>();
        public (int, int)? Rampbase { get; set; }

        public override string ToString()
        {
            if (Rampbase.HasValue)
            {
                return $"{FurColorTrait}\t\t\t\t{BallWithBaseColor}\trampbase: {Rampbase.Value.Item1}\t\t{Rampbase.Value.Item2}";
            }
            else
            {
                return $"{FurColorTrait}\t\t\t\t{BallWithBaseColor}\t\t\t\t\t{String.Join(", ", ColorAreas)}";
            }
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "FurColorTrait", FurColorTrait.ToString() },
                { "BallWithBaseColor", BallWithBaseColor.ToString() },
                { "RampbaseX", string.Empty },
                { "RampbaseY", string.Empty },
                { "ColorAreas", string.Empty }
            };
            if (Rampbase.HasValue)
            {
                dict["RampbaseX"] = Rampbase.Value.Item1.ToString();
                dict["RampbaseY"] = Rampbase.Value.Item2.ToString();
            }
            else
            {
                dict["ColorAreas"] = String.Join(", ", ColorAreas);
            }
            return MergeDicts(dict, base.GetFields());
        }
    }
}
