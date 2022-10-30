using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test;

public class MoveCommandTests
{
    [Fact]
    public void TestPositive()
    {
        //PRE
        Mock<IMove> movable = new Mock<IMove>();
        movable.SetupProperty(m => m.Position, new Vector(12, 5));
        movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));
        

        //ACTION
        MoveCommand command = new MoveCommand(movable.Object);
        command.Execute();

        //POST
        // var q = new Vector(5, 8); // костыли. Причина использования - кривой класс Vector (наверно)
        // var w = (q[0], q[1]);
        // var e = (movable.Object.Position[0], movable.Object.Position[1]);
        // Assert.Equal(w, e);
        Assert.Equal(new Vector(5, 8), movable.Object.Position);
    }

    // [Theory]
    // public void TestNegSetPosition()
    // {
    //     //PRE
    //     Mock<IMove> movable = new Mock<IMove>();
    //     movable.SetupProperty(m => m.Position, new Vector(12, 5));
    //     movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));
    //     movable.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();
    //     MoveCommand command = new MoveCommand(movable.Object);

    //     //ACTION
    //     command.Execute();

    //     //POST
    //     Assert.Throws<Exception>(() =>  command.Execute());
    // }
}