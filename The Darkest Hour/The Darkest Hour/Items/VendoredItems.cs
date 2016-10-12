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

        #region Loot Call

        #endregion

        public Item GetWeapon(string nameOne, string nameTwo, string nameThree, int minStat, int maxStat, int minRequired, int maxRequired)
        {
            Item returnData = new Item();
            rand = new Random();

            Weapon aWeapon;

            List<string> SwordNames = new List<string>();
            SwordNames.Add(nameOne + " Sword");
            SwordNames.Add(nameTwo + " Sword");
            SwordNames.Add(nameThree + " Sword");

            List<string> BowNames = new List<string>();
            BowNames.Add(nameOne + " Bow");
            BowNames.Add(nameTwo + " Bow");
            BowNames.Add(nameThree + " Bow");

            List<string> StaffNames = new List<string>();
            StaffNames.Add(nameOne + " Staff");
            StaffNames.Add(nameTwo + " Staff");
            StaffNames.Add(nameThree + " Staff");

            List<string> WandNames = new List<string>();
            WandNames.Add(nameOne + " Wand");
            WandNames.Add(nameTwo + " Wand");
            WandNames.Add(nameThree + " Wand");

            List<string> AxeNames = new List<string>();
            AxeNames.Add(nameOne + " Axe");
            AxeNames.Add(nameTwo + " Axe");
            AxeNames.Add(nameThree + " Axe");

            List<string> DaggerNames = new List<string>();
            DaggerNames.Add(nameOne + " Dagger");
            DaggerNames.Add(nameTwo + " Dagger");
            DaggerNames.Add(nameThree + " Dagger");

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

            damage = GameState.NumberGenerator.Next(minStat, maxStat);
            strength = GameState.NumberGenerator.Next(0, maxStat);
            agility = GameState.NumberGenerator.Next(0, maxStat);
            intelligence = GameState.NumberGenerator.Next(0, maxStat);
            health = GameState.NumberGenerator.Next(0, maxStat);
            requiredLevel = GameState.NumberGenerator.Next(minRequired, maxRequired);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(minStat, maxStat);

            aWeapon = new Weapon(itemName, itemType, damage, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aWeapon;
            return returnData;
        }

        public Item GetArmor(string nameOne, string nameTwo, string nameThree, int minStat, int maxStat, int minRequired, int maxRequired)
        {
            Item returnData = new Item();
            rand = new Random();

            Armor aArmor;

            List<string> ArmorNames = new List<string>();
            ArmorNames.Add(nameOne + " Chainmail");
            ArmorNames.Add(nameTwo + " Leather Armor");
            ArmorNames.Add(nameThree + " Robe");


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


            armor = GameState.NumberGenerator.Next(minStat, maxStat);
            strength = GameState.NumberGenerator.Next(0, maxStat);
            agility = GameState.NumberGenerator.Next(0, maxStat);
            intelligence = GameState.NumberGenerator.Next(0, maxStat);
            health = GameState.NumberGenerator.Next(0, maxStat);
            requiredLevel = GameState.NumberGenerator.Next(minRequired, maxRequired);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(minStat, maxStat);

            aArmor = new Armor(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aArmor;
            return returnData;
        }

        public Item GetHelmet(string nameOne, string nameTwo, string nameThree, int minStat, int maxStat, int minRequired, int maxRequired)
        {
            Item returnData = new Item();
            rand = new Random();

            Helmet aHelmet;

            List<string> HelmetNames = new List<string>();
            HelmetNames.Add(nameOne + " Helmet");
            HelmetNames.Add(nameTwo + " Helmet");
            HelmetNames.Add(nameThree + " Hat");


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


            armor = GameState.NumberGenerator.Next(minStat, maxStat);
            strength = GameState.NumberGenerator.Next(0, maxStat);
            agility = GameState.NumberGenerator.Next(0, maxStat);
            intelligence = GameState.NumberGenerator.Next(0, maxStat);
            health = GameState.NumberGenerator.Next(0, maxStat);
            requiredLevel = GameState.NumberGenerator.Next(minRequired, maxRequired);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(minStat, maxStat);

            aHelmet = new Helmet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aHelmet;
            return returnData;
        }

        public Item GetAmulet(string nameOne, string nameTwo, string nameThree, int minStat, int maxStat, int minRequired, int maxRequired)
        {
            Item returnData = new Item();
            rand = new Random();

            Amulet aAmulet;

            List<string> AmuletNames = new List<string>();
            AmuletNames.Add(nameOne + " Amulet");
            AmuletNames.Add(nameTwo + " Amulet");
            AmuletNames.Add(nameThree + " Amulet");


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

            armor = GameState.NumberGenerator.Next(minStat, maxStat);
            strength = GameState.NumberGenerator.Next(0, maxStat);
            agility = GameState.NumberGenerator.Next(0, maxStat);
            intelligence = GameState.NumberGenerator.Next(0, maxStat);
            health = GameState.NumberGenerator.Next(0, maxStat);
            requiredLevel = GameState.NumberGenerator.Next(minRequired, maxRequired);
            goldFind = 0;
            magicFind = 0;
            critChance = 0;
            critDamage = 0;
            worth = GameState.NumberGenerator.Next(minStat, maxStat);

            aAmulet = new Amulet(itemName, itemType, armor, strength, agility, intelligence, health, goldFind, magicFind, requiredLevel, critChance, critDamage, worth);
            returnData = aAmulet;
            return returnData;
        }

        public Item GetPotion(string name, int healMin, int healMax, int energyMin, int energyMax, int worthMin, int worthMax)
        {
            Item returnData = new Item();
            rand = new Random();

            Potion aPotion;

            string potionName = name + " Potion";

            itemType = "Potion";

            healAmount = GameState.NumberGenerator.Next(healMin, healMax);
            energyIncreased = GameState.NumberGenerator.Next(energyMin, energyMax);
            requiredLevel = GameState.Hero.level;
            worth = GameState.NumberGenerator.Next(worthMin, worthMax);

            aPotion = new Potion(potionName, healAmount, energyIncreased, requiredLevel, itemType, worth);
            returnData = aPotion;
            return returnData;
        }

    }
}