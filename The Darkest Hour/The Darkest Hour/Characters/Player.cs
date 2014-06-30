using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Resources;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Characters.Professions;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Characters
{
    public class Player : Character
    {
        public double critChance = 0;
        public double critDamage = 1;
        public int requiredXP = 100;
        public int armor = 0; //Needs to be implemented
        public int inventoryCap = 60;
        public int maxGold = 1000000;
        public int travelRations = 0;
        public double magicFind;
        public double goldFind;
        public string mainStatName;
        public string requiredWeaponType;
        public string requiredArmorType;
        public string requiredAmuletType = "Amulet";
        public string startingLocation = "Watertown";
        public bool isHardCore = false;
        public bool isAlive = true;
        public bool WeaponsFull = false;
        public bool ArmorFull = false;
        public bool AmuletFull = false;
        public bool HelmetFull = false;
        public bool PotionsFull = false;
        public bool usedPotionCombat = false;
        public bool isInCombat = false;
        public List<Item> Inventory = new List<Item>();
        public List<Item> EquippedItems = new List<Item>();
        public Profession Profession;
        public Accomplishments Accomplishments = new Accomplishments();

        public void Initialize()
        {
            if (this.Identifier == null || this.Identifier == "" || this.Identifier == " ")
            {
                Console.WriteLine(CharacterResources.EnterCharacterName);
                this.Identifier = Console.ReadLine();
                Console.Clear();
                if (this.Identifier == null || this.Identifier == "" || this.Identifier == " ")
                {
                    Console.WriteLine(CharacterResources.EnterCharacterName);
                    this.Identifier = Console.ReadLine();
                    Console.Clear();
                }

                this.damageMin = 1;
                this.damage = 10;
                this.level = 1;
                this.levelCap = 50;
                this.energy = 1000;
                this.maxEnergy = 1000;
                this.health = 20;
                this.maxHealth = 20;

                ChooseProfession();

                Console.Clear();

                Console.WriteLine(CharacterResources.IntroPartOne);
                ClearScreen();
                Console.WriteLine(CharacterResources.IntroPartTwo);
                ClearScreen();
                Console.WriteLine(CharacterResources.IntroPartThree);
                ClearScreen();
            }
        }

        private void ChooseProfession()
        {
            CharacterProfessions prof;
            if (this.Profession == null)
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
                            this.Profession = new Rogue();
                            break;

                        case CharacterProfessions.Hunter:
                            this.Profession = new Hunter();
                            break;

                        case CharacterProfessions.Warrior:
                            this.Profession = new Warrior();
                            break;

                        case CharacterProfessions.Guardian:
                            this.Profession = new Guardian();
                            break;

                        case CharacterProfessions.Mage:
                            this.Profession = new Mage();
                            break;

                        case CharacterProfessions.Cleric:
                            this.Profession = new Cleric();
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

            this.Profession.CreateInitialHero(this);
            this.UpdateStats();

        }

        public int ResetHealth()
        {
            this.health = this.maxHealth;
            this.energy = 1000;
            return this.health;
        }

        public void DisplayProfession()
        {
            Console.WriteLine(this.Profession.Name);
            Console.WriteLine("Main stat is: {0}", this.mainStatName);
        }

        public void ClearScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void UpdateStats()
        {
            this.damage = this.Profession.GetDamageMultipler(this) + damage;
        }

        public void DisplayStats()
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
{4}                  {5}              {6}            {7}
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
", this.Identifier, this.level, this.health, this.damage, this.armor, this.strength, this.agility, this.intelligence, this.critChance, this.critDamage, this.goldFind, this.xp, this.requiredXP, this.gold);
        }

        public void DisplayInventory()
        {
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in this.Inventory)
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

                    Item selectedItem = this.Inventory.ElementAt(selected);

                    //Console.WriteLine("\nYou Selected: {0}", selectedItem);

                    if (selectedItem.isEquipable)
                    {
                        if (selectedItem.itemType == this.requiredArmorType || selectedItem.itemType == this.requiredWeaponType || selectedItem.itemType == this.requiredAmuletType)
                        {
                            if (selectedItem.isEquipped)
                            {
                                selectedItem.DeEquip(selectedItem, this);
                            }
                            else
                            {
                                if (this.level >= selectedItem.requiredLevel)
                                {
                                    bool isFull = selectedItem.SlotCheck(this);
                                    if (!isFull)
                                    {
                                        selectedItem.Equip(selectedItem, this);
                                        this.EquippedItems.Add(selectedItem);
                                        this.Inventory.Remove(selectedItem);
                                    }
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
                        this.health += selectedItem.healthHeal;
                        if (this.health >= this.maxHealth)
                            this.health = this.maxHealth;
                        this.energy += selectedItem.energyHeal;
                        if (this.energy >= this.maxEnergy)
                            this.energy = this.maxEnergy;

                        ClearScreen(false);

                        Console.WriteLine("\nYou use {0}", selectedItem.name);
                        if (selectedItem.healthHeal > 0)
                            Console.WriteLine("{0} heals you for {1}. \nYou now have {2} health", selectedItem.name, selectedItem.healthHeal, this.health);
                        if (selectedItem.energyHeal > 0)
                            Console.WriteLine("{0} increases your energy by {1}. \nYou now have {2} energy", selectedItem.name, selectedItem.energyHeal, this.energy);

                        this.Inventory.Remove(selectedItem);

                        if (this.isInCombat)
                            this.usedPotionCombat = true;
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayEquipped()
        {
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in this.EquippedItems)
            {
                Console.WriteLine(i + ". " + displayItems);
                i++;
            }
            try
            {
                Console.WriteLine("\n\nDo you want to use any of your equipped items?");
                Console.WriteLine("(1) Yes (2) No\n");
                string answer = Console.ReadLine();
                int answerParsed = Int32.Parse(answer);
                if (answerParsed == 1)
                {
                    Console.WriteLine("\nWhich item do you want to use?\n");
                    answer = Console.ReadLine();
                    int selected = Int32.Parse(answer);
                    selected -= 1;

                    Item selectedItem = this.EquippedItems.ElementAt(selected);

                    //Console.WriteLine("\nYou Selected: {0}", selectedItem);
                    if (Inventory.Count < inventoryCap)
                    {
                        selectedItem.DeEquip(selectedItem, this);
                        Inventory.Add(selectedItem);
                        EquippedItems.Remove(selectedItem);

                        Console.WriteLine("Successfully un-equipped {0}", selectedItem.name);
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough room in your inventory. Go sell something first.");
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Maybe AffixSwap() should be moved to a different class. Maybe the the Action that actually implements this method.
        public void AffixSwap()
        {
            Item selectedItem;
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in this.Inventory)
            {
                Console.WriteLine(i + ". " + displayItems);
                i++;
            }

            try
            {
                Console.WriteLine("\n\nDo you want to replace an affix of any item in your inventory?");
                Console.WriteLine("(1) Yes (2) No\n");
                string answer = Console.ReadLine();
                int answerParsed = Int32.Parse(answer);
                if (answerParsed == 1)
                {
                    do
                    {
                        Console.WriteLine("\nWhich item do you want to change an affix of?\n");
                        answer = Console.ReadLine();
                        int selected = Int32.Parse(answer);
                        selected -= 1;

                        selectedItem = this.Inventory.ElementAt(selected);

                        if (selectedItem.isPotion == true)
                        {
                            Console.WriteLine("\nSorry, we can't swap out affixes on a potion.\n");
                        }
                    } while (selectedItem.isPotion == true);

                    ClearScreen(false);

                    int cost = selectedItem.worth * 5;
                    string costAnswer = "";

                    do
                    {
                        Console.WriteLine("This will cost {0} gold and you have {1} gold. Do you wish to proceed (1) Yes (2) No?", cost, this.gold);
                        costAnswer = Console.ReadLine();
                        if (this.gold >= cost)
                        {
                            this.gold -= cost;
                            Console.WriteLine("You now have {0} gold", this.gold);

                            Console.WriteLine("\nYou Selected: {0}", selectedItem);

                            bool success = false;

                            do
                            {
                                Console.WriteLine("Which affix do you want to swap out? (ENTER FULL NAME OF THE AFFIX. CORRECTLY!)");
                                string affixAnswer = Console.ReadLine();
                                affixAnswer = affixAnswer.ToLower();
                                switch (affixAnswer)
                                {
                                    case "strength":
                                        selectedItem.strength = 0;
                                        break;
                                    case "intelligence":
                                        selectedItem.intelligence = 0;
                                        break;
                                    case "agility":
                                        selectedItem.agility = 0;
                                        break;
                                    default:
                                        Console.WriteLine("\nYou entered an invalid affix. Try again.\n");
                                        break;
                                }

                                int value = 0;

                                //GameState.NumberGenerator
                                
                                if (this.level < 10)
                                {
                                    value = GameState.NumberGenerator.Next(0, 11);
                                }
                                if (this.level >= 10)
                                {
                                    value = GameState.NumberGenerator.Next(5, 16);
                                }

                                bool secondSuccess = false;

                                do
                                {
                                    int itemAffix = GameState.NumberGenerator.Next(0, 3);

                                    switch (itemAffix)
                                    {
                                        case 0:
                                            if (affixAnswer != "strength")
                                            {
                                                selectedItem.strength += value;
                                                Console.WriteLine("\n{0} got {1} added to it's strength, it now has {2} strength", selectedItem.name, value, selectedItem.strength);
                                                secondSuccess = true;
                                            }
                                            break;
                                        case 1:
                                            if (affixAnswer != "intelligence")
                                            {
                                                selectedItem.intelligence += value;
                                                Console.WriteLine("\n{0} got {1} added to it's intelligence, it now has {2} intelligence", selectedItem.name, value, selectedItem.intelligence);
                                                secondSuccess = true;
                                            }
                                            break;
                                        case 2:
                                            if (affixAnswer != "agility")
                                            {
                                                selectedItem.agility += value;
                                                Console.WriteLine("\n{0} got {1} added to it's agility, it now has {2} agility", selectedItem.name, value, selectedItem.agility);
                                                secondSuccess = true;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                } while (!secondSuccess);

                                this.ClearScreen();
                                success = true;
                            } while (!success);
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough money. Try again.");
                            costAnswer = "";
                        }
                        ClearScreen();
                    } while (costAnswer != "1" && costAnswer != "2");

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SellItems()
        {
            Console.WriteLine();
            int i = 1;
            foreach (Item displayItems in this.Inventory)
            {
                Console.WriteLine(i + ". " + displayItems);
                i++;
            }

            try
            {
                Console.WriteLine("\n\nDo you want to sell any of the items in your inventory?");
                Console.WriteLine("(1) Yes (2) No\n");
                string answer = Console.ReadLine();
                int answerParsed = Int32.Parse(answer);
                if (answerParsed == 1)
                {
                    Console.WriteLine("\nWhich item do you want to sell?\n");
                    answer = Console.ReadLine();
                    int selected = Int32.Parse(answer);
                    selected -= 1;

                    Item selectedItem = this.Inventory.ElementAt(selected);

                    this.gold += selectedItem.worth;
                    if (this.gold >= this.maxGold)
                        this.gold = this.maxGold;

                    Console.WriteLine("\nYou sold {0} for {1} gold!", selectedItem.name, selectedItem.worth);
                    Console.WriteLine("You now have {0} gold!", this.gold);

                    if (selectedItem.isEquipped)
                        selectedItem.DeEquip(selectedItem, this);

                    this.Inventory.Remove(selectedItem);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetLevel()
        {
            if (this.level < levelCap)
            {
                this.requiredXP = CalculateXPNeeded();

                if (this.xp >= this.requiredXP)
                {
                    int leftOverXP = this.xp - this.requiredXP;
                    this.level += 1;
                    this.AddToStats(10, 2);
                    this.xp = 0 + leftOverXP;
                    int newXPRequired = CalculateXPNeeded();
                    this.requiredXP = newXPRequired;
                    Console.WriteLine("Congratulations! You leveled!\nYou're now level {0}!\nYou have {1} of {2} xp needed for level {3}", this.level, this.xp, this.requiredXP, (this.level + 1));
                    Console.WriteLine("\a");
                }


                else
                {
                    Console.WriteLine("{0}'s level: {1}", this.Identifier, this.level);
                    Console.WriteLine("You have {0} of {1} xp needed for level {2}.\n", this.xp, this.requiredXP, (this.level + 1));
                }
            }

            else
            {
                this.level = this.levelCap;
                this.xp = 0;
            }
        }

        private void AddToStats(int numberAddedToStats, int secondNumberAddedToStats)
        {
            this.damage += numberAddedToStats;
            this.strength += numberAddedToStats;
            this.agility += numberAddedToStats;
            this.intelligence += numberAddedToStats;
            this.health += numberAddedToStats;
            this.maxHealth += numberAddedToStats;
            this.damageMin += secondNumberAddedToStats;

            this.energy = this.maxEnergy;
            this.health = this.maxHealth;
        }

        private int CalculateXPNeeded()
        {
            int xpNeeded = 0;
            int playerLevel = this.level;

            if (this.level == 1)
                xpNeeded = 100;
            if (this.level >= 2 && this.level < 10)
            {
                xpNeeded = 100 + (playerLevel * (int)Math.Exp(2));
            }
            if (this.level >= 2 && this.level < 50)
            {
                xpNeeded = 100 + (playerLevel * (int)Math.Exp(4));
            }
            if (this.level == levelCap)
            {
                xpNeeded = 0;
                this.xp = 0;
            }

            return xpNeeded;
        }

        private void ClearScreen(bool noMessage)
        {
            Console.Clear();
        }
    }
}
