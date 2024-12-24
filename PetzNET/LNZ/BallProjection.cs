using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallProjection : LNZDataItem
    {
        public BallProjection(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', '\t', ','], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            AnchorBall = int.Parse(line[0]);
            LinkedBall = int.Parse(line[1]);
            Offset = int.Parse(line[2]);
        } 

        public int AnchorBall { get; set; }
        public int LinkedBall { get; set; }
        public int Offset { get; set; }
        public override string ToString()
        {
            var str = $"{AnchorBall},\t{LinkedBall},\t{Offset}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "AnchorBall", AnchorBall.ToString() },
                { "LinkedBall", LinkedBall.ToString() },
                { "Offset", Offset.ToString() },
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
