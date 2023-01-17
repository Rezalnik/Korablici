namespace SpaceBattle.Lib;

public interface IReader
{
    public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>> GetValue (string datas);
}
