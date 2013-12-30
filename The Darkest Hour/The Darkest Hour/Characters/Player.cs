using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Resources;
using The_Darkest_Hour.Items_and_Inventory;
using The_Darkest_Hour.Characters.Professions;

namespace The_Darkest_Hour.Characters
{
    public class Player : Character
    {
        public int mainStat;
        public double critChance = 0;
        public double critDamage = 1;
        public int damage = 10;
        public int level = 1;
        public int levelCap = 50;
        public int energy = 1000;
        public int maxEnergy = 1000;
        public int health = 20;
        public int maxHealth = 20;
        public int requiredXP = 100;
        public int armor = 0; //Needs to be implemented
        public int inventoryCap = 40;
        public int maxGold = 1000000;
        public double magicFind;
        public double goldFind;
        public string Rogue = "Rogue";
        public string Hunter = "Hunter";
        public string Warrior = "Warrior";
        public string Guardian = "Guardian";
        public string Mage = "Mage";
        public string Cleric = "Cleric";
        public string profession = null;
        public string mainStatName;
        public string requiredWeaponType;
        public string requiredArmorType;
        public string requiredAmuletType = "Amulet";
        public bool isHardCore = false;
        public bool isAlive = true;
        public bool WeaponsFull = false;
        public bool ArmorFull = false;
        public bool AmuletFull = false;
        public bool HelmetFull = false;
        public bool PotionsFull = false;
        public string Identifier;
        public List<Item> Inventory = new List<Item>();
        public Profession Profession;

        public void Initialize(Player hero)
        {
            if (hero.Identifier == null || hero.Identifier == "" || hero.Identifier == " ")
            {
                Console.WriteLine(CharacterResources.EnterCharacterName);
                hero.Identifier = Console.ReadLine();
                Console.Clear();
                if (hero.Identifier == null || hero.Identifier == "" || hero.Identifier == " ")
                {
                    Console.WriteLine(CharacterResources.EnterCharacterName);
                    hero.Identifier = Console.ReadLine();
                    Console.Clear();
                }

                ChooseProfession(hero);
                Console.Clear();

                Console.WriteLine(CharacterResources.IntroPartOne);
                ClearScreen();
                Console.WriteLine(CharacterResources.IntroPartTwo);
                ClearScreen();
                Console.WriteLine(CharacterResources.IntroPartThree);
                ClearScreen();
            }
        }

        private void ChooseProfession(Player myHero)
        {
            CharacterProfessions prof;
            if (profession == null)
            {
                Console.WriteLine(CharacterResources.ChooseProfession); //Ask the player what profession they want to be
                try
                {
                    string buffer = Console.ReadLine(); //Recieve the input as a public string
                    prof = (CharacterProfessions)Convert.ToInt32(buffer); //Convert it to an public int, using enums for readability in code
                    // TODO: Remove the profession property when everything reads the Profession property
                    switch (prof)
                    {
                        case CharacterProfessions.Invalid:
                            Console.WriteLine("Uh oh, something went wrong O.O\n");
                            break;

                        case CharacterProfessions.Rogue:
                            myHero.profession = Rogue;
                            myHero.Profession = new Rogue();
                            break;

                        case CharacterProfessions.Hunter:
                            myHero.profession = Hunter;
                            myHero.Profession = new Hunter();
                            break;

                        case CharacterProfessions.Warrior:
                            myHero.profession = Warrior;
                            myHero.Profession = new Warrior();
                            break;

                        case CharacterProfessions.Guardian:
                            myHero.profession = Guardian;
                            myHero.Profession = new Guardian();
                            break;

                        case CharacterProfessions.Mage:
                            myHero.profession = Mage;
                            myHero.Profession = new Mage();
                            break;

                        case CharacterProfessions.Cleric:
                            myHero.profession = Cleric;
                            myHero.Profession = new Cleric();
                            break;

                        default:
                            Console.WriteLine("Uh oh, something went wrong O.O\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            myHero.Profession.CreateInitialHero(myHero);
            myHero.UpdateStats();

        }

        public int ResetHealth(Player myHero)
        {
            myHero.health = myHero.maxHealth;
            myHero.energy = 1000;
            return myHero.health;
        }

        public void DisplayProfession(Player myHero)
        {
            Console.WriteLine(myHero.profession);
            Console.WriteLine("Main stat is: {0}", myHero.mainStatName);
        }

        public void ClearScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void UpdateStats()
        {
            switch (this.profession)
            {
                case "Rogue":
                    damage = (agility * 5) + damage;
                    break;

                case "Hunter":
                    damage = (agility * 5) + damage;
                    break;

                case "Warrior":
                    damage = (strength * 5) + damage;
                    break;

                case "Guardian":
                    damage = (strength * 5) + damage;
                    break;

                case "Mage":
                    damage = (intelligence * 5) + damage;
                    break;

                case "Cleric":
                    damage = (intelligence * 5) + damage;
                    break;
            }
        }

        public void DisplayStats(Player myHero)
        {
            Console.WriteLine(@"
*************************************************************************
Name:           Level:          Health:           Damage:   
-------------------------------------------------------------------------
{0}             {1}             {2}               {3}
*************************************************************************
*************************************************************************
 Armor:             Strength:         Agility:       Intelligence:          
-------------------------------------------------------------------------
{4}                  {5}              {6}             {7}
*************************************************************************
*************************************************************************
 Critical Chance:   Critical Damge:   Gold Find:         
-------------------------------------------------------------------------
{8}                  {9}              {10}            
*************************************************************************
*************************************************************************
 XP / XP Needed To Level            Gold:
-------------------------------------------------------------------------
{11} / {12}                         {13}
*************************************************************************
", myHero.Identifier, myHero.level, myHero.health, myHero.damage, myHero.armor, myHero.strength, myHero.agility, myHero.intelligence, myHero.critChance, myHero.critDamage, myHero.goldFind, myHero.xp, myHero.requiredXP, myHero.gold);
        }

        public void DisplayInventory(Player myHero)
        {
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in myHero.Inventory)
            {
                Console.WriteLine(i + ". " + displayItems);
                i++;
            }

            try
            {
                Console.WriteLine("\n\nDo you want to use any of the items in your inventory?");
                Console.WriteLine("(1) Yes (2) No\n");
                string answer = Console.ReadLine();
                int answerParsed = Int32.Parse(answer);
                if (answerParsed == 1)
                {
                    Console.WriteLine("\nWhich item do you want to use?\n");
                    answer = Console.ReadLine();
                    int selected = Int32.Parse(answer);
                    selected -= 1;

                    Item selectedItem = myHero.Inventory.ElementAt(selected);

                    //Console.WriteLine("\nYou Selected: {0}", selectedItem);

                    if (selectedItem.isEquipable)
                    {
                        if (selectedItem.itemType == myHero.requiredArmorType || selectedItem.itemType == myHero.requiredWeaponType || selectedItem.itemType == myHero.requiredAmuletType)
                        {
                            if (selectedItem.isEquipped)
                            {
                                selectedItem.DeEquip(selectedItem, myHero);
                            }
                            else
                            {
                                if (myHero.level >= selectedItem.requiredLevel)
                                {
                                    bool isFull = selectedItem.SlotCheck(myHero);
                                    if (!isFull)
                                        selectedItem.Equip(selectedItem, myHero);
                                }
                                else
                                {
                                    Console.WriteLine("You're not high enough level");
                                }
                            }
                        }
                        else
                            Console.WriteLine("You cannot use that item.");
                    }

                    if (selectedItem.isPotion)
                    {
                        myHero.health += selectedItem.healthHeal;
                        if (myHero.health >= myHero.maxHealth)
                            myHero.health = myHero.maxHealth;
                        myHero.energy += selectedItem.energyHeal;
                        if (myHero.energy >= myHero.maxEnergy)
                            myHero.energy = myHero.maxEnergy;

                        Console.WriteLine("\nYou use {0}", selectedItem.name);
                        if (selectedItem.healthHeal > 0)
                            Console.WriteLine("{0} heals you for {1}. \nYou now have {2} health", selectedItem.name, selectedItem.healthHeal, myHero.health);
                        if (selectedItem.energyHeal > 0)
                            Console.WriteLine("{0} increases your energy by {1}. \nYou now have {2} energy", selectedItem.name, selectedItem.energyHeal, myHero.energy);

                        myHero.Inventory.Remove(selectedItem);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SellItems(Player myHero)
        {
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in myHero.Inventory)
            {
                Console.WriteLine(i + ". " + displayItems);
                i++;
            }

            try
            {
                Console.WriteLine("\n\nDo you want to use any of the items in your inventory?");
                Console.WriteLine("(1) Yes (2) No\n");
                string answer = Console.ReadLine();
                int answerParsed = Int32.Parse(answer);
                if (answerParsed == 1)
                {
                    Console.WriteLine("\nWhich item do you want to use?\n");
                    answer = Console.ReadLine();
                    int selected = Int32.Parse(answer);
                    selected -= 1;

                    Item selectedItem = myHero.Inventory.ElementAt(selected);

                    myHero.gold += selectedItem.worth;
                    if (myHero.gold >= myHero.maxGold)
                        myHero.gold = myHero.maxGold;

                    Console.WriteLine("\nYou sold {0} for {1} gold!", selectedItem.name, selectedItem.worth);
                    Console.WriteLine("You now have {0} gold!", myHero.gold);

                    myHero.Inventory.Remove(selectedItem);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetLevel(Player myHero)
        {
            if (myHero.level < levelCap)
            {
                myHero.requiredXP = CalculateXPNeeded(myHero);

                if (myHero.xp >= myHero.requiredXP)
                {
                    int leftOverXP = myHero.xp - myHero.requiredXP;
                    myHero.level += 1;
                    AddToStats(myHero, 10);
                    myHero.xp = 0 + leftOverXP;
                    int newXPRequired = CalculateXPNeeded(myHero);
                    myHero.requiredXP = newXPRequired;
                    Console.WriteLine("Congratulations! You leveled!\nYou're now level {0}!\nYou have {1} of {2} xp needed for level {3}", myHero.level, myHero.xp, myHero.requiredXP, (myHero.level + 1));
                }


                else
                {
                    Console.WriteLine("{0}'s level: {1}", myHero.Identifier, myHero.level);
                    Console.WriteLine("You have {0} of {1} xp needed for level {2}.\n", myHero.xp, myHero.requiredXP, (myHero.level + 1));
                }
            }

            else
            {
                myHero.level = myHero.levelCap;
                myHero.xp = 0;
            }
        }

        private void AddToStats(Player myHero, int numberAddedToStats)
        {
            myHero.damage += numberAddedToStats;
            myHero.strength += numberAddedToStats;
            myHero.agility += numberAddedToStats;
            myHero.intelligence += numberAddedToStats;
            myHero.health += numberAddedToStats;
        }

        private int CalculateXPNeeded(Player myHero)
        {
            int xpNeeded = 0;
            int playerLevel = myHero.level;

            if (myHero.level == 1)
                xpNeeded = 100;
            if (myHero.level >= 2)
            {
                xpNeeded = 100 + (playerLevel * (int)Math.Exp(2));
            }
            if (myHero.level == levelCap)
            {
                xpNeeded = 0;
                myHero.xp = 0;
            }

            return xpNeeded;
        }
    }
}
