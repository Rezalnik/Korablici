namespace SpaceBattle.Lib;

class CreateTreeFromtxt: IReader
{
    public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>> GetValue(string datas)
    {
        if (string.IsNullOrEmpty(datas))
        {
            return new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>>();
        }
        using (var fileReader = new StreamReader(datas))
        {
            var CollisionTree = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int>>>>();
            var thirdlevel = new Dictionary<int, int>();
            var secondlevel = new Dictionary<int, Dictionary<int, int>>();
            var firstlevel = new Dictionary<int, Dictionary<int, Dictionary<int, int>>>();

            string[] values = fileReader.ReadLine()!.Split(" ");
            thirdlevel.Add(Convert.ToInt32(values[3]), 1);
            secondlevel.Add(Convert.ToInt32(values[2]), thirdlevel);
            firstlevel.Add(Convert.ToInt32(values[1]), secondlevel);
            CollisionTree.Add(Convert.ToInt32(values[0]), firstlevel);
            
            thirdlevel.Clear();
            secondlevel.Clear();
            firstlevel.Clear();

            while (!fileReader.EndOfStream)
            {
                values = fileReader.ReadLine()!.Split(" ");
                if (!CollisionTree.ContainsKey(Convert.ToInt32(values[0])))
                {
                    thirdlevel.Add(Convert.ToInt32(values[3]), 1);
                    secondlevel.Add(Convert.ToInt32(values[2]), thirdlevel);
                    firstlevel.Add(Convert.ToInt32(values[1]), secondlevel);
                    CollisionTree.Add(Convert.ToInt32(values[0]), firstlevel);
                    
                    thirdlevel.Clear();
                    secondlevel.Clear();
                    firstlevel.Clear();
                }
                
                if (!CollisionTree[Convert.ToInt32(values[0])].ContainsKey(Convert.ToInt32(values[1])))
                {
                    thirdlevel.Add(Convert.ToInt32(values[3]), 1);
                    secondlevel.Add(Convert.ToInt32(values[2]), thirdlevel);
                    CollisionTree[Convert.ToInt32(values[0])].Add(Convert.ToInt32(values[1]), secondlevel);

                    thirdlevel.Clear();
                    secondlevel.Clear();
                }
                
                
                if (!CollisionTree[Convert.ToInt32(values[0])][Convert.ToInt32(values[1])].ContainsKey(Convert.ToInt32(values[2])))
                {
                    thirdlevel.Add(Convert.ToInt32(values[3]), 1);
                    CollisionTree[Convert.ToInt32(values[0])][Convert.ToInt32(values[1])].Add(Convert.ToInt32(values[2]), thirdlevel);

                    thirdlevel.Clear();
                }

                CollisionTree[Convert.ToInt32(values[0])][Convert.ToInt32(values[1])][Convert.ToInt32(values[2])].Add(Convert.ToInt32(values[3]), 1);
            }

            return CollisionTree;
        }
    }
}
