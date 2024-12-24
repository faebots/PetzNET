
namespace PetzNET.LNZ
{
    public interface ILNZSection
    {
        IList<Dictionary<int, string>> BoundVariations { get; set; }
        IList<LNZDataItem> DefaultItems { get; }
        IList<LNZDataItem> Items { get; set; }
        string Name { get; set; }
        string RawData { get; set; }
        IList<int> Variations { get; set; }

        void AddVariation(int index);
        void AddVariationSet(int count);
        LNZDataItem DataItemFromString(string str);
        IList<LNZDataItem> ItemsByVariation(int variationIndex);
        IList<LNZDataItem> ItemsByVariation(int variationIndex, int variation);
        void Parse();
        string ToString();
    }
}