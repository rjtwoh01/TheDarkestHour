using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Areas;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Towns.StartingArea;

namespace The_Darkest_Hour
{
    class MainGame
    {
        public MainGame()
        {
            DisplayLocations();
        }

        public void DisplayLocations()
        {
            InitialGameMenu initialGameMenu = new InitialGameMenu();
            GameState.CurrentLocation = initialGameMenu.GetStartingLocation();


            GameState.CurrentLocation.Display();
            LocationAction locationAction = GameState.CurrentLocation.GetAction();

            while(!(locationAction is ExitGame))
            {
                GameState.CurrentLocation = locationAction.DoAction();

                GameState.CurrentLocation.Display();
                locationAction = GameState.CurrentLocation.GetAction();
            }
        }

        public void ClearScreen()
        {
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}