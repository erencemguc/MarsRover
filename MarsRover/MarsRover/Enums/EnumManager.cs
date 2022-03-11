using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Enums
{
    public class EnumManager
    {
        public static DirectionEnum FindDirectionEnum(string directionCharacter)
        {
            switch (directionCharacter)
            {
                case "N":
                    return DirectionEnum.N;
                case "E":
                    return DirectionEnum.E;
                case "S":
                    return DirectionEnum.S;
                case "W":
                    return DirectionEnum.W;
                default:
                    return DirectionEnum.N;
            }
        }


        public static CommandEnum FindCommandEnum(string command)
        {
            switch (command)
            {
                case "L":
                    return CommandEnum.L;
                case "M":
                    return CommandEnum.M;
                case "R":
                    return CommandEnum.R;
                default:
                    return CommandEnum.M;
            }
        }

        public static string GetDirectionName(DirectionEnum directionEnum)
        {
            switch (directionEnum)
            {
                case DirectionEnum.N:
                    return "N";
                case DirectionEnum.E:
                    return "E";
                case DirectionEnum.S:
                    return "S";
                case DirectionEnum.W:
                    return "W";
                default:
                    return "";
            }

        }
    }
}
