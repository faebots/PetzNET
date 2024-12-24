using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class Whisker : LNZDataItem
    {
        public Whisker(string str) : base(str) 
        {
            str = SetComment(str);
            var line = str.Split([' ', '\t', ','], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            StartBall = int.Parse(line[0]);
            EndBall = int.Parse(line[1]);
            Color = int.Parse(line[2]);
        }

        public int StartBall { get; set; }
        public int EndBall { get; set; }
        public int Color {  get; set; }
        public override string ToString()
        {
            var str = $"{StartBall}, {EndBall}, {Color}";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "StartBall", StartBall.ToString() },
                { "EndBall", EndBall.ToString() },
                { "Color", Color.ToString() }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
