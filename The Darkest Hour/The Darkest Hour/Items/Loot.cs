﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Items
{
    public class Loot
    {
        int damage, strength, agility, intelligence, health, requiredLevel, temp, temp2, armor, healAmount, energyIncreased, worth;
        double goldFind, magicFind, critChance, critDamage;
        string itemType, itemName;
        Random rand = new Random();

        public Loot()
        {
        }

        public void SelectLoot()
        {
            if (GameState.Hero.level >= 1 && GameState.Hero.level <= 5)
            {
                LevelsOneToFiveLoot();
            }
            if (GameState.Hero.level >= 6 && GameState.Hero.level <= 10)
            {
                LevelsSixToTenLoot();
            }
            if (GameState.Hero.level >= 11 && GameState.Hero.level <= 50)
            {
                LevelsElevenToFifteenLoot();
            }
        }

        public Loot(Mob mob)
        {
            if (mob.level >= 1 && mob.level <= 5)
            {
                LevelsOneToFiveLoot();
            }
            if (mob.level >= 6 && mob.level <= 10)
            {
                LevelsSixToTenLoot();
            }
            if (mob.level >= 11 && mob.level <= 15)
            {
                LevelsElevenToFifteenLoot();
            }
            if (mob.level >= 16 && mob.level <= 20)
            {
                LevelsSixteenToTwentyLoot();
            }
            if (mob.level >= 21 && mob.level <= 50)
            {
                LevelsTwentyOneToTwentyFiveLoot();
            }
        }

        public void LevelsOneToFiveLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsOneToFiveGetWeapon();
                    break;
                case 2:
                    LevelsOneToFiveGetArmor();
                    break;
                case 3:
                    LevelsOneToFiveGetHelmet();
                    break;
                case 4:
                    LevelsOneToFiveGetAmulet();
                    break;
                case 5:
                    LevelsOneToFiveGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsSixToTenLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsSixToTenGetWeapon();
                    break;
                case 2:
                    LevelsSixToTenGetArmor();
                    break;
                case 3:
                    LevelsSixToTenGetHelmet();
                    break;
                case 4:
                    LevelsSixToTenGetAmulet();
                    break;
                case 5:
                    LevelsSixToTenGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsElevenToFifteenLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsElevenToFifteenGetWeapon();
                    break;
                case 2:
                    LevelsElevenToFifteenGetArmor();
                    break;
                case 3:
                    LevelsElevenToFifteenGetHelmet();
                    break;
                case 4:
                    LevelsElevenToFifteenGetAmulet();
                    break;
                case 5:
                    LevelsElevenToFifteenGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsSixteenToTwentyLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsSixteenToTwentyGetWeapon();
                    break;
                case 2:
                    LevelsSixteenToTwentyGetArmor();
                    break;
                case 3:
                    LevelsSixteenToTwentyGetHelmet();
                    break;
                case 4:
                    LevelsSixteenToTwentyGetAmulet();
                    break;
                case 5:
                    LevelsSixteenToTwentyGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsTwentyOneToTwentyFiveLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsTwentyOneToTwenyFiveGetWeapon();
                    break;
                case 2:
                    LevelsTwentyOneToTwenyFiveGetArmor();
                    break;
                case 3:
                    LevelsTwentyOneToTwenyFiveGetHelmet();
                    break;
                case 4:
                    LevelsTwentyOneToTwenyFiveGetAmulet();
                    break;
                case 5:
                    LevelsTwentyOneToTwenyFiveGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsOneToFiveGetWeapon()
        {

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

            temp = GameState.NumberGenerator.Next(1, 7);
            temp2 = GameState.NumberGenerator.Next(1, 4);

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

            damage = GameState.NumberGenerator.Next(0, 11);
            strength = GameState.NumberGenerator.Next(0, 11);
            agility = GameState.NumberGenerator.Next(0, 11);
            intelligence = GameState.NumberGenerator.Next(0, 11);
            health = GameState.NumberGenerator.Next(0, 11);
            requiredLevel = GameState.NumberGenerator.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 11);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsOneToFiveGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Rusted Chainmail");
            ArmorNames.Add("Torn Leather Armor");
            ArmorNames.Add("Patched Robes");


            temp = GameState.NumberGenerator.Next(1, 4);

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



            armor = GameState.NumberGenerator.Next(0, 11);
            strength = GameState.NumberGenerator.Next(0, 11);
            agility = GameState.NumberGenerator.Next(0, 11);
            intelligence = GameState.NumberGenerator.Next(0, 11);
            health = GameState.NumberGenerator.Next(0, 11);
            requiredLevel = GameState.NumberGenerator.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 11);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Rusted Helmet");
            HelmetNames.Add("Torn Helmet");
            HelmetNames.Add("Patched Hat");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(0, 11);
            strength = GameState.NumberGenerator.Next(0, 11);
            agility = GameState.NumberGenerator.Next(0, 11);
            intelligence = GameState.NumberGenerator.Next(0, 11);
            health = GameState.NumberGenerator.Next(0, 11);
            requiredLevel = GameState.NumberGenerator.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 11);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Chipped Amulet");
            AmuletNames.Add("Cracked Amulet");
            AmuletNames.Add("Rusted Amulet");


            temp = GameState.NumberGenerator.Next(1, 4);

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

            armor = GameState.NumberGenerator.Next(0, 11);
            strength = GameState.NumberGenerator.Next(0, 11);
            agility = GameState.NumberGenerator.Next(0, 11);
            intelligence = GameState.NumberGenerator.Next(0, 11);
            health = GameState.NumberGenerator.Next(0, 11);
            requiredLevel = GameState.NumberGenerator.Next(1, 6);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 11);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsOneToFiveGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Old Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(1, 11);
            energyIncreased = GameState.NumberGenerator.Next(1, 251);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(1, 11);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixToTenGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Worn Sword");
            SwordNames.Add("Dull Sword");
            SwordNames.Add("Old Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Worn Bow");
            BowNames.Add("Dull Bow");
            BowNames.Add("Old Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Worn Staff");
            StaffNames.Add("Dull Staff");
            StaffNames.Add("Old Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Worn Wand");
            WandNames.Add("Dull Wand");
            WandNames.Add("Old Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Worn Axe");
            AxeNames.Add("Dull Axe");
            AxeNames.Add("Old Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Worn Dagger");
            DaggerNames.Add("Dull Dagger");
            DaggerNames.Add("Old Dagger");

            temp = GameState.NumberGenerator.Next(1, 7);
            temp2 = GameState.NumberGenerator.Next(1, 4);

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

            damage = GameState.NumberGenerator.Next(5, 16);
            strength = GameState.NumberGenerator.Next(0, 16);
            agility = GameState.NumberGenerator.Next(0, 16);
            intelligence = GameState.NumberGenerator.Next(0, 16);
            health = GameState.NumberGenerator.Next(0, 16);
            requiredLevel = GameState.NumberGenerator.Next(1, 11);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(5, 16);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsSixToTenGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Dull Chainmail");
            ArmorNames.Add("Worn Leather Armor");
            ArmorNames.Add("Old Robes");


            temp = GameState.NumberGenerator.Next(1, 4);

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



            armor = GameState.NumberGenerator.Next(5, 16);
            strength = GameState.NumberGenerator.Next(0, 16);
            agility = GameState.NumberGenerator.Next(0, 16);
            intelligence = GameState.NumberGenerator.Next(0, 16);
            health = GameState.NumberGenerator.Next(0, 16);
            requiredLevel = GameState.NumberGenerator.Next(5, 11);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 16);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixToTenGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Worn Helmet");
            HelmetNames.Add("Dull Helmet");
            HelmetNames.Add("Old Hat");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(5, 16);
            strength = GameState.NumberGenerator.Next(0, 16);
            agility = GameState.NumberGenerator.Next(0, 16);
            intelligence = GameState.NumberGenerator.Next(0, 16);
            health = GameState.NumberGenerator.Next(0, 16);
            requiredLevel = GameState.NumberGenerator.Next(5, 11);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 11);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixToTenGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Worn Amulet");
            AmuletNames.Add("Dull Amulet");
            AmuletNames.Add("Old Amulet");


            temp = GameState.NumberGenerator.Next(1, 4);

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

            armor = GameState.NumberGenerator.Next(5, 16);
            strength = GameState.NumberGenerator.Next(0, 16);
            agility = GameState.NumberGenerator.Next(0, 16);
            intelligence = GameState.NumberGenerator.Next(0, 16);
            health = GameState.NumberGenerator.Next(0, 16);
            requiredLevel = GameState.NumberGenerator.Next(5, 11);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(1, 16);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixToTenGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(5, 16);
            energyIncreased = GameState.NumberGenerator.Next(100, 451);
            requiredLevel = 5;
            worth = GameState.NumberGenerator.Next(1, 16);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsElevenToFifteenGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Worn Sword");
            SwordNames.Add("Dull Sword");
            SwordNames.Add("Old Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Worn Bow");
            BowNames.Add("Dull Bow");
            BowNames.Add("Old Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Worn Staff");
            StaffNames.Add("Dull Staff");
            StaffNames.Add("Old Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Worn Wand");
            WandNames.Add("Dull Wand");
            WandNames.Add("Old Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Worn Axe");
            AxeNames.Add("Dull Axe");
            AxeNames.Add("Old Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Worn Dagger");
            DaggerNames.Add("Dull Dagger");
            DaggerNames.Add("Old Dagger");

            temp = GameState.NumberGenerator.Next(1, 7);
            temp2 = GameState.NumberGenerator.Next(1, 4);

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

            damage = GameState.NumberGenerator.Next(10, 26);
            strength = GameState.NumberGenerator.Next(0, 26);
            agility = GameState.NumberGenerator.Next(0, 26);
            intelligence = GameState.NumberGenerator.Next(0, 26);
            health = GameState.NumberGenerator.Next(0, 26);
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(10, 26);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsElevenToFifteenGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Dull Chainmail");
            ArmorNames.Add("Worn Leather Armor");
            ArmorNames.Add("Old Robes");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(10, 26);
            strength = GameState.NumberGenerator.Next(0, 26);
            agility = GameState.NumberGenerator.Next(0, 26);
            intelligence = GameState.NumberGenerator.Next(0, 26);
            health = GameState.NumberGenerator.Next(0, 26);
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(10, 26);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsElevenToFifteenGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Worn Helmet");
            HelmetNames.Add("Dull Helmet");
            HelmetNames.Add("Old Hat");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(10, 26);
            strength = GameState.NumberGenerator.Next(0, 26);
            agility = GameState.NumberGenerator.Next(0, 26);
            intelligence = GameState.NumberGenerator.Next(0, 26);
            health = GameState.NumberGenerator.Next(0, 26);
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(10, 26);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsElevenToFifteenGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Worn Amulet");
            AmuletNames.Add("Dull Amulet");
            AmuletNames.Add("Old Amulet");


            temp = GameState.NumberGenerator.Next(1, 4);

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

            armor = GameState.NumberGenerator.Next(10, 26);
            strength = GameState.NumberGenerator.Next(0, 26);
            agility = GameState.NumberGenerator.Next(0, 26);
            intelligence = GameState.NumberGenerator.Next(0, 26);
            health = GameState.NumberGenerator.Next(0, 26);
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(10, 26);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsElevenToFifteenGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(10, 26);
            energyIncreased = GameState.NumberGenerator.Next(200, 551);
            requiredLevel = 5;
            worth = GameState.NumberGenerator.Next(10, 26);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixteenToTwentyGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Stable Sword");
            SwordNames.Add("Strong Sword");
            SwordNames.Add("New Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Stable Bow");
            BowNames.Add("Strong Bow");
            BowNames.Add("New Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Stable Staff");
            StaffNames.Add("Strong Staff");
            StaffNames.Add("New Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Stable Wand");
            WandNames.Add("Strong Wand");
            WandNames.Add("New Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Stable Axe");
            AxeNames.Add("Strong Axe");
            AxeNames.Add("New Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Stable Dagger");
            DaggerNames.Add("Strong Dagger");
            DaggerNames.Add("New Dagger");

            temp = GameState.NumberGenerator.Next(1, 7);
            temp2 = GameState.NumberGenerator.Next(1, 4);

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

            damage = GameState.NumberGenerator.Next(20, 31);
            strength = GameState.NumberGenerator.Next(0, 31);
            agility = GameState.NumberGenerator.Next(0, 31);
            intelligence = GameState.NumberGenerator.Next(0, 31);
            health = GameState.NumberGenerator.Next(0, 31);
            requiredLevel = GameState.NumberGenerator.Next(16, 21);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsSixteenToTwentyGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Strong Chainmail");
            ArmorNames.Add("Stable Leather Armor");
            ArmorNames.Add("New Robes");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(20, 31);
            strength = GameState.NumberGenerator.Next(0, 31);
            agility = GameState.NumberGenerator.Next(0, 31);
            intelligence = GameState.NumberGenerator.Next(0, 31);
            health = GameState.NumberGenerator.Next(0, 31);
            requiredLevel = GameState.NumberGenerator.Next(16, 21);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixteenToTwentyGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Stable Helmet");
            HelmetNames.Add("Strong Helmet");
            HelmetNames.Add("New Hat");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(20, 31);
            strength = GameState.NumberGenerator.Next(0, 31);
            agility = GameState.NumberGenerator.Next(0, 31);
            intelligence = GameState.NumberGenerator.Next(0, 31);
            health = GameState.NumberGenerator.Next(0, 31);
            requiredLevel = GameState.NumberGenerator.Next(16, 21);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixteenToTwentyGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Stable Amulet");
            AmuletNames.Add("Strong Amulet");
            AmuletNames.Add("New Amulet");


            temp = GameState.NumberGenerator.Next(1, 4);

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

            armor = GameState.NumberGenerator.Next(20, 31);
            strength = GameState.NumberGenerator.Next(0, 31);
            agility = GameState.NumberGenerator.Next(0, 31);
            intelligence = GameState.NumberGenerator.Next(0, 31);
            health = GameState.NumberGenerator.Next(0, 31);
            requiredLevel = GameState.NumberGenerator.Next(16, 21);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsSixteenToTwentyGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Strong Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(20, 31);
            energyIncreased = GameState.NumberGenerator.Next(250, 601);
            requiredLevel = 16;
            worth = GameState.NumberGenerator.Next(20, 31);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentyOneToTwenyFiveGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Resolute Sword");
            SwordNames.Add("Resilient Sword");
            SwordNames.Add("Polished Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Resolute Bow");
            BowNames.Add("Resilient Bow");
            BowNames.Add("Polished Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Resolute Staff");
            StaffNames.Add("Resilient Staff");
            StaffNames.Add("Polished Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Resolute Wand");
            WandNames.Add("Resilient Wand");
            WandNames.Add("Polished Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Resolute Axe");
            AxeNames.Add("Resilient Axe");
            AxeNames.Add("Polished Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Resolute Dagger");
            DaggerNames.Add("Resilient Dagger");
            DaggerNames.Add("Polished Dagger");

            temp = GameState.NumberGenerator.Next(1, 7);
            temp2 = GameState.NumberGenerator.Next(1, 4);

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

            damage = GameState.NumberGenerator.Next(25, 36);
            strength = GameState.NumberGenerator.Next(0, 36);
            agility = GameState.NumberGenerator.Next(0, 36);
            intelligence = GameState.NumberGenerator.Next(0, 36);
            health = GameState.NumberGenerator.Next(0, 36);
            requiredLevel = GameState.NumberGenerator.Next(21, 26);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            switch (itemType)
            {
                case "Sword":
                    aSword = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aSword);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Bow":
                    aBow = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aBow);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Staff":
                    aStaff = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aStaff);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Wand":
                    aWand = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aWand);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Dagger":
                    aDagger = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aDagger);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                case "Axe":
                    aAxe = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
                    Console.WriteLine("You loot {0}", itemName);
                    if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                        GameState.Hero.Inventory.Add(aAxe);
                    else
                        Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
                    break;

                default:
                    Console.WriteLine("\nUh Oh, something went wrong.\n");
                    break;
            }
        }

        public void LevelsTwentyOneToTwenyFiveGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Resilient Chainmail");
            ArmorNames.Add("Resolute Leather Armor");
            ArmorNames.Add("Polished Robes");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(25, 36);
            strength = GameState.NumberGenerator.Next(0, 36);
            agility = GameState.NumberGenerator.Next(0, 36);
            intelligence = GameState.NumberGenerator.Next(0, 36);
            health = GameState.NumberGenerator.Next(0, 36);
            requiredLevel = GameState.NumberGenerator.Next(21, 26);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentyOneToTwenyFiveGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Resolute Helmet");
            HelmetNames.Add("Resilient Helmet");
            HelmetNames.Add("Polished Hat");


            temp = GameState.NumberGenerator.Next(1, 4);

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


            armor = GameState.NumberGenerator.Next(25, 36);
            strength = GameState.NumberGenerator.Next(0, 36);
            agility = GameState.NumberGenerator.Next(0, 36);
            intelligence = GameState.NumberGenerator.Next(0, 36);
            health = GameState.NumberGenerator.Next(0, 36);
            requiredLevel = GameState.NumberGenerator.Next(21, 26);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentyOneToTwenyFiveGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Resolute Amulet");
            AmuletNames.Add("Resilient Amulet");
            AmuletNames.Add("Polished Amulet");


            temp = GameState.NumberGenerator.Next(1, 4);

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

            armor = GameState.NumberGenerator.Next(25, 36);
            strength = GameState.NumberGenerator.Next(0, 36);
            agility = GameState.NumberGenerator.Next(0, 36);
            intelligence = GameState.NumberGenerator.Next(0, 36);
            health = GameState.NumberGenerator.Next(0, 36);
            requiredLevel = GameState.NumberGenerator.Next(21, 26);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentyOneToTwenyFiveGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Resilient Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(30, 41);
            energyIncreased = GameState.NumberGenerator.Next(300, 651);
            requiredLevel = 21;
            worth = GameState.NumberGenerator.Next(30, 41);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }


    }
}