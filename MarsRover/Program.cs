using MarsRover.Helpers;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        { 
            var plateau = new Plateau();

            //Inserting Plateau Size
            Console.WriteLine("Insert Plateau Size:");
            var plateauSize = Console.ReadLine();
            //Plateau Size Input Validation Control
            while (!plateauSize.IsPlateauSizeInputValid())
            {
                Console.WriteLine("Incorrect Plateau Size! Please insert two parameter between 1-9:");
                plateauSize = Console.ReadLine();
            }
            //Creating Plataeu
            plateau.InitializePlateau(plateauSize);

            //Taking rover and action informations
            var inputParameter = "";
            while (inputParameter != "EXIT")
            {
                var rover = new Rover();

                inputParameter = "";
                //Inserting Rover Position
                Console.WriteLine("Insert Rover Position:");
                var roverPosition = Console.ReadLine().ToUpper();
                roverPosition = !string.IsNullOrEmpty(roverPosition) ? roverPosition.ToUpper() : roverPosition;

                //Rover Position Input & Inside Plateua Validation Control
                while (!roverPosition.IsRoverPositionInputValid() || !rover.InitializeRover(plateau, roverPosition))
                {
                    Console.WriteLine("Incorrect Rover Position! Please insert first parameter 0 to "+ plateau.PlateauSize.WidthX + ", second parameter 0 to "+ plateau.PlateauSize.HeigthY + " and last parameter one of N,S,W,E");
                        
                    roverPosition = Console.ReadLine();
                    roverPosition = !string.IsNullOrEmpty(roverPosition) ? roverPosition.ToUpper() : roverPosition;                     
                }

                //Inserting Rover Position
                Console.WriteLine("Insert Rover Action Commands:");
                var roverActionCommand = Console.ReadLine();
                //Rover Action Command Input Validation Control
                while (!roverActionCommand.IsRoverActionCommandInputValid())
                {
                    Console.WriteLine("Incorrect Rover Action Command! Please insert command string use only L,R,M characters.");
                    roverActionCommand = Console.ReadLine();
                    roverActionCommand = !string.IsNullOrEmpty(roverActionCommand) ? roverActionCommand.ToUpper() : roverActionCommand;
                }

                //Calculate position after commands execute
                var commandResultByRover = CommandHelper.CalculateResult(rover.Position, rover.Direction, roverActionCommand);

                // Calculated position is inside plateua, apply command to rover, else cancel command
                if (plateau.PositionIsInsidePlataeu(commandResultByRover.Position))
                {
                    rover.ExecuteCommand(commandResultByRover);
                }
                else
                {
                    Console.WriteLine("Rover position after executing command is out of Plateau borders. Command has been cancelled.");
                }
                
                //write final position and direction
                Console.WriteLine(rover.ToString()+Environment.NewLine + Environment.NewLine);
               
                //Create New Rover & Action or Exit
                while (inputParameter != "EXIT" && inputParameter != "NEW")
                {
                    Console.WriteLine("For quit insert 'EXIT'");
                    Console.WriteLine("Create new rover write 'NEW'");
                    inputParameter = Console.ReadLine();
                    inputParameter = !string.IsNullOrEmpty(inputParameter) ? inputParameter.ToUpper() : inputParameter;
                }

            }
        }
    }
}
