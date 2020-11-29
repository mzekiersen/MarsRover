namespace MarsRover.Models
{
    /// <summary>
    /// Rover position and Direction for execution command
    /// </summary>
    public class CommandResultModel
    {
        /// <summary>
        /// Position after command run
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Direction after command run
        /// </summary>
        public string Direction { get; set; }
    }
}
