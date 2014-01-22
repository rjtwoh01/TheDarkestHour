using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Areas
{
    class GeneralStore
    {
        public static void DoGeneralStore() 
        {
            Console.WriteLine("Welcome to the store, you can sell any of your goods here!");
            Console.WriteLine("Or if you're interested, we have some mighty fine goods to buy here!\n\n");

            bool goAgain = false;

            do
            {
                Console.WriteLine("Do you wish to (1) Sell Items or (2) Buy Items?");
                string answer = Console.ReadLine();
                if (answer == "1")
                    SellItems();
                else if (answer == "2")
                    BuyItems();

                Console.WriteLine("Do you still wish to utilize any of my services? (1) Yes (2) No");
                string answerTwo = Console.ReadLine();
                if (answerTwo == "1")
                    goAgain = true;
                else if (answerTwo == "2")
                    goAgain = false;
                else
                    goAgain = true;

            } while (goAgain);

            ClearScreen();
        }

        public static void SellItems()
        {
            bool goAgain = false;

            do
            {
                GameState.Hero.SellItems();
                ClearScreen();

                Console.WriteLine("Want to go again? (1) Yes (2) No");
                string answer = Console.ReadLine();
                if (answer == "1")
                    goAgain = true;
                else if (answer == "2")
                    goAgain = false;
                else
                    goAgain = true;

            } while (goAgain);

            ClearScreen();
        }

        public static void BuyItems()
        {
            bool goAgain = false;
            VendoredItems vendor = new VendoredItems();

            do
            {
                List<Item> itemsToBuy = new List<Item>();
                Item aWeapon = new Weapon();
                Item aArmor = new Armor();
                Item aHelmet = new Helmet();
                Item aAmulet = new Amulet();
                Item aPotion = new Potion();

                for (int counter = 0; counter < 4; counter++)
                {
                    if (GameState.Hero.level >= 1 && GameState.Hero.level <= 5)
                    {
                        aWeapon = vendor.LevelsOneToFiveGetWeapon();
                        aArmor = vendor.LevelsOneToFiveGetArmor();
                        aHelmet = vendor.LevelsOneToFiveGetHelmet();
                        aAmulet = vendor.LevelsOneToFiveGetAmulet();
                        aPotion = vendor.LevelsOneToFiveGetPotion();
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 6 && GameState.Hero.level <= 50)
                    {
                        aWeapon = vendor.LevelsSixToTenGetWeapon();
                        aArmor = vendor.LevelsSixToTenGetArmor();
                        aHelmet = vendor.LevelsSixToTenGetHelmet();
                        aAmulet = vendor.LevelsSixToTenGetAmulet();
                        aPotion = vendor.LevelsSixToTenGetPotion();
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                }

                int i = 1;
                foreach (Item displayItems in itemsToBuy)
                {
                    Console.WriteLine(i + ". " + displayItems);
                    i++;
                }

                Console.WriteLine("\nDo you want to buy any of these? (1) Yes, (2) No");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("Which item?");
                    string itemAnswer = Console.ReadLine();
                    int selected = Int32.Parse(itemAnswer);
                    selected -= 1;

                    Item selectedItem = itemsToBuy.ElementAt(selected);

                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap && GameState.Hero.gold >= selectedItem.worth)
                    {
                        GameState.Hero.Inventory.Add(selectedItem);
                        Console.WriteLine("You bought {0} for {1} gold and you now have {2} gold left.\n\n", selectedItem.name, selectedItem.worth, GameState.Hero.gold);
                    }
                    else if (GameState.Hero.Inventory.Count > GameState.Hero.inventoryCap)
                    {
                        Console.WriteLine("You have too many items in your inventory. Maybe you should sell something to me first.\n\n");
                    }
                    else if (GameState.Hero.gold < selectedItem.worth)
                    {
                        Console.WriteLine("You don't have enough money for that\n\n");
                    }
                    else if (GameState.Hero.Inventory.Count > GameState.Hero.inventoryCap && GameState.Hero.gold < selectedItem.worth)
                    {
                        Console.WriteLine("You have too many items in your inventory, and you don't have enough gold. Maybe you should sell something to me first.\n\n");
                    }
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Then why'd you ask to come here! I ain't going to have anything better you know!\n\n");
                }
                else
                {
                    Console.WriteLine("What you wasting my time for?");
                }


                Console.WriteLine("\n\nWant to buy something else? (1) Yes (2) No");
                string answerTwo = Console.ReadLine();
                if (answerTwo == "1")
                    goAgain = true;
                else if (answerTwo == "2")
                    goAgain = false;
                else
                    goAgain = true;

                ClearScreen();
            } while (goAgain);
            ClearScreen();
        }

        public static void ClearScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}