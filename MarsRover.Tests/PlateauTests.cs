using MarsRover.Models;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [TestFixture]
        public class Plateau_Get_Initialized_Values
        {
            [TestCase("3 4", 3, 4)]
            [TestCase("4 5", 4, 5)]
            public void Initialize_Plateau_Should_Returns_Given_Same_WidthX(string pConsolePlateauSizeInput, int pExpectedPlateauWidth, int pExpectedPlateauHeight)
            {
                var expectedPlateauSize = new PlateauSize
                {
                    WidthX = pExpectedPlateauWidth,
                    HeigthY = pExpectedPlateauHeight
                };

                var plateau = new Plateau();
                plateau.InitializePlateau(pConsolePlateauSizeInput);
                Assert.AreEqual(expectedPlateauSize.WidthX, plateau.PlateauSize.WidthX);
            }

            [TestCase("3 4", 3, 4)]
            [TestCase("4 5", 4, 5)]
            public void Initialize_Plateau_Should_Returns_Given_Same_HeightY(string pConsolePlateauSizeInput, int pExpectedPlateauWidth, int pExpectedPlateauHeight)
            {
                var expectedPlateauSize = new PlateauSize
                {
                    WidthX = pExpectedPlateauWidth,
                    HeigthY = pExpectedPlateauHeight
                };

                var plateau = new Plateau();
                plateau.InitializePlateau(pConsolePlateauSizeInput);                

                Assert.AreEqual(expectedPlateauSize.HeigthY, plateau.PlateauSize.HeigthY);
            }            
        }

        [TestFixture]
        public class Plateau_IsPositionInsidePlateau
        {
            [TestCase("1 1", 0, 0)]
            [TestCase("1 3", 1, 1)]
            [TestCase("2 3", 2, 3)]
            [TestCase("7 6", 4, 5)]
            public void When_Given_Position_is_Inside_Plateau_Returns_True(string pConsolePlateauSizeInput, int pPositionX, int pPositionY)
            {
                var plateau = new Plateau();
                plateau.InitializePlateau(pConsolePlateauSizeInput);

                var controlPosition = new Position
                {
                    PointX = pPositionX,
                    PointY = pPositionY
                };

                Assert.That(plateau.PositionIsInsidePlataeu(controlPosition));
            }


            [TestCase("1 1", 3, 0)]
            [TestCase("1 3", -1, 1)]
            [TestCase("2 3", 5, 3)]
            [TestCase("7 6", 4, -4)]
            public void When_Given_Position_is_Outside_Plateau_Returns_False(string pConsolePlateauSizeInput, int pPositionX, int pPositionY)
            {
                var plateau = new Plateau();
                plateau.InitializePlateau(pConsolePlateauSizeInput);

                var controlPosition = new Position
                {
                    PointX = pPositionX,
                    PointY = pPositionY
                };

                Assert.That(!plateau.PositionIsInsidePlataeu(controlPosition));
            }

        }
    }
}