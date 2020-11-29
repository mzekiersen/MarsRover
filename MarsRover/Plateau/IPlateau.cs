using MarsRover.Models;

namespace MarsRover
{
    public interface IPlateau
    {
        PlateauSize PlateauSize { get; set; }

        void InitializePlateau(string pSizeInput);
         
        bool PositionIsInsidePlataeu(Position pPosition);
    }
}
