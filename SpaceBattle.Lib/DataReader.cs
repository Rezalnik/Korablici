namespace SpaceBattle.Lib;

class DataReader
{
    public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>> GetValue(IReader reader, string datas)
    {
        return reader.GetValue(datas);
    }
}
