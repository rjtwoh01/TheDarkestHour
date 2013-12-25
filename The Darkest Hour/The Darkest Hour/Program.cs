using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 54);
            Console.Title = GeneralGameResources.TitleAndVersion;
            MainGame game = new MainGame();
        }
    }
}