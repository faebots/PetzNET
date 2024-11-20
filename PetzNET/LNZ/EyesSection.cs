using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzNET.LNZ
{
    public class EyesSection : LNZSection<EyeDefinition>
    {
        public EyesSection(string name, string data) : base("Eyes", data)
        {
        }

        public int RightEye {
            get => DefaultItems[0].Right;
            set => DefaultItems[0].Right = value;
        }
        public int LeftEye
        {
            get => DefaultItems[0].Left;
            set => DefaultItems[0].Left = value;
        }
        public int RightIris
        {
            get => DefaultItems[1].Right;
            set => DefaultItems[1].Right = value;
        }
        public int LeftIris
        {
            get => DefaultItems[1].Left;
            set => DefaultItems[1].Left = value;
        }

        public int RightEyeVariation(int variationIndex, int variation)
        {
            var variations = ItemsByVariation(variationIndex, variation);
            if (variations.Count < 1)
                return -1;
            return variations[0].Right;
        }

        public int LeftEyeVariation(int variationIndex, int variation)
        {
            var variations = ItemsByVariation(variationIndex, variation);
            if (variations.Count < 1)
                return -1;
            return variations[0].Left;
        }

        public int RightIrisVariation(int variationIndex, int variation)
        {
            var variations = ItemsByVariation(variationIndex, variation);
            if (variations.Count < 2)
                return -1;
            return variations[1].Right;
        }

        public int LeftIrisVariation(int variationIndex, int variation)
        {
            var variations = ItemsByVariation(variationIndex, variation);
            if (variations.Count < 2)
                return -1;
            return variations[1].Left;
        }
    }
}
