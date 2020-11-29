using MarsRover.Helpers;
using MarsRover.Models;
using Moq;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class CommandTests
    {
        [TestFixture]
        public class Command_Actions_Left_Command
        {
            Mock<IRover> mockRover;
            readonly string leftCommand = "L";

            [SetUp]
            public void Setup()
            {
                mockRover = new Mock<IRover>();
                mockRover.Setup(i => i.Position).Returns(new Position { PointX = 1, PointY = 1 }); 
            }

            [Test]
            public void Command_Actions_Turn_Left_When_Direction_N()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "N", leftCommand);
                Assert.AreEqual("W", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Left_When_Direction_W()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "W", leftCommand);
                Assert.AreEqual("S", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Left_When_Direction_S()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "S", leftCommand);
                Assert.AreEqual("E", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Left_When_Direction_E()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "E", leftCommand);
                Assert.AreEqual("N", commandResultByRover.Direction);
            }
        }
        [TestFixture]
        public class Command_Actions_Right_Command
        {
            Mock<IRover> mockRover;
            readonly string rightCommand = "R";

            [SetUp]
            public void Setup()
            {
                mockRover = new Mock<IRover>();
                mockRover.Setup(i => i.Position).Returns(new Position { PointX = 1, PointY = 1 });
            }

            [Test]
            public void Command_Actions_Turn_Right_When_Direction_N()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "N", rightCommand);
                Assert.AreEqual("E", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Right_When_Direction_W()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "W", rightCommand);
                Assert.AreEqual("N", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Right_When_Direction_S()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "S", rightCommand);
                Assert.AreEqual("W", commandResultByRover.Direction);
            }

            [Test]
            public void Command_Actions_Turn_Right_When_Direction_E()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "E", rightCommand);
                Assert.AreEqual("S", commandResultByRover.Direction);
            }
        }

        [TestFixture]
        public class Command_Actions_Move_Command
        {
            Mock<IRover> mockRover;
            readonly string moveCommand = "M";

            [SetUp]
            public void Setup()
            {
                mockRover = new Mock<IRover>();
                mockRover.Setup(i => i.Position).Returns(new Position { PointX = 1, PointY = 1 });
            }

            [Test]
            public void Command_Actions_Move_When_Direction_N()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "N", moveCommand);
                Assert.AreEqual(2, commandResultByRover.Position.PointY);
            }

            [Test]
            public void Command_Actions_Move_When_Direction_W()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "W", moveCommand);
                Assert.AreEqual(0, commandResultByRover.Position.PointX);
            }

            [Test]
            public void Command_Actions_Move_When_Direction_S()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "S", moveCommand);
                Assert.AreEqual(0, commandResultByRover.Position.PointY);
            }

            [Test]
            public void Command_Actions_Move_When_Direction_E()
            {
                var commandResultByRover = CommandHelper.CalculateResult(mockRover.Object.Position, "E", moveCommand);
                Assert.AreEqual(2, commandResultByRover.Position.PointX);
            }
        }
    }
}
