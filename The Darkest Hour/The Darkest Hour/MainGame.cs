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
        Player myHero;
        Mob mob;
        string userInput;
        Battle battle = new Battle();
        Skeleton skeleton;
        Bandit bandit;
        Random rand = new Random();
        int temp = 0;

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
                        myHero = LoadSave.LoadCharacter();
                    }
                }
            }

            // myHero should be null if not loaded from a saved file (or not loaded successfully);
            if (myHero == null)
            {
                myHero = new Player();
                myHero.Initialize();
            }

            GameState.Hero = myHero;
                        
            mob = new Mob();            

            Console.WriteLine(myHero.Identifier);
            myHero.DisplayProfession();
            Console.WriteLine("\n\nAnd your inventory is: \n");
            int i = 1;
            foreach (Item displayInventory in myHero.Inventory)
            {
                Console.WriteLine(i + ". " + displayInventory);
                i++;
            }
            Console.WriteLine();
            ClearScreen();

            DisplayLocations();

            return;

            do
            {
                skeleton = new Skeleton();
                bandit = new Bandit();
                Console.WriteLine("Do you want to go to the arena or quit the game?");
                Console.WriteLine("(1) Arena \n(2) Display your stats \n(3) Display Inventory \n(4) Sell Items \n(5) Save \n(6) Quit\n");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    temp = rand.Next(1, 3);
                    if (temp == 1)
                    {
                        Console.Clear();
                        battle.DoBattle(myHero, skeleton);
                        myHero.ResetHealth();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        battle.DoBattle(myHero, bandit);
                        myHero.ResetHealth();
                        Console.Clear();
                    }
                }
                else if (answer == "2")
                {
                    myHero.DisplayStats();
                    ClearScreen();
                }
                else if (answer == "3")
                {
                    myHero.DisplayInventory();
                    ClearScreen();
                }
                else if (answer == "4")
                {
                    GeneralStore.DoGeneralStore();
                }
                else if (answer == "5")
                {
                    LoadSave.SaveCharacter(myHero);
                    ClearScreen();
                }
                else if (answer == "6")
                {
                    userInput = "10";
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }while(userInput != "10");
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