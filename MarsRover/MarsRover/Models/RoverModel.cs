using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class RoverModel
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public DirectionEnum Direction { get; set; }

        public MarsModel Mars { get; set; }
        public bool IsLost { get; set; }


        public RoverModel(int coordinateX, int coordinateY, DirectionEnum direction)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.Direction = direction;
        }
        public void ExeCommand(CommandEnum command)
        {
            //Eğer uzayda kaybolduysak birdaha konumumuzu bulamayız
            if (this.IsLost)
                return;

            if (command != CommandEnum.M)
            {
                int newDirection = command == CommandEnum.L ? ((int)this.Direction - 1) : ((int)this.Direction + 1);

                if (newDirection < 0)
                {
                    this.Direction = DirectionEnum.W;
                }
                else if (newDirection > 3)
                {
                    this.Direction = DirectionEnum.N;
                }
                else
                {
                    this.Direction = (DirectionEnum)newDirection;
                }
            }
            else
            {
                //Switch den önce new x ve y tanımlanır switch den sonra ızgara validasyonu tanımlanır.
                int newCoordinateX = CoordinateX;
                int newCoordinateY = CoordinateY;
                switch (this.Direction)
                {
                    case DirectionEnum.N:
                        newCoordinateY++;
                        break;
                    case DirectionEnum.E:
                        newCoordinateX++;
                        break;
                    case DirectionEnum.S:
                        newCoordinateY--;
                        break;
                    case DirectionEnum.W:
                        newCoordinateX--;
                        break;
                    default:
                        break;
                }

                IsLost = this.Mars.MaxCoordinateX < newCoordinateX || this.Mars.MaxCoordinateY < newCoordinateY;

                CoordinateX = newCoordinateX;
                CoordinateY = newCoordinateY;

            }
        }

        public string GetState()
        {
            return $"{CoordinateX} {CoordinateY} {EnumManager.GetDirectionName(Direction)}";
        }

    }
}
