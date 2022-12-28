namespace SpaceBattle.Lib;

public class StartMoveCommand: IMoveCommandStartable
{
    private IUObject obj;
    StartMoveCommand(IUObject obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        
    }
}
