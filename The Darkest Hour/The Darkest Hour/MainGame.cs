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

namespace The_Darkest_Hour
{
    class MainGame
    {
        public MainGame()
        {
            if (LoadSave.SavedGameExists())
            {
                // TODO: Later, save characters to individual files
                // and present a list of characters to load and pick from those.
                Console.WriteLine("Do you want to load a previously saved character?");
                Console.WriteLine("(Y)es \n(N)o\n");
                string loadAnswer = Console.ReadLine();
                // Pretty much any answer that begins with Y will be accepted as yes.
                // everything else is treated as a No.
                // This design allows for mistakes but in this case it's no big deal if you load
                // from a saved file.
                // In other situations you may want to be more strigent to checking 100% accuracy of the input.
                if ((loadAnswer != null) && (loadAnswer.Length > 0))
                {
                    if (loadAnswer.ToUpper()[0] == 'Y')
                    {
                        GameState.Hero = LoadSave.LoadCharacter();
                    }
                }
            }

            // myHero should be null if not loaded from a saved file (or not loaded successfully);
            if (GameState.Hero == null)
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
            GameState.CurrentLocation = GetStartLocation();

            GameState.CurrentLocation.Display();
            LocationAction locationAction = GameState.CurrentLocation.GetAction();

            while(!(locationAction is ExitGame))
            {
                GameState.CurrentLocation = locationAction.DoAction();

                GameState.CurrentLocation.Display();
                locationAction = GameState.CurrentLocation.GetAction();
            }
        }

        public Location GetStartLocation()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Town Center";
            returnData.Description = "Do you want to go to the arena or quit the game?";

            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction = new ArenaAction();
            locationActions.Add(locationAction);

            locationAction = new DisplayStatsAction();
            locationActions.Add(locationAction);

            locationAction = new DisplayInventoryAction();
            locationActions.Add(locationAction);

            locationAction = new SellItemsAction();
            locationActions.Add(locationAction);

            locationAction = new SaveAction();
            locationActions.Add(locationAction);

            locationAction = new ExitGame();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            return returnData;
        }

        public void ClearScreen()
        {
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}