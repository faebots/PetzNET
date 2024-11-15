using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class Linez : LNZDataItem
    {
        public Linez(string str) : base(str) 
        {
            str = SetComment(str);

        }

        public int StartBall { get; set; }
        public int EndBall { get; set; }
        public int Fuzz { get; set; }
        public int Color { get; set; }
        public int LeftOutlineColor { get; set; }
        public int RightOutlineColor { get; set; }
        public int StartThick { get; set; }
        public int EndThick { get; set; }
        public int OutlineFlag { get; set; }
        public int LineOutside { get; set; }
    }
}
