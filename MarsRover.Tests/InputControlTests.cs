using MarsRover.Helpers;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class InputControlTests
    {
        [TestFixture]
        public class Plateau_Console_Input_Validation
        {
            [TestCase("3 4")]
            [TestCase("4 5")]
            [TestCase("8 9")]
            public void Plateau_Console_Input_Validation_Returns_True(string pPlateauInputString)
            {
                Assert.IsTrue(pPlateauInputString.IsPlateauSizeInputValid());
            }

            [TestCase("34")]
            [TestCase("4- 5")]
            [TestCase("-8 9")]
            [TestCase("8 9 4")]
            [TestCase("a v 9")]
            public void Plateau_Console_Input_Validation_Returns_False(string pPlateauInputString)
            {
                Assert.IsTrue(!pPlateauInputString.IsPlateauSizeInputValid());
            }
        }

        [TestFixture]
        public class Rover_Position_Console_Input_Validation
        {
            [TestCase("3 4 W")]
            [TestCase("4 5 E")]
            [TestCase("8 9 S")]
            [TestCase("1 2 N")]
            public void Rover_Position_Console_Input_Validation_Returns_True(string pRoverPositionInputString)
            {
                Assert.IsTrue(pRoverPositionInputString.IsRoverPositionInputValid());
            }

            [TestCase("34")]
            [TestCase("4 5")]
            [TestCase("-8 9")]
            [TestCase("8 9 D")]
            [TestCase("a v 9")]
            public void Rover_Position_Console_Input_Validation_Returns_False(string pRoverPositionInputString)
            {
                Assert.IsTrue(!pRoverPositionInputString.IsRoverPositionInputValid());
            }
        }

        [TestFixture]
        public class Rover_Command_Console_Input_Validation
        {
            [TestCase("RLMMRL")]
            [TestCase("LLLL")]
            [TestCase("MRLRLRMRMRMRM")]
            public void Rover_Command_Console_Input_Validation_Returns_True(string pRoverCommandInputString)
            {
                Assert.IsTrue(pRoverCommandInputString.IsRoverActionCommandInputValid());
            }

            [TestCase("34")]
            [TestCase("4 5")]
            [TestCase("DSFMD")]
            [TestCase("SD34")]
            public void Rover_Command_Console_Input_Validation_Returns_False(string pRoverCommandInputString)
            {
                Assert.IsTrue(!pRoverCommandInputString.IsRoverActionCommandInputValid());
            }
        }

    }
}
