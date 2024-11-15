﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class LNZSection<T> where T : LNZDataItem
    {
        public T DataItemFromString(string str)
        {
            return typeof(T).GetConstructor([typeof(string)]).Invoke(new object[] {str}) as T;
        }

        public LNZSection(string name, string data)
        {
            Name = name;
            RawData = data;
            Parse();
        }
        
        public string Name { get; set; }
        public IList<T> Items { get; set; } = new List<T>();
        public string RawData { get; set; }
        public IList<int> Variations { get; set; } = new List<int>();
        public IList<Dictionary<int, string>> BoundVariations { get; set; } = new List<Dictionary<int, string>>();
        public void Parse()
        {
            var inVariation = false;
            var index = -1;
            var id = "";
            foreach (var l in RawData.Split('\n'))
            {
                var line = l.Trim();
                if (line.StartsWith('#'))
                {
                    line = line.Split(';')[0].Trim();
                    var name = line.Substring(1);
                    if (name == "#")
                    {
                        inVariation = false;
                        id = "";
                        continue;
                    }
                    if (!inVariation)
                    {
                        var count = int.Parse(name.Split('.')[0]);
                        Variations.Add(count);
                        BoundVariations.Add(new Dictionary<int, string>());
                        inVariation = true;
                        index++;
                    }
                    id = name;
                    if (id.IndexOf(".") > -1)
                    {
                        var num = int.Parse(id.Split('.')[0]);
                        BoundVariations[index][num] = id.Split('.')[1];
                    }
                    continue;
                }
                if (string.IsNullOrEmpty(line) || line.StartsWith(";") || line.StartsWith("["))
                    continue;
                var dataItem = DataItemFromString(line.Trim());
                if (inVariation)
                {
                    dataItem.Variation = id;
                    dataItem.VariationIndex = index;
                }
                Items.Add(dataItem);
            }
        }
    }
}