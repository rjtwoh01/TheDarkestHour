using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Characters.Professions;
//using The_Darkest_Hour.GUIForm;


namespace The_Darkest_Hour.Combat
{
    class Battle
    {
        Hunter ranger = new Hunter();
        Mage mage = new Mage();
        Rogue rogue = new Rogue();
        Warrior warrior = new Warrior();
        Guardian guardian = new Guardian();
        Cleric cleric = new Cleric();
        Loot loot;
        string attack;
        string answer;
        int playerDamage, mobDamage;
        bool playerLost = false;
        bool mobLost = false;
        bool hasFled = false;
        bool actionStarted = false;

        public CombatResult DoBattle(Player myHero, Mob mob)
        {
            CombatResult returnData = CombatResult.NoResults;
            bool battleInProgress = true;
            GameState.Hero.isInCombat = true;

            do
            {
                answer = InitialQuestion(myHero, mob);
                if (answer == "Attack")
                {
                    actionStarted = true;
                    do{
                        attack = myHero.Profession.GetAttack(myHero);
                        playerDamage = myHero.Profession.CalculateDamage(myHero, attack);
                        if (playerDamage == 0)
                        {
                            DisplayStats(myHero, mob);
                        }
                    } while (playerDamage == 0) ;

                    mob.health -= playerDamage;
                    if (mob.health <= 0)
                    {
                        mob.health = 0;
                        mobLost = true;
                        battleInProgress = false;
                        returnData = CombatResult.PlayerVictory;
                    }
                    else
                    {
                        if (attack != "Distracting Shot" && attack != "Frozen" && attack != "Dust in the Eyes" && attack != "Low Cut" && attack != "Block" && attack != "Blinding Light")
                        {
                            mobDamage = mob.GetDamage(mob);
                            mobDamage = mobDamage - (mobDamage / myHero.armor);
                            myHero.health -= mobDamage;
                            if (myHero.health <= 0)
                            {
                                //If player is HC, add code here to delete the character
                                myHero.health = 0;
                                playerLost = true;
                                battleInProgress = false;
                                returnData = CombatResult.PlayerLoss;
                            }
                        }
                    }
                    Console.WriteLine("\n\n{0} attacks {1} with {2} and does {3} damage.", myHero.Identifier, mob.Identifier, attack, playerDamage);
                    Console.WriteLine("{0} has {1} health left.", mob.Identifier, mob.health);
                    if (attack != "Distracting Shot" && attack != "Frozen" && attack != "Dust in the Eyes" && attack != "Low Cut" && attack != "Block" && attack != "Blinding Light" && !mobLost)
                    {
                        Console.WriteLine("{0} attacks you for {1} damage.", mob.Identifier, mobDamage);
                        Console.WriteLine("{0} has {1} health left.\n\n", myHero.Identifier, myHero.health);
                    }
                    else if (attack == "Distracting Shot")
                        Console.WriteLine("{0} was too distracted to attack you!", mob.Identifier);
                    else if (attack == "Frozen")
                        Console.WriteLine("{0} was frozen and couldn't attack you!", mob.Identifier);
                    else if (attack == "Dust in the Eyes")
                        Console.WriteLine("{0} couldn't see so {0} couldn't attack you!", mob.Identifier);
                    else if (attack == "Low Cut")
                        Console.WriteLine("{0} was imobolized due to {0}'s leg injury, so {0} couldn't attack you!", mob.Identifier);
                    else if (attack == "Block")
                        Console.WriteLine("{0}'s attack was blocked by your shield!", mob.Identifier);
                    else if (attack == "Blinding Light")
                        Console.WriteLine("{0} couldn't see due to the bright flash of light, so {0} couldn't attack you!!", mob.Identifier);
                    ClearScreen();
                }


                /// <summary>
                /// Added code here to prevent the user for immediately going again after using their potion. 
                /// The mob has to attack after it for challenge.
                /// This is not the best implementation for the solution, but it's fine for now
                /// Need to come back later and work on something better
                /// Maybe have the mob's attack be its own method. Only problem is all the variables
                /// That the main battle method needs to work with. Maybe have thos be variables avaliable to the whole class?
                /// Not sure yet. Will look into later.
                /// </summary>
                else if (answer == "Inventory")
                {
                    battleInProgress = true;
                    hasFled = false;
                    myHero.DisplayInventory();
                    if (GameState.Hero.usedPotionCombat)
                    {
                        actionStarted = true;
                        if (mob.health <= 0)
                        {
                            mob.health = 0;
                            mobLost = true;
                            battleInProgress = false;
                            returnData = CombatResult.PlayerVictory;
                        }
                        else
                        {
                            if (attack != "Distracting Shot" && attack != "Frozen" && attack != "Dust in the Eyes" && attack != "Low Cut" && attack != "Block" && attack != "Blinding Light")
                            {
                                mobDamage = mob.GetDamage(mob);
                                mobDamage -= myHero.armor;
                                myHero.health -= mobDamage;
                                if (myHero.health <= 0)
                                {
                                    //If player is HC, add code here to delete the character
                                    myHero.health = 0;
                                    playerLost = true;
                                    battleInProgress = false;
                                    returnData = CombatResult.PlayerLoss;
                                }
                            }

                            Console.WriteLine("\n{0} attacks you for {1} damage.", mob.Identifier, mobDamage);
                            Console.WriteLine("{0} has {1} health left.\n\n", myHero.Identifier, myHero.health);
                        }
                        GameState.Hero.usedPotionCombat = false;
                    }
                    ClearScreen();
                }

                else if (answer == "Equipped")
                {
                    battleInProgress = true;
                    hasFled = false;
                    myHero.DisplayEquipped();
                    ClearScreen();
                }

                else if (answer == "Ration")
                {
                    battleInProgress = true;
                    hasFled = false;
                    if (!actionStarted)
                    {
                        if (myHero.travelRations > 0)
                        {
                            myHero.health = myHero.maxHealth;
                            myHero.energy = myHero.maxEnergy;
                            myHero.travelRations--;
                            Console.WriteLine("You use a travel ration to restore your health and energy to max.\nYou now have {0} rations left", myHero.travelRations);
                        }
                        else
                            Console.WriteLine("You don't have enough travel rations");
                    }
                    else if (actionStarted)
                        Console.WriteLine("You cannot use a travel ration once the battle has started");
                    ClearScreen();
                }

                else if (answer == "Flee")
                {
                    battleInProgress = false;
                    hasFled = true;
                    returnData = CombatResult.PlayerFled;
                    break;
                }

            } while (battleInProgress);

            mob.ResetHealth(mob);
            if (playerLost)
            {
                myHero.ResetHealth();
                Console.WriteLine("The battle is over and you lost. Better luck next time ya idiot.");
                playerLost = false;
            }
            else if (mobLost)
            {
                Console.WriteLine("The battle is over and you emerge victorious! Hail to the hero!");
                loot = new Loot(mob);
                myHero.xp += mob.xp;
                myHero.gold += mob.gold;
                myHero.GetLevel();
                mobLost = false;
            }
            else if (hasFled)
            {
                Console.WriteLine("\nYou run away with your tail in between your legs like a puppy. BABY!");
                hasFled = false;
            }

            ClearScreen();

            GameState.Hero.isInCombat = false;

            return returnData;

        }

        public void DisplayStats(Player myHero, Mob mob)
        {
            Console.WriteLine(@"
*********************************************************************
Name:           Level:          Health:        Energy:
---------------------------------------------------------------------
{0}             {1}             {2}            {3}
---------------------------------------------------------------------
{4}             {5}             {6}            {7}
*********************************************************************
", myHero.Identifier, myHero.level, myHero.health, myHero.energy, mob.Identifier, mob.level, mob.health, mob.energy);
        }

        private string InitialQuestion(Player myHero, Mob mob)
        {
            string answer = "";
            do
            {
                DisplayStats(myHero, mob);
                Console.WriteLine(@"
Do you want to:
1) Attack
2) Inventory
3) View Equipped Items
4) Use Travel Ration {0}
5) Flee
", myHero.travelRations);
                answer = Console.ReadLine();
                if (answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer != "5")
                    Console.Clear();
            } while (answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer != "5");

            if (answer == "1")
                answer = "Attack";
            else if (answer == "2")
                answer = "Inventory";
            else if (answer == "3")
                answer = "Equipped";
            else if (answer == "4")
                answer = "Ration";
            else if (answer == "5")
                answer = "Flee";

            return answer;
        }

        public void ClearScreen()
        {
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
        }

        public void ClearScreen(bool noMessage)
        {
            Console.Clear();
        }
    }
}