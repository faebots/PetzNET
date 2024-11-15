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

        protected string SetComment(string str)
        {
            var line = str.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (line.Length > 1)
                Comment = line[1];
            return line[0];
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
    }
}
