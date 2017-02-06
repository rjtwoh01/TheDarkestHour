using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace The_Darkest_Hour
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int height = Console.LargestWindowHeight;
                //int width = Console.LargestWindowWidth;
                int height = 40;
                int width = 140;
                Console.SetWindowSize(width, height);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                int height = Console.LargestWindowHeight;
                int width = Console.LargestWindowWidth;
                Console.SetWindowSize(width, height);
                Debug.WriteLine(e);
                
            }
            Console.Title = GeneralGameResources.TitleAndVersion;
            MainGame mainGame = new MainGame();
            
            //Currently initializes window post run of game, couldn't figure out how to get them to run at the same time.
            //Demonstrates the program's ability to pull and show information in the top right.
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new The_Darkest_Hour.GUIForm.Console());
            
            
        }
    }
}