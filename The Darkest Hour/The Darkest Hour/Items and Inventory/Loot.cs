using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Items_and_Inventory
{
    public class Loot
    {
        int damage, strength, agility, intelligence, health, requiredLevel, temp, temp2, armor, healAmount, energyIncreased, worth;
        double goldFind, magicFind, critChance, critDamage;
        string itemType, itemName;
        bool isFull;
        Random rand;
        public Loot(Player myHero, Mob mob)
        {
            if (mob.level >= 1 && mob.level <= 5)
            {
                LevelsOneToFiveLoot(myHero);
            }
        }

        public void LevelsOneToFiveLoot(Player myHero)
        {
            rand = new Random();
            temp = rand.Next(1, 7);
            switch (temp)
            {
                case 1:
                    LevelsOneToFiveGetWeapon(myHero);
                    break;
                case 2:
                    LevelsOneToFiveGetArmor(myHero);
                    break;
                case 3:
                    LevelsOneToFiveGetHelmet(myHero);
                    break;
                case 4:
                    LevelsOneToFiveGetAmulet(myHero);
                    break;
                case 5:
                    LevelsOneToFiveGetPotion(myHero);
                    break;
                default:
                    break;
            }
        }

        public void LevelsOneToFiveGetWeapon(Player myHero)
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Slightly Broken Sword");
            SwordNames.Add("Rusty Sword");
            SwordNames.Add("Chipped Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Slightly Broken Bow");
            BowNames.Add("Chipped Bow");
            BowNames.Add("Simple Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Slightly Broken Staff");
            StaffNames.Add("Chipped Staff");
            StaffNames.Add("Simple Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Slightly Broken Wand");
            WandNames.Add("Chipped Wand");
            WandNames.Add("Simple Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Slightly Broken Axe");
            AxeNames.Add("Rusty Axe");
            AxeNames.Add("Chipped Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Slightly Broken Dagger");
            DaggerNames.Add("Rusty Dagger");
            DaggerNames.Add("Chipped Dagger");

            temp = rand.Next(1, 7);
            temp2 = rand.Next(1, 4);

            switch (temp)
            {
                case 1:
                    itemType = "Sword";
                    switch (temp2)
                    {
                        case 1:
                            itemName = SwordNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = SwordNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = SwordNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                case 2:
                    itemType = "Bow";
                    switch (temp2)
                    {
                        case 1:
                            itemName = BowNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = BowNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = BowNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                case 3:
                    itemType = "Staff";
                    switch (temp2)
                    {
                        case 1:
                            itemName = StaffNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = StaffNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = StaffNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                case 4:
                    itemType = "Wand";
                    switch (temp2)
                    {
                        case 1:
                            itemName = WandNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = WandNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = WandNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                case 5:
                    itemType = "Dagger";
                    switch (temp2)
                    {
                        case 1:
                            itemName = DaggerNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = DaggerNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = DaggerNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                case 6:
                    itemType = "Axe";
                    switch (temp2)
                    {
                        case 1:
                            itemName = AxeNames.ElementAt(0);
                            break;
                        case 2:
                            itemName = AxeNames.ElementAt(1);
                            break;
                        case 3:
                            itemName = AxeNames.ElementAt(2);
                            break;
                        default:
                            Console.WriteLine("\nUh Oh, something went wrong.\n");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }

            damage = rand.Next(1, 11);
            strength = rand.Next(0, 11);
            agility = rand.Next(0, 11);
            intelligence = rand.Next(0, 11);
            health = rand.Next(0, 11);
            requiredLevel = rand.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = rand.Next(1, 11);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (myHero.Inventory.Count < myHero.inventoryCap)
                        myHero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsOneToFiveGetArmor(Player myHero)
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Rusted Chainmail");
            ArmorNames.Add("Torn Leather Armor");
            ArmorNames.Add("Patched Robes");


            temp = rand.Next(1, 4);

            switch (temp)
            {
                case 1:
                    itemName = ArmorNames.ElementAt(0);
                    itemType = "Mail";
                    break;
                case 2:
                    itemName = ArmorNames.ElementAt(1);
                    itemType = "Leather";
                    break;
                case 3:
                    itemName = ArmorNames.ElementAt(2);
                    itemType = "Cloth";
                    break;
                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }

            

            armor = rand.Next(1, 11);
            strength = rand.Next(0, 11);
            agility = rand.Next(0, 11);
            intelligence = rand.Next(0, 11);
            health = rand.Next(0, 11);
            requiredLevel = rand.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = rand.Next(1, 11);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (myHero.Inventory.Count < myHero.inventoryCap)
                myHero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetHelmet(Player myHero)
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Rusted Helmet");
            HelmetNames.Add("Torn Helmet");
            HelmetNames.Add("Patched Hat");


            temp = rand.Next(1, 4);

            switch (temp)
            {
                case 1:
                    itemName = HelmetNames.ElementAt(0);
                    itemType = "Mail";
                    break;
                case 2:
                    itemName = HelmetNames.ElementAt(1);
                    itemType = "Leather";
                    break;
                case 3:
                    itemName = HelmetNames.ElementAt(2);
                    itemType = "Cloth";
                    break;
                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }


            armor = rand.Next(1, 11);
            strength = rand.Next(0, 11);
            agility = rand.Next(0, 11);
            intelligence = rand.Next(0, 11);
            health = rand.Next(0, 11);
            requiredLevel = rand.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = rand.Next(1, 11);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (myHero.Inventory.Count < myHero.inventoryCap)
                myHero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetAmulet(Player myHero)
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Chipped Amulet");
            AmuletNames.Add("Cracked Amulet");
            AmuletNames.Add("Rusted Amulet");


            temp = rand.Next(1, 4);

            switch (temp)
            {
                case 1:
                    itemName = AmuletNames.ElementAt(0);
                    break;
                case 2:
                    itemName = AmuletNames.ElementAt(1);
                    break;
                case 3:
                    itemName = AmuletNames.ElementAt(2);
                    break;
                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }

            itemType = "Amulet";

            armor = rand.Next(1, 11);
            strength = rand.Next(0, 11);
            agility = rand.Next(0, 11);
            intelligence = rand.Next(0, 11);
            health = rand.Next(0, 11);
            requiredLevel = rand.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = rand.Next(1, 11);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (myHero.Inventory.Count < myHero.inventoryCap)
                myHero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetPotion(Player myHero)
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Old Potion";

            itemType = "Potion";

            healAmount = rand.Next(1, 11);
            energyIncreased = rand.Next(1, 251);
            requiredLevel = 1;
            worth = rand.Next(1, 11);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (myHero.Inventory.Count < myHero.inventoryCap)
                myHero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }
    }
}