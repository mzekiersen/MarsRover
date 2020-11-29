using MarsRover.Models;
using System.Linq;

namespace MarsRover
{
    /// <summary>
    /// Plateau where Rover will stand
    /// </summary>
    public class Plateau : IPlateau
    {
        /// <summary>
        /// Plateau Size Information ( top rigth: WidthX, HeightY)
        /// </summary>
        public PlateauSize PlateauSize { get; set; }

        /// <summary>
        /// Initialize Plateau
        /// </summary>
        /// <param name="pSizeInput">Plateau's initial values from console</param>
        public void InitializePlateau(string pSizeInput)
        {
            var sizeList = pSizeInput.Split(' ').Select(i => int.Parse(i)).ToList();
            PlateauSize = new PlateauSize
            {
                WidthX = sizeList[0],
                HeigthY = sizeList[1]
            };
        }

        /// <summary>
        /// Control if given position is inside Plateau area
        /// </summary>
        /// <param name="pPosition">being controlled position info</param>
        /// <returns>true if inside / false if outside</returns>
        public bool PositionIsInsidePlataeu(Position pPosition)
        {
            return pPosition.PointX >= 0 && pPosition.PointX <= PlateauSize.WidthX && pPosition.PointY >= 0 && pPosition.PointY <= PlateauSize.HeigthY;
        }

    }
}
