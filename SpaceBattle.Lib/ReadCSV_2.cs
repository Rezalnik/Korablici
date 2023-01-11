namespace SpaceBattle.Lib;

public class ReadCSV: ICommand
{
    private string spliter;
    private string fileway;
    private List<Dictionary<string, object?>> table;
    public ReadCSV(string fileway, string spliter="; ")
    {
        this.table = new List<Dictionary<string, object?>>();
        this.fileway = fileway;
        this.spliter = spliter;
    }

    public void Execute()
    {
        var reader = new StreamReader(fileway);
        IList<string> listHEADERS = reader.ReadLine()!.Split("; ");
        
        while (!reader.EndOfStream)
        {
            string[] values = reader.ReadLine()!.Split("; ");
            table.Add(new Dictionary<string, object?>(listHEADERS.Zip(values, (k, v) => new KeyValuePair<string, object?>(k, (object?)v))));
        }
    }
}
