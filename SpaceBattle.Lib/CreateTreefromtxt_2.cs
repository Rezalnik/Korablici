using Hwdtech;

namespace SpaceBattle.Lib;

public class CreateTreeFromtxt_2 : IStrategy
{
    public object ExecuteStrategy(params object[] args)
    {
        using (var fileReader = new StreamReader((string)args[0]))
        {
            var CollisionTree = IoC.Resolve<Dictionary<string, object>>("GetCollisionTree");

            while (!fileReader.EndOfStream)
            {
                string[] values = fileReader.ReadLine()!.Split(" ");

                var branch = CollisionTree;

                foreach (string value in values)
                {
                    branch.TryAdd(value, new Dictionary<string, object>());
                    branch = (Dictionary<string, object>) branch[value];
                }
            }
            return CollisionTree;
        }
    }
}
