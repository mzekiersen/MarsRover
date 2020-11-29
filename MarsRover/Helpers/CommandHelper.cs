using MarsRover.Models;
using System.Linq;

namespace MarsRover.Helpers
{
    /// <summary>
    /// Command Execution Helper
    /// </summary>
    public static class CommandHelper
    {
        /// <summary>
        /// Calculating Position after running Command List
        /// </summary>
        /// <param name="pRoverPosition">Rover's position</param>
        /// <param name="pDirection">Rover's Direction</param>
        /// <param name="pRoverCommandInput">Command List from console</param>
        /// <returns>Calculated Position and Direction by Rover's initial value</returns>
        public static CommandResultModel CalculateResult(Position pRoverPosition, string pDirection, string pRoverCommandInput)
        {
            var returnCommandResult = new CommandResultModel
            {
                Position = pRoverPosition,
                Direction = pDirection
            };

            var commandList = pRoverCommandInput.Select(i => new string(i, 1)).ToList();

            foreach (var command in commandList)
            {
                switch (command)
                {
                    case "L": // turn Left
                        returnCommandResult.TurnLeft();
                        break;
                    case "R": // turn right
                        returnCommandResult.TurnRight();
                        break;
                    case "M": // move forward
                        returnCommandResult.MoveForward();
                        break;
                }
            };
            return returnCommandResult;
        }

        /// <summary>
        /// Turn Left by Direction
        /// </summary>
        /// <param name="pCommandResult">value to be changed</param>
        private static void TurnLeft(this CommandResultModel pCommandResult)
        {
            switch (pCommandResult.Direction)
            {
                case "N":
                    pCommandResult.Direction = "W";
                    break;
                case "W":
                    pCommandResult.Direction = "S";
                    break;
                case "S":
                    pCommandResult.Direction = "E";
                    break;
                case "E":
                    pCommandResult.Direction = "N";
                    break;
            }
        }

        /// <summary>
        /// Turn Right by Direction
        /// </summary>
        /// <param name="pCommandResult">value to be changed</param>
        private static void TurnRight(this CommandResultModel pCommandResult)
        {
            switch (pCommandResult.Direction)
            {
                case "N":
                    pCommandResult.Direction = "E";
                    break;
                case "W":
                    pCommandResult.Direction = "N";
                    break;
                case "S":
                    pCommandResult.Direction = "W";
                    break;
                case "E":
                    pCommandResult.Direction = "S";
                    break;
            }
        }

        /// <summary>
        /// Move by Direction & Position
        /// </summary>
        /// <param name="pCommandResult">value to be changed</param>
        private static void MoveForward(this CommandResultModel pCommandResult)
        {
            switch (pCommandResult.Direction)
            {
                case "N":
                    pCommandResult.Position.PointY++;
                    break;
                case "W":
                    pCommandResult.Position.PointX--;
                    break;
                case "S":
                    pCommandResult.Position.PointY--;
                    break;
                case "E":
                    pCommandResult.Position.PointX++;
                    break;
            }
        }
    }
}
