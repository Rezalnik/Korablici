namespace SpaceBattle.Lib;

public class CSVReader: ICommand
{
    private string spliter;
    private string fileway;
    public List<Dictionary<string, object?>> table;
    public CSVReader(string fileway, string spliter="; ")
    {
        this.table = new List<Dictionary<string, object?>>();
        this.fileway = fileway;
        this.spliter = spliter;
    }

    public void Execute()
    {
        using (var reader = new StreamReader(fileway))
        {
            IList<string> listHEADERS = reader.ReadLine()!.Split("; ");
            
            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine()!.Split("; ");
                table.Add(new Dictionary<string, object?>(listHEADERS.Zip(values, (k, v) => new KeyValuePair<string, object?>(k, (object?)v))));
            }
        }
    }
}
