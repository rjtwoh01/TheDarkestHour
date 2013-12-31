using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Characters.Professions;

namespace The_Darkest_Hour
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

        public void DoBattle(Player myHero, Mob mob)
        {
            bool battleInProgress = true;

            do
            {
                answer = InitialQuestion(myHero, mob);
                if (answer == "Attack")
                {
                    string profession = myHero.profession;

                    {
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
                    }
                    else
                    {
                        if (attack != "Distracting Shot" && attack != "Frozen" && attack != "Dust in the Eyes" && attack != "Low Cut" && attack != "Block" && attack != "Blinding Light")
                        {
                            mobDamage = mob.GetDamage(mob);
                            myHero.health -= mobDamage;
                            if (myHero.health <= 0)
                            {
                                //If player is HC, add code here to delete the character
                                myHero.health = 0;
                                playerLost = true;
                                battleInProgress = false;
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

                else if (answer == "Inventory")
                {
                    battleInProgress = true;
                    hasFled = false;
                    myHero.DisplayInventory();
                    ClearScreen();
                }

                else if (answer == "Flee")
                {
                    battleInProgress = false;
                    hasFled = true;
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
                loot = new Loot(myHero, mob);
                myHero.xp += mob.xp;
                myHero.GetLevel();
                mobLost = false;
            }
            else if (hasFled)
            {
                Console.WriteLine("\nYou run away with your tail in between your legs like a puppy. BABY!");
                hasFled = false;
            }

            ClearScreen();

        }

        public void DisplayStats(Player myHero, Mob mob)
        {
            Console.WriteLine(@"
*********************************************************************
Name:           Level:          Health:        Energy:
---------------------------------------------------------------------
{0}            {1}              {2}           {3}
---------------------------------------------------------------------
{4}            {5}              {6}           {7}
*********************************************************************
", myHero.Identifier, myHero.level, myHero.health, myHero.energy, mob.Identifier, mob.level, mob.health, mob.energy);
        }

        public string InitialQuestion(Player myHero, Mob mob)
        {
            string answer = "";
            do
            {
                DisplayStats(myHero, mob);
                Console.WriteLine(@"
Do you want to:
1) Attack
2) Inventory
3) Flee
");
                answer = Console.ReadLine();
                if (answer != "1" && answer != "2" && answer != "3")
                    Console.Clear();
            } while (answer != "1" && answer != "2" && answer != "3");

            if (answer == "1")
                answer = "Attack";
            else if (answer == "2")
                answer = "Inventory";
            else if (answer == "3")
                answer = "Flee";

            return answer;
        }

        public void ClearScreen()
        {
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}