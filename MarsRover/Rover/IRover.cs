using MarsRover.Models;

namespace MarsRover
{
    public interface IRover
    {
        Position Position { get; set; }
        string Direction { get; set; }
        bool InitializeRover(IPlateau pPlateau, string pRoverInput);
        void ExecuteCommand(CommandResultModel pRoverCommandInput);
    }
}
