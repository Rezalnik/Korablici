using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using Xunit;

namespace SpaceBattle.Lib.Test;

public class TestCreateTree
{
    public void TestTree()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        var tree = new Mock<ICommand>();
        tree.Setup(t => t.Execute());

        var returnTree = new Mock<IStrategy>();
        returnTree.Setup(t => t.ExecuteStrategy(It.IsAny<string>())).Returns(tree.Object);

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "GetCollisionTree", (object[] args) => returnTree.Object.ExecuteStrategy(args)).Execute();
    }

    [Fact]
    public void TestPositive()
    {
        //PRE
        


        //ACTION


        //POST

    }
}
