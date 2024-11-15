using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PetzNET.LNZ
{
    public class ClothingItem : LNZDataItem
    {
        public ClothingItem(string str) : base(str)
        {
            str = SetComment(str);
            var match = Regex.Match(str, @"^(?<kind>\w+)\s+""(?<file>[^""]+)""\s+""(?<lnz>[^""]+)""$");
            if (!match.Success)
                throw new ArgumentException();

            Kind = match.Groups["kind"].Value;
            ClothesFile = match.Groups["file"].Value;
            ClothesLNZ = match.Groups["lnz"].Value;
        }

        public string Kind { get; set; }
        public string ClothesFile { get; set; }
        public string ClothesLNZ { get; set; }
    }
}
