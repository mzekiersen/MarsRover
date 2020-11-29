using System.Text.RegularExpressions;

namespace MarsRover.Helpers
{
    /// <summary>
    /// Control inputs from console
    /// </summary>
    public static class InputControlHelper
    {
        /// <summary>
        /// Control the Plateau size input is valid
        /// </summary>
        /// <param name="pInput">input size value</param>
        /// <returns>true --> if valid / false --> if not valid </returns>
        public static bool IsPlateauSizeInputValid(this string pInput)
        {
            //2 inputs between 1-9 split with space
            return Regex.IsMatch(pInput, @"^\+?([1-9]) \+?([1-9])$");
        }

        /// <summary>
        /// Control the Rover Position input is valid
        /// </summary>
        /// <param name="pInput">input position value</param>
        /// <returns>true --> if valid / false --> if not valid </returns>
        public static bool IsRoverPositionInputValid(this string pInput)
        {
            //2 inputs between 1-9 split with space and one of N,W,S,E
            return Regex.IsMatch(pInput, @"^\+?([1-9]) \+?([1-9]) [NSWE]$");
        }

        /// <summary>
        /// Control the Rover Action Command input is valid
        /// </summary>
        /// <param name="pInput">input Action Command value</param>
        /// <returns>true --> if valid / false --> if not valid </returns>
        public static bool IsRoverActionCommandInputValid(this string pInput)
        {
            // inputs must be one of L,R,M, 
            return Regex.IsMatch(pInput, @"^[LRM]*$");
        }
    }
}
