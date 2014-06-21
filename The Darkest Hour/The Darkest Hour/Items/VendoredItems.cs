using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;


namespace The_Darkest_Hour.Items
{
    class VendoredItems
    {
        int damage, strength, agility, intelligence, health, requiredLevel, temp, temp2, armor, healAmount, energyIncreased, worth;
        double goldFind, magicFind, critChance, critDamage;
        string itemType, itemName;
        Random rand;

        public VendoredItems()
        {
            //if (GameState.Hero.level >= 1 && GameState.Hero.level <= 5)
            //{
            //    LevelsOneToFiveLoot();
            //}
            //if (GameState.Hero.level >= 6 && GameState.Hero.level <= 50)
            //{
            //    LevelsSixToTenLoot();
            //}
        }

        public void LevelsOneToFiveLoot()
        {
            rand = new Random();
            temp = GameState.NumberGenerator.Next(1, 7);
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
            temp = GameState.NumberGenerator.Next(1, 7);
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

        public void LevelsElevelToFifteenLoot()
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
                    LevelsTwentyOneToTwentyFiveGetWeapon();
                    break;
                case 2:
                    LevelsTwentyOneToTwentyFiveGetArmor();
                    break;
                case 3:
                    LevelsTwentyOneToTwentyFiveGetHelmet();
                    break;
                case 4:
                    LevelsTwentyOneToTwentyFiveGetAmulet();
                    break;
                case 5:
                    LevelsTwentyOneToTwentyFiveGetPotion();
                    break;
                default:
                    break;
            }
        }

        public Item LevelsOneToFiveGetWeapon()
        {
            Item returnData = new Item();

            rand = new Random();

            Weapon aWeapon;

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

            damage = GameState.NumberGenerator.Next(1, 11);
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


            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;
                    

            return returnData;
        }

        public Item LevelsOneToFiveGetArmor()
        {
            Item returnData = new Item();

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

            

            armor = GameState.NumberGenerator.Next(1, 11);
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
            returnData = aArmor;

            return returnData;
        }

        public Item LevelsOneToFiveGetHelmet()
        {
            Item returnData = new Item();
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


            armor = GameState.NumberGenerator.Next(1, 11);
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
            returnData = aHelmet;

            return returnData;
        }

        public Item LevelsOneToFiveGetAmulet()
        {
            Item returnData = new Item();
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

            armor = GameState.NumberGenerator.Next(1, 11);
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
            returnData = aAmulet;

            return returnData;
        }

        public Item LevelsOneToFiveGetPotion()
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = "Old Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(1, 11);
            energyIncreased = GameState.NumberGenerator.Next(1, 251);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(1, 11);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;

            return returnData;
        }

        public Item LevelsSixToTenGetWeapon()
        {
            Item returnData = new Item();
            rand = new Random();

            Weapon aWeapon;

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

            
            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;

            return returnData;        
        }

        public Item LevelsSixToTenGetArmor()
        {
            Item returnData = new Item();
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
            returnData = aArmor;

            return returnData;
        }

        public Item LevelsSixToTenGetHelmet()
        {
            Item returnData = new Item();
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
            returnData = aHelmet;

            return returnData;
        }

        public Item LevelsSixToTenGetAmulet()
        {
            Item returnData = new Item();
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
            returnData = aAmulet;

            return returnData;
        }

        public Item LevelsSixToTenGetPotion()
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(5, 16);
            energyIncreased = GameState.NumberGenerator.Next(100, 451);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(1, 16);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;

            return returnData;
        }

        public Item LevelsElevenToFifteenGetWeapon()
        {
            Item returnData = new Item();
            rand = new Random();

            Weapon aWeapon;

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


            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;

            return returnData;
        }

        public Item LevelsElevenToFifteenGetArmor()
        {
            Item returnData = new Item();
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
            returnData = aArmor;

            return returnData;
        }

        public Item LevelsElevenToFifteenGetHelmet()
        {
            Item returnData = new Item();
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
            returnData = aHelmet;

            return returnData;
        }

        public Item LevelsElevenToFifteenGetAmulet()
        {
            Item returnData = new Item();
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
            returnData = aAmulet;

            return returnData;
        }

        public Item LevelsElevenToFifteenGetPotion()
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(10, 26);
            energyIncreased = GameState.NumberGenerator.Next(200, 551);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(1, 16);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;

            return returnData;
        }

        public Item LevelsSixteenToTwentyGetWeapon()
        {
            Item returnData = new Item();
            rand = new Random();

            Weapon aWeapon;

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
            AxeNames.Add("Worn Axe");
            AxeNames.Add("Strong Axe");
            AxeNames.Add("New Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Worn Dagger");
            DaggerNames.Add("Dull Dagger");
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);


            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;

            return returnData;
        }

        public Item LevelsSixteenToTwentyGetArmor()
        {
            Item returnData = new Item();
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Stable Chainmail");
            ArmorNames.Add("Strong Leather Armor");
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aArmor;

            return returnData;
        }

        public Item LevelsSixteenToTwentyGetHelmet()
        {
            Item returnData = new Item();
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aHelmet;

            return returnData;
        }

        public Item LevelsSixteenToTwentyGetAmulet()
        {
            Item returnData = new Item();
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(20, 31);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aAmulet;

            return returnData;
        }

        public Item LevelsSixteenToTwentyGetPotion()
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(20, 31);
            energyIncreased = GameState.NumberGenerator.Next(250, 601);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(20, 31);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;

            return returnData;
        }

        public Item LevelsTwentyOneToTwentyFiveGetWeapon()
        {
            Item returnData = new Item();
            rand = new Random();

            Weapon aWeapon;

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
            AxeNames.Add("Worn Axe");
            AxeNames.Add("Resilient Axe");
            AxeNames.Add("Polished Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add("Worn Dagger");
            DaggerNames.Add("Dull Dagger");
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);


            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;

            return returnData;
        }

        public Item LevelsTwentyOneToTwentyFiveGetArmor()
        {
            Item returnData = new Item();
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add("Resolute Chainmail");
            ArmorNames.Add("Resilient Leather Armor");
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aArmor;

            return returnData;
        }

        public Item LevelsTwentyOneToTwentyFiveGetHelmet()
        {
            Item returnData = new Item();
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aHelmet;

            return returnData;
        }

        public Item LevelsTwentyOneToTwentyFiveGetAmulet()
        {
            Item returnData = new Item();
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
            requiredLevel = GameState.NumberGenerator.Next(11, 16);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(25, 36);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aAmulet;

            return returnData;
        }

        public Item LevelsTwentyOneToTwentyFiveGetPotion()
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = "Dull Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(30, 41);
            energyIncreased = GameState.NumberGenerator.Next(300, 651);
            requiredLevel = 1;
            worth = GameState.NumberGenerator.Next(30, 41);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;

            return returnData;
        }

    }
}