﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class AddBall : LNZDataItem
    {
        public AddBall(string str) : base(str)
        {
            str = SetComment(str);
            var line = str.Split([',', ' ', '\t'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            BaseBall = int.Parse(line[0]);
            X = float.Parse(line[1]);
            Y = float.Parse(line[2]);
            Z = float.Parse(line[3]);
            Color = int.Parse(line[4]);
            OutlineColor = int.Parse(line[5]);
            Fuzz = int.Parse(line[6]);
            Group = int.Parse(line[7]);
            Outline = int.Parse(line[8]);
            Size = int.Parse(line[9]);
            BodyArea = int.Parse(line[10]);
            AddGroup = int.Parse(line[11]);
            Texture = int.Parse(line[12]);
            if (line.Length > 13)
                RelativeTo = int.Parse(line[13]);
        }

        public int BaseBall { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Color { get; set; }
        public int OutlineColor { get; set; }
        public int Fuzz { get; set; }
        public int Group { get; set; }
        public int Outline { get; set; }
        public int Size { get; set; }
        public int BodyArea { get; set; }
        public int AddGroup { get; set; }
        public int Texture { get; set; }
        public int RelativeTo { get; set; } = -1;
    }
}