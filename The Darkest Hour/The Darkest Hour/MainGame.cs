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
using The_Darkest_Hour.Towns.Watertown;

namespace The_Darkest_Hour
{
    class MainGame
    {
        public MainGame()
        {
            if (LoadSave.CheckForLoadSavedGame() == false)
            {
                GameState.Hero = new Player();
                GameState.Hero.Initialize();
            }

            Console.WriteLine(GameState.Hero.Identifier);
            GameState.Hero.DisplayProfession();
            Console.WriteLine("\n\nAnd your inventory is: \n");
            int i = 1;
            foreach (Item displayInventory in GameState.Hero.Inventory)
            {
                Console.WriteLine(i + ". " + displayInventory);
                i++;
            }
            Console.WriteLine();
            ClearScreen();

            DisplayLocations();
        }

        public void DisplayLocations()
        {
            Watertown watertown = new Watertown();
            GameState.CurrentLocation = watertown.GetStartingLocation();

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