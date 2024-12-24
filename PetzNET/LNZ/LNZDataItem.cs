using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public abstract class LNZDataItem
    {
        public static LNZDataItem FromString(string str, Type type)
        {
            if (!type.IsAssignableTo(typeof(LNZDataItem)))
            {
                throw new ArgumentException();
            }
            return type.GetConstructor([typeof(string)]).Invoke(new object[] {str}) as LNZDataItem;
        }

        public virtual IDictionary<string, string> GetFields()
        {
            return new Dictionary<string, string>
            {
                { "Comment", Comment },
                { "Variation", Variation },
                { "VariationIndex", VariationIndex.ToString() }
            };
        }

        protected string SetComment(string str)
        {
            var line = str.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (line.Length > 1)
                Comment = line[1];
            if (line.Length > 0)
                return line[0];
            return "";
        }

        protected IDictionary<string, string> MergeDicts(IDictionary<string, string> dict1, IDictionary<string, string> dict2)
        {
            foreach (var key in dict2.Keys)
                dict1[key] = dict2[key];
            return dict1;
        }

        internal LNZDataItem(string str) { }
        public string? Comment { get; set; }
        public string? Variation { get; set; }
        public int? VariationIndex { get; set; }
    }

    public class LNZDataString : LNZDataItem
    {
        public LNZDataString(string str) : base(str)
        {
            str = SetComment(str);
            Value = str;
        }

        public string Value { get; set; }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Value", Value }
            };
            return MergeDicts(dict, base.GetFields());
        }

        public override string ToString()
        {
            return Comment == null ?
                Value :
                Value + $"\t; {Comment}";
        }
    }

    public class LNZDataBool : LNZDataItem
    {
        public LNZDataBool(string str) : base(str)
        {
            str = SetComment(str);
            Value = str == "1";
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Value", (Value ? 1 : 0).ToString() }
            };
            return MergeDicts(dict, base.GetFields());
        }

        public bool Value { get; set; }
        public override string ToString()
        {
            var val = Value ? 1 : 0;
            return Comment == null ?
                val.ToString() :
                $"{val}\t; {Comment}";
        }
    }

    public class LNZDataInt : LNZDataItem
    {
        public LNZDataInt(string str) : base(str)
        {
            str = SetComment(str);
            Value = int.Parse(str);
        }
        public int Value { get; set; }

        public override string ToString()
        {
            return Comment == null ?
                Value.ToString() :
                $"{Value}\t; {Comment}";
        }

        public override IDictionary<string, string> GetFields()
        {
            var dict = new Dictionary<string, string>
            {
                { "Value", Value.ToString() }
            };
            return MergeDicts(dict, base.GetFields());
        }
    }
}
