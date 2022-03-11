using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5 5
            //1 2 N
            //LMLMLMLMM
            //3 3 E
            //MMRMMRMRRM

            //Console.WriteLine("Lütfen şu sırayla değerleri giriş yapınız:");
            Console.WriteLine("Marsın max koordinat değerlerini boşluk bırakarak X ve Y sırasıyla:");
            var Coordinates = Console.ReadLine().Split(' ');
            Console.WriteLine("İlk Rover ın durumunu giriniz:");
            var FirstRoverState = Console.ReadLine().Split(' ');
            Console.WriteLine("İlk Rover ın yapmasını istediğiniz hareket komutlarını:");
            var FirstRoverMove = Console.ReadLine();
            Console.WriteLine("İkinci Rover ın durumunu giriniz:");
            var SecondRoverState = Console.ReadLine().Split(' ');
            Console.WriteLine("İkinci Rover ın yapmasını istediğiniz hareket komutlarını:");
            var SecondRoverMove = Console.ReadLine();
            if (Coordinates.Length != 2 || FirstRoverState.Length != 3 || SecondRoverState.Length != 3
                || int.TryParse(Coordinates[0], out int o) == false || int.TryParse(Coordinates[1], out int u) == false
                 || int.TryParse(FirstRoverState[0], out int f0) == false || int.TryParse(FirstRoverState[1], out int f1) == false
                   || int.TryParse(SecondRoverState[0], out int s0) == false || int.TryParse(SecondRoverState[1], out int s1) == false)
            {
                Console.WriteLine("Yanlış Değer Girdiniz");
            }
            else
            {
            var Mars = new MarsModel() { MaxCoordinateX = Convert.ToInt32(Coordinates[0]), MaxCoordinateY = Convert.ToInt32(Coordinates[1]) };
            var FirstRover = new RoverModel(Convert.ToInt32(FirstRoverState[0]), Convert.ToInt32(FirstRoverState[1]), EnumManager.FindDirectionEnum(FirstRoverState[2]));
            FirstRover.Mars = Mars;
            var SecondRover = new RoverModel(Convert.ToInt32(SecondRoverState[0]), Convert.ToInt32(SecondRoverState[1]), EnumManager.FindDirectionEnum(SecondRoverState[2]));
            SecondRover.Mars = Mars;

            ExecuteStringCommand(FirstRover, FirstRoverMove);
            ExecuteStringCommand(SecondRover, SecondRoverMove);


            Console.WriteLine("İlk Rover:" + FirstRover.GetState());
            Console.WriteLine("İkinci Rover:" + SecondRover.GetState());

            }

            Console.ReadKey();
        }

        private static void ExecuteStringCommand(RoverModel rover, string command)
        {
            List<char> commands = new List<char>() { 'L', 'R', 'M' };

            for (int i = 0; i < command.Length; i++)
            {
                if (commands.Any(x => x.Equals(command[i])))
                    rover.ExeCommand(EnumManager.FindCommandEnum(command[i].ToString()));
            }

        }


    }
}
