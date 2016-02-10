using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Areas
{
    class GeneralStore
    {
        public static void DoGeneralStore() 
        {
            Console.WriteLine("\nWelcome to the store, you can sell any of your goods here!");
            Console.WriteLine("Or if you're interested, we have some mighty fine goods to buy here!\n\n");

            bool goAgain = false;

            do
            {
                Console.WriteLine("Do you wish to (1) Sell Items, (2) Buy Items or (3) Sell All?");
                string answer = Console.ReadLine();
                if (answer == "1")
                    SellItems();
                else if (answer == "2")
                    BuyItems();
                else if (answer == "3")
                    SellAll();

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
                        aWeapon = vendor.GetWeapon("Slightly Broken", "Chipped", "Simple", 1, 6, 1, 6);
                        aArmor = vendor.GetArmor("Rusted", "Torn", "Patched", 1, 6, 1, 6);
                        aHelmet = vendor.GetHelmet("Rusted", "Torn", "Patched", 1, 6, 1, 6);
                        aAmulet = vendor.GetAmulet("Rusted", "Chipped", "Cracked", 1, 6, 1, 6);
                        aPotion = vendor.GetPotion("Old", 1, 11, 1, 251, 1, 11);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 6 && GameState.Hero.level <= 10)
                    {
                        aWeapon = vendor.GetWeapon("Worn", "Dull", "Old", 5, 16, 5, 11);
                        aArmor = vendor.GetArmor("Worn", "Dull", "Old", 5, 16, 5, 11);
                        aHelmet = vendor.GetHelmet("Worn", "Dull", "Old", 5, 16, 5, 11);
                        aAmulet = vendor.GetAmulet("Worn", "Dull", "Old", 5, 16, 5, 11);
                        aPotion = vendor.GetPotion("Dull", 5, 16, 100, 451, 5, 16);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 11 && GameState.Hero.level <= 15)
                    {
                        aWeapon = vendor.GetWeapon("New", "Curved", "Glossed", 10, 26, 11, 16);
                        aArmor = vendor.GetArmor("New", "Curved", "Glossed", 10, 26, 11, 16);
                        aHelmet = vendor.GetHelmet("New", "Curved", "Glossed", 10, 26, 11, 16);
                        aAmulet = vendor.GetAmulet("New", "Curved", "Glossed", 10, 26, 11, 16);
                        aPotion = vendor.GetPotion("New", 10, 26, 200, 551, 10, 26);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 16 && GameState.Hero.level <= 20)
                    {
                        aWeapon = vendor.GetWeapon("Stable", "Strong", "Sturdy", 20, 31, 16, 21);
                        aArmor = vendor.GetArmor("Stable", "Strong", "Sturdy", 20, 31, 16, 21);
                        aHelmet = vendor.GetHelmet("Stable", "Strong", "Sturdy", 20, 31, 16, 21);
                        aAmulet = vendor.GetAmulet("Stable", "Strong", "Sturdy", 20, 31, 16, 21);
                        aPotion = vendor.GetPotion("Strong", 20, 31, 200, 601, 20, 31);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 21 && GameState.Hero.level <= 25)
                    {
                        aWeapon = vendor.GetWeapon("Resolute", "Resiliant", "Polished", 25, 36, 21, 26);
                        aArmor = vendor.GetArmor("Resolute", "Resiliant", "Polished", 25, 36, 21, 26);
                        aHelmet = vendor.GetHelmet("Resolute", "Resiliant", "Polished", 25, 36, 21, 26);
                        aAmulet = vendor.GetAmulet("Resolute", "Resiliant", "Polished", 25, 36, 21, 26);
                        aPotion = vendor.GetPotion("Resiliant", 30, 41, 300, 651, 25, 36);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 26 && GameState.Hero.level <= 30)
                    {
                        aWeapon = vendor.GetWeapon("Blackened", "Cold", "Fire", 30, 41, 26, 31);
                        aArmor = vendor.GetArmor("Blackened", "Cold", "Fire", 30, 41, 26, 31);
                        aHelmet = vendor.GetHelmet("Blackened", "Cold", "Fire", 30, 41, 26, 31);
                        aAmulet = vendor.GetAmulet("Blackened", "Cold", "Fire", 30, 41, 26, 31);
                        aPotion = vendor.GetPotion("Cold", 100, 201, 400, 751, 30, 41);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 31 && GameState.Hero.level <= 35)
                    {
                        aWeapon = vendor.GetWeapon("Earth", "Warm", "Storm", 35, 56, 31, 36);
                        aArmor = vendor.GetArmor("Earth", "Warm", "Storm", 35, 56, 31, 36);
                        aHelmet = vendor.GetHelmet("Earth", "Warm", "Storm", 35, 56, 31, 36);
                        aAmulet = vendor.GetAmulet("Earth", "Warm", "Storm", 35, 56, 31, 36);
                        aPotion = vendor.GetPotion("Warm", 150, 301, 500, 851, 35, 56);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 36 && GameState.Hero.level <= 40)
                    {
                        aWeapon = vendor.GetWeapon("Jagged", "Cold", "Fire", 40, 76, 36, 41);
                        aArmor = vendor.GetArmor("Jagged", "Cold", "Fire", 40, 76, 36, 41);
                        aHelmet = vendor.GetHelmet("Jagged", "Cold", "Fire", 40, 76, 36, 41);
                        aAmulet = vendor.GetAmulet("Jagged", "Cold", "Fire", 40, 76, 36, 41);
                        aPotion = vendor.GetPotion("Cold", 200, 351, 550, 901, 40, 76);
                        itemsToBuy.Add(aWeapon);
                        itemsToBuy.Add(aArmor);
                        itemsToBuy.Add(aHelmet);
                        itemsToBuy.Add(aAmulet);
                        itemsToBuy.Add(aPotion);
                    }
                    if (GameState.Hero.level >= 41 && GameState.Hero.level <= 50)
                    {
                        aWeapon = vendor.GetWeapon("Champion's", "Honor", "Black Market", 45, 86, 41, 46);
                        aArmor = vendor.GetArmor("Champion's", "Honor", "Black Market", 45, 86, 41, 46);
                        aHelmet = vendor.GetHelmet("Champion's", "Honor", "Black Market", 45, 86, 41, 46);
                        aAmulet = vendor.GetAmulet("Champion's", "Honor", "Black Market", 45, 86, 41, 46);
                        aPotion = vendor.GetPotion("Honor", 250, 401, 600, 951, 45, 86);
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
                    if (selectedItem.itemType != "Potion")
                    {
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
                    else if (selectedItem.itemType == "Potion")
                    {
                        if (GameState.Hero.PotionBag.Count < GameState.Hero.potionBagCap && GameState.Hero.gold >= selectedItem.worth)
                        {
                            GameState.Hero.PotionBag.Add(selectedItem);
                            Console.WriteLine("You bought {0} for {1} gold and you now have {2} gold left.\n\n", selectedItem.name, selectedItem.worth, GameState.Hero.gold);
                        }
                        else if (GameState.Hero.PotionBag.Count > GameState.Hero.potionBagCap)
                        {
                            Console.WriteLine("You have too many items in your inventory. Maybe you should sell something to me first.\n\n");
                        }
                        else if (GameState.Hero.gold < selectedItem.worth)
                        {
                            Console.WriteLine("You don't have enough money for that\n\n");
                        }
                        else if (GameState.Hero.PotionBag.Count > GameState.Hero.potionBagCap && GameState.Hero.gold < selectedItem.worth)
                        {
                            Console.WriteLine("You have too many items in your inventory, and you don't have enough gold. Maybe you should sell something to me first.\n\n");
                        }
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

        public static void SellAll()
        {
            GameState.Hero.SellAll();
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