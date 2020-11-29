using MarsRover.Models;

namespace MarsRover
{
    /// <summary>
    /// Mars Rover Object
    /// </summary>
    public class Rover : IRover
    {
        /// <summary>
        /// Rover's Active Position
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Rover's Active Direction
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Initialize Rover
        /// </summary>
        /// <param name="pPlateau">Plateau where Rover placed in</param>
        /// <param name="pRoverInput">Rover's initial values from console</param>
        /// <returns>True if Rover inside Plateau area / false --> outside</returns>
        public bool InitializeRover(IPlateau pPlateau, string pRoverInput)
        {
            var roverParams = pRoverInput.Split(' ');
            Position = new Position
            {
                PointX = int.Parse(roverParams[0]),
                PointY = int.Parse(roverParams[1])
            };
            Direction = roverParams[2];

            return pPlateau.PositionIsInsidePlataeu(Position);
        }

        /// <summary>
        /// Change Rover's Position and Direction after Execution Command Result
        /// </summary>
        /// <param name="pCommandResult">Calculated Command Result</param>
        public void ExecuteCommand(CommandResultModel pCommandResult)
        {
            Position = pCommandResult.Position;
            Direction = pCommandResult.Direction;
        }

        /// <summary>
        /// Console Output for Rover Position and Direction
        /// </summary>
        /// <returns>String information</returns>
        public override string ToString()
        {
           return string.Format("Rover Position : {0} {1} {2}", Position.PointX, Position.PointY, Direction);
        }
    }
}
