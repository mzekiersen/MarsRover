using MarsRover.Models;
using Moq;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [TestFixture]
        public class Rover_Get_Initialized_Values
        {
            Mock<IPlateau> mockPlateau;

            [SetUp]
            public void Setup()
            {
                mockPlateau= new Mock<IPlateau>();
                var expectedPoint = new Position { PointX = 1, PointY = 2 };
                mockPlateau.Setup(i => i.PositionIsInsidePlataeu(expectedPoint)).Returns(true);                
            }

            [TestCase("1 2 L",1)]
            [TestCase("3 4 W", 3)]
            public void Initialize_Rover_Should_Returns_Given_Same_PositionX(string pConsoleRoverInput,int pPositionX)
            {
                var rover = new Rover();
                rover.InitializeRover(mockPlateau.Object, pConsoleRoverInput);
                Assert.AreEqual(rover.Position.PointX, pPositionX);
            }

            [TestCase("1 2 L", 2)]
            [TestCase("3 4 W", 4)]
            public void Initialize_Rover_Should_Returns_Given_Same_PositionY(string pConsoleRoverInput, int pPositionY)
            {
                var rover = new Rover();
                rover.InitializeRover(mockPlateau.Object, pConsoleRoverInput);
                Assert.AreEqual(rover.Position.PointY, pPositionY);
            }

            [TestCase("1 2 L", "L")]
            [TestCase("3 4 W", "W")]
            public void Initialize_Rover_Should_Returns_Given_Same_Direction(string pConsoleRoverInput, string pDirection)
            {
                var rover = new Rover();
                rover.InitializeRover(mockPlateau.Object, pConsoleRoverInput);
                Assert.AreEqual(rover.Direction, pDirection);
            }

            [TestCase("1 2 L", "Rover Position : 1 2 L")]
            [TestCase("3 4 W", "Rover Position : 3 4 W")]
            public void Initialize_Rover_Should_Returns_Formatted_String(string pConsoleRoverInput, string pFormattedString)
            {
                var rover = new Rover();
                rover.InitializeRover(mockPlateau.Object, pConsoleRoverInput);
                Assert.AreEqual(rover.ToString(), pFormattedString);
            }

        }
    }
}
