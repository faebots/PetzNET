﻿using System;
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
        public override string ToString()
        {
            var str = $"{Kind}     \"{ClothesFile}\" \"{ClothesLNZ}\"";
            if (!string.IsNullOrEmpty(Comment))
                str += $"\t; {Comment}";
            return str;
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Kind", Kind },
                { "ClothesFile", ClothesFile },
                { "ClothesLNZ", ClothesLNZ }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
