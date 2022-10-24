using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test;

public class MoveCommandTests
{
    [Fact]
    public void TestPositiveMove()
    {

        var m = new Mock<IMove>();
        m.Setup(a => a.Position).Returns(new Vector(12, 5)).Verifiable();
        m.Setup(a => a.Velocity).Returns(new Vector(-7, 3)).Verifiable();
        var c = new MoveCommand(m.Object);
        
        c.Execute();

        m.VerifySet(a => a.Position = new Vector(5, 8), Times.Once);
        m.VerifyAll();

        // //PRE
        // Mock<IMove> movable = new Mock<IMove>();
        // movable.SetupProperty(m => m.Position, new Vector(0, 0));
        // movable.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(1, 1));
        // MoveCommand command = new MoveCommand(movable.obj);

        // //ACTION
        // command.Execute();

        // //POST
        // Assert.Equal(new Vector(1, 1), movable.obj.Position);
    }
}