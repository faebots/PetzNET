using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class FurMarking : LNZDataItem
    {
        public FurMarking(string str) : base(str)
        {
            str = SetComment(str);
            var cols = str.Split('\t', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            GroupType = (FurMarkingGroupType)Int32.Parse(cols[0]);
            BallGroup = cols[1].Split([' ', ','])
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Trim())
                .ToList();
        }

        public FurMarkingGroupType GroupType { get; set; }
        public List<string> BallGroup { get; private set; } = new List<string>();

        public override string ToString()
        {
            var str = $"{(int)GroupType}\t\t\t{string.Join(", ", BallGroup)}";
            if (Comment != null)
            {
                str += $"\t; {Comment}";
            }
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "GroupType", ((int)GroupType).ToString() },
                { "BallGroup", string.Join(", ", BallGroup) }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
