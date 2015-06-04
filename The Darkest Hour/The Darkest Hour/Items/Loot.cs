using System;
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

        #region Loot Selection
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
            if (GameState.Hero.level >= 11 && GameState.Hero.level <= 15)
            {
                LevelsElevenToFifteenLoot();
            }
            if (GameState.Hero.level >= 16 && GameState.Hero.level <= 20)
            {
                LevelsSixteenToTwentyLoot();
            }
            if (GameState.Hero.level >= 21 && GameState.Hero.level <= 25)
            {
                LevelsTwentyOneToTwentyFiveLoot();
            }
            if (GameState.Hero.level >= 26 && GameState.Hero.level <= 30)
            {
                LevelsTwentySixToThirtyLoot();
            }
            if (GameState.Hero.level >= 31 && GameState.Hero.level <= 35)
            {
                LevelsThirtyOneToThirtyFiveLoot();
            }
            if (GameState.Hero.level >= 36 && GameState.Hero.level <= 40)
            {
                LevelsThirtySixToFortyLoot();
            }
            if (GameState.Hero.level >= 41 && GameState.Hero.level <= 50)
            {
                LevelsFortyOneToFortyFiveLoot();
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
            if (mob.level >= 21 && mob.level <= 25)
            {
                LevelsTwentyOneToTwentyFiveLoot();
            }
            if (mob.level >= 26 && mob.level <= 30)
            {
                LevelsTwentySixToThirtyLoot();
            }
            if (mob.level >= 31 && mob.level <= 35)
            {
                LevelsThirtyOneToThirtyFiveLoot();
            }
            if (mob.level >= 36 && mob.level <= 40)
            {
                LevelsThirtySixToFortyLoot();
            }
            if (mob.level >= 41 && mob.level <= 50)
            {
                LevelsFortyOneToFortyFiveLoot();
            }
        }
        #endregion

        #region Loot Call
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

        public void LevelsTwentySixToThirtyLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsTwentySixToThirtyGetWeapon();
                    break;
                case 2:
                    LevelsTwentySixToThirtyGetArmor();
                    break;
                case 3:
                    LevelsTwentySixToThirtyGetHelmet();
                    break;
                case 4:
                    LevelsTwentySixToThirtyGetAmulet();
                    break;
                case 5:
                    LevelsTwentySixToThirtyGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsThirtyOneToThirtyFiveLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsThirtyOneToThirtyFiveGetWeapon();
                    break;
                case 2:
                    LevelsThirtyOneToThirtyFiveGetArmor();
                    break;
                case 3:
                    LevelsThirtyOneToThirtyFiveGetHelmet();
                    break;
                case 4:
                    LevelsThirtyOneToThirtyFiveGetAmulet();
                    break;
                case 5:
                    LevelsThirtyOneToThirtyFiveGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsThirtySixToFortyLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsThirtySixToFortyGetWeapon();
                    break;
                case 2:
                    LevelsThirtySixToFortyGetArmor();
                    break;
                case 3:
                    LevelsThirtySixToFortyGetHelmet();
                    break;
                case 4:
                    LevelsThirtySixToFortyGetAmulet();
                    break;
                case 5:
                    LevelsThirtySixToFortyGetPotion();
                    break;
                default:
                    break;
            }
        }

        public void LevelsFortyOneToFortyFiveLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 6);
            switch (temp)
            {
                case 1:
                    LevelsFortyOneToFortyFiveGetWeapon();
                    break;
                case 2:
                    LevelsFortyOneToFortyFiveGetArmor();
                    break;
                case 3:
                    LevelsFortyOneToFortyFiveGetHelmet();
                    break;
                case 4:
                    LevelsFortyOneToFortyFiveGetAmulet();
                    break;
                case 5:
                    LevelsFortyOneToFortyFiveGetPotion();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Levels 1-5
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
        #endregion

        #region Levels 6-10
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
        #endregion

        #region Levels 11-15
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
        #endregion

        #region Levels 16-20
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
        #endregion

        #region Levels 21-25
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
        #endregion

        #region Levels 26-30
        public void LevelsTwentySixToThirtyGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Blackened Sword");
            SwordNames.Add("Cold Sword");
            SwordNames.Add("Fire Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Blackened Bow");
            BowNames.Add("Cold Bow");
            BowNames.Add("Fire Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Blackened Staff");
            StaffNames.Add("Cold Staff");
            StaffNames.Add("Fire Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Blackened Wand");
            WandNames.Add("Cold Wand");
            WandNames.Add("Fire Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Blackened Axe");
            AxeNames.Add("Cold Axe");
            AxeNames.Add("Fire Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Blackened Dagger");
            DaggerNames.Add("Cold Dagger");
            DaggerNames.Add("Fire Dagger");

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

            damage = GameState.NumberGenerator.Next(30, 41);
            strength = GameState.NumberGenerator.Next(0, 41);
            agility = GameState.NumberGenerator.Next(0, 41);
            intelligence = GameState.NumberGenerator.Next(0, 41);
            health = GameState.NumberGenerator.Next(0, 41);
            requiredLevel = GameState.NumberGenerator.Next(26, 31);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(30, 41);

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

        public void LevelsTwentySixToThirtyGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Cold Chainmail");
            ArmorNames.Add("Blackened Leather Armor");
            ArmorNames.Add("Fire Robes");


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


            armor = GameState.NumberGenerator.Next(30, 41);
            strength = GameState.NumberGenerator.Next(0, 41);
            agility = GameState.NumberGenerator.Next(0, 41);
            intelligence = GameState.NumberGenerator.Next(0, 41);
            health = GameState.NumberGenerator.Next(0, 41);
            requiredLevel = GameState.NumberGenerator.Next(26, 31);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(30, 41);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentySixToThirtyGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Blackened Helmet");
            HelmetNames.Add("Cold Helmet");
            HelmetNames.Add("Fire Hat");


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


            armor = GameState.NumberGenerator.Next(30, 41);
            strength = GameState.NumberGenerator.Next(0, 41);
            agility = GameState.NumberGenerator.Next(0, 41);
            intelligence = GameState.NumberGenerator.Next(0, 41);
            health = GameState.NumberGenerator.Next(0, 41);
            requiredLevel = GameState.NumberGenerator.Next(26, 31);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(30, 41);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentySixToThirtyGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Blackened Amulet");
            AmuletNames.Add("Cold Amulet");
            AmuletNames.Add("Fire Amulet");


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

            armor = GameState.NumberGenerator.Next(30, 41);
            strength = GameState.NumberGenerator.Next(0, 41);
            agility = GameState.NumberGenerator.Next(0, 41);
            intelligence = GameState.NumberGenerator.Next(0, 41);
            health = GameState.NumberGenerator.Next(0, 41);
            requiredLevel = GameState.NumberGenerator.Next(26, 31);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(30, 41);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsTwentySixToThirtyGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Cold Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(100, 201);
            energyIncreased = GameState.NumberGenerator.Next(400, 751);
            requiredLevel = 26;
            worth = GameState.NumberGenerator.Next(30, 41);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }
        #endregion

        #region Levels 31-35
        public void LevelsThirtyOneToThirtyFiveGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Earth Sword");
            SwordNames.Add("Warm Sword");
            SwordNames.Add("Storm Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Earth Bow");
            BowNames.Add("Warm Bow");
            BowNames.Add("Storm Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Earth Staff");
            StaffNames.Add("Warm Staff");
            StaffNames.Add("Storm Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Earth Wand");
            WandNames.Add("Warm Wand");
            WandNames.Add("Storm Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Earth Axe");
            AxeNames.Add("Warm Axe");
            AxeNames.Add("Storm Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Earth Dagger");
            DaggerNames.Add("Warm Dagger");
            DaggerNames.Add("Storm Dagger");

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

            damage = GameState.NumberGenerator.Next(35, 56);
            strength = GameState.NumberGenerator.Next(0, 56);
            agility = GameState.NumberGenerator.Next(0, 56);
            intelligence = GameState.NumberGenerator.Next(0, 56);
            health = GameState.NumberGenerator.Next(0, 56);
            requiredLevel = GameState.NumberGenerator.Next(31, 36);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(35, 56);

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

        public void LevelsThirtyOneToThirtyFiveGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Warm Chainmail");
            ArmorNames.Add("Earth Leather Armor");
            ArmorNames.Add("Storm Robes");


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


            armor = GameState.NumberGenerator.Next(35, 56);
            strength = GameState.NumberGenerator.Next(0, 56);
            agility = GameState.NumberGenerator.Next(0, 56);
            intelligence = GameState.NumberGenerator.Next(0, 56);
            health = GameState.NumberGenerator.Next(0, 56);
            requiredLevel = GameState.NumberGenerator.Next(31, 36);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(35, 56);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtyOneToThirtyFiveGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Earth Helmet");
            HelmetNames.Add("Warm Helmet");
            HelmetNames.Add("Storm Hat");


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


            armor = GameState.NumberGenerator.Next(35, 56);
            strength = GameState.NumberGenerator.Next(0, 56);
            agility = GameState.NumberGenerator.Next(0, 56);
            intelligence = GameState.NumberGenerator.Next(0, 56);
            health = GameState.NumberGenerator.Next(0, 56);
            requiredLevel = GameState.NumberGenerator.Next(31, 36);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(35, 56);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtyOneToThirtyFiveGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Earth Amulet");
            AmuletNames.Add("Warm Amulet");
            AmuletNames.Add("Storm Amulet");


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

            armor = GameState.NumberGenerator.Next(35, 56);
            strength = GameState.NumberGenerator.Next(0, 56);
            agility = GameState.NumberGenerator.Next(0, 56);
            intelligence = GameState.NumberGenerator.Next(0, 56);
            health = GameState.NumberGenerator.Next(0, 56);
            requiredLevel = GameState.NumberGenerator.Next(31, 36);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(35, 56);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtyOneToThirtyFiveGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Warm Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(150, 301);
            energyIncreased = GameState.NumberGenerator.Next(500, 851);
            requiredLevel = 31;
            worth = GameState.NumberGenerator.Next(35, 56);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }
        #endregion

        #region Levels 36-40
        public void LevelsThirtySixToFortyGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Jagged Sword");
            SwordNames.Add("Cold Sword");
            SwordNames.Add("Fire Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Jagged Bow");
            BowNames.Add("Cold Bow");
            BowNames.Add("Fire Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Jagged Staff");
            StaffNames.Add("Cold Staff");
            StaffNames.Add("Fire Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Jagged Wand");
            WandNames.Add("Cold Wand");
            WandNames.Add("Fire Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Jagged Axe");
            AxeNames.Add("Cold Axe");
            AxeNames.Add("Fire Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Jagged Dagger");
            DaggerNames.Add("Cold Dagger");
            DaggerNames.Add("Fire Dagger");

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

            damage = GameState.NumberGenerator.Next(40, 76);
            strength = GameState.NumberGenerator.Next(0, 76);
            agility = GameState.NumberGenerator.Next(0, 76);
            intelligence = GameState.NumberGenerator.Next(0, 76);
            health = GameState.NumberGenerator.Next(0, 76);
            requiredLevel = GameState.NumberGenerator.Next(36, 41);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(40, 76);

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

        public void LevelsThirtySixToFortyGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Cold Chainmail");
            ArmorNames.Add("Jagged Leather Armor");
            ArmorNames.Add("Fire Robes");


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


            armor = GameState.NumberGenerator.Next(40, 76);
            strength = GameState.NumberGenerator.Next(0, 76);
            agility = GameState.NumberGenerator.Next(0, 76);
            intelligence = GameState.NumberGenerator.Next(0, 76);
            health = GameState.NumberGenerator.Next(0, 76);
            requiredLevel = GameState.NumberGenerator.Next(36, 41);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(40, 76);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtySixToFortyGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Jagged Helmet");
            HelmetNames.Add("Cold Helmet");
            HelmetNames.Add("Fire Hat");


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


            armor = GameState.NumberGenerator.Next(40, 76);
            strength = GameState.NumberGenerator.Next(0, 76);
            agility = GameState.NumberGenerator.Next(0, 76);
            intelligence = GameState.NumberGenerator.Next(0, 76);
            health = GameState.NumberGenerator.Next(0, 76);
            requiredLevel = GameState.NumberGenerator.Next(36, 41);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(40, 76);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtySixToFortyGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Jagged Amulet");
            AmuletNames.Add("Cold Amulet");
            AmuletNames.Add("Fire Amulet");


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

            armor = GameState.NumberGenerator.Next(40, 76);
            strength = GameState.NumberGenerator.Next(0, 76);
            agility = GameState.NumberGenerator.Next(0, 76);
            intelligence = GameState.NumberGenerator.Next(0, 76);
            health = GameState.NumberGenerator.Next(0, 76);
            requiredLevel = GameState.NumberGenerator.Next(36, 41);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(40, 76);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsThirtySixToFortyGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Cold Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(200, 351);
            energyIncreased = GameState.NumberGenerator.Next(550, 901);
            requiredLevel = 36;
            worth = GameState.NumberGenerator.Next(40, 76);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }
        #endregion

        #region Levels 41-45
        public void LevelsFortyOneToFortyFiveGetWeapon()
        {
            rand = new Random();

            Weapon aSword;
            Weapon aBow;
            Weapon aStaff;
            Weapon aAxe;
            Weapon aDagger;
            Weapon aWand;

            List<string> SwordNames = new List<string>();
            SwordNames.Add("Champion's Sword");
            SwordNames.Add("Honor Sword");
            SwordNames.Add("Black Market Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add("Champion's Bow");
            BowNames.Add("Honor Bow");
            BowNames.Add("Black Market Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add("Champion's Staff");
            StaffNames.Add("Honor Staff");
            StaffNames.Add("Black Market Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add("Champion's Wand");
            WandNames.Add("Honor Wand");
            WandNames.Add("Black Market Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add("Champion's Axe");
            AxeNames.Add("Honor Axe");
            AxeNames.Add("Black Market Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Champion's Dagger");
            DaggerNames.Add("Honor Dagger");
            DaggerNames.Add("Black Market Dagger");

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

            damage = GameState.NumberGenerator.Next(45, 86);
            strength = GameState.NumberGenerator.Next(0, 86);
            agility = GameState.NumberGenerator.Next(0, 86);
            intelligence = GameState.NumberGenerator.Next(0, 86);
            health = GameState.NumberGenerator.Next(0, 86);
            requiredLevel = GameState.NumberGenerator.Next(40, 46);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(45, 86);

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

        public void LevelsFortyOneToFortyFiveGetArmor()
        {
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Honor Chainmail");
            ArmorNames.Add("Champion's Leather Armor");
            ArmorNames.Add("Black Market Robes");


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


            armor = GameState.NumberGenerator.Next(45, 86);
            strength = GameState.NumberGenerator.Next(0, 86);
            agility = GameState.NumberGenerator.Next(0, 86);
            intelligence = GameState.NumberGenerator.Next(0, 86);
            health = GameState.NumberGenerator.Next(0, 86);
            requiredLevel = GameState.NumberGenerator.Next(40, 46);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(45, 86);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aArmor);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsFortyOneToFortyFiveGetHelmet()
        {
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add("Champion's Helmet");
            HelmetNames.Add("Honor Helmet");
            HelmetNames.Add("Black Market Hat");


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


            armor = GameState.NumberGenerator.Next(45, 86);
            strength = GameState.NumberGenerator.Next(0, 86);
            agility = GameState.NumberGenerator.Next(0, 86);
            intelligence = GameState.NumberGenerator.Next(0, 86);
            health = GameState.NumberGenerator.Next(0, 86);
            requiredLevel = GameState.NumberGenerator.Next(40, 46);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(45, 86);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aHelmet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsFortyOneToFortyFiveGetAmulet()
        {
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add("Champion's Amulet");
            AmuletNames.Add("Honor Amulet");
            AmuletNames.Add("Black Market Amulet");


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

            armor = GameState.NumberGenerator.Next(45, 86);
            strength = GameState.NumberGenerator.Next(0, 86);
            agility = GameState.NumberGenerator.Next(0, 86);
            intelligence = GameState.NumberGenerator.Next(0, 86);
            health = GameState.NumberGenerator.Next(0, 86);
            requiredLevel = GameState.NumberGenerator.Next(40, 46);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(45, 86);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            Console.WriteLine("You loot {0}", itemName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aAmulet);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }

        public void LevelsFortyOneToFortyFiveGetPotion()
        {
            rand = new Random();

            Potion aPotion;

            string potionName = "Honor Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(250, 401);
            energyIncreased = GameState.NumberGenerator.Next(600, 951);
            requiredLevel = 40;
            worth = GameState.NumberGenerator.Next(45, 86);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            Console.WriteLine("You loot {0}", potionName);
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                GameState.Hero.Inventory.Add(aPotion);
            else
                Console.WriteLine("Unfortunately you don't have enough space to store {0} and it will lay forever abandoned and forgotten", itemName);
        }
        #endregion
    }
}