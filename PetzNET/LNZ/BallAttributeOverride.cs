using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class BallAttributeOverride : LNZDataItem
    {
        public BallAttributeOverride(string str) : base(str)
        {
            str = SetComment(str);
            var cols = str.Split(['\t', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            BallNumber = int.Parse(cols[0]);
            AttributeValue = int.Parse(cols[1]);
        }

        public int BallNumber { get; set; }
        public int AttributeValue { get; set; }
        public override string ToString()
        {
            var str = $"{BallNumber},\t{AttributeValue}";
            if (!string.IsNullOrEmpty(Comment))
            {
                str += $"\t; {Comment}";
            }
            return str;
        }
    }
}
