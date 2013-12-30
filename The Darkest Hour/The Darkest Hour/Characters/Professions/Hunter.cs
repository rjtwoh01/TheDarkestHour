using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Professions
{
    public class Hunter : Profession
    {
        Random rand = new Random();

        public override string GetAttack(Player myHero)
        {
            string attackName = "";
            string getUserInput = "";
            int userInput = 0;

            do
            {
                Console.WriteLine(@"
Choose your attack:
1) Quick Shot - 100% damage, adds 25 energy
2) Power Shot - 500% damage, subtracts 750 energy
3) Rapid Fire -  400% damage, subtrats 500 energy
4) Destructive Shot - 600% damage, subtracts 900 energy
5) Distracting Shot - 50% damage, subtracts 100 energy, the enemey loses its next turn
6) Silver Arrow - 1000% damage, subtracts 1,000 energy
");
                try
                {
                    getUserInput = Console.ReadLine();
                    userInput = Int32.Parse(getUserInput);

                    switch (userInput)
                    {
                        case 1:
                            attackName = "Quick Shot";
                            break;

                        case 2:
                            attackName = "Power Shot";
                            break;

                        case 3:
                            attackName = "Rapid Fire";
                            break;

                        case 4:
                            attackName = "Destructive Shot";
                            break;

                        case 5:
                            attackName = "Distracting Shot";
                            break;

                        case 6:
                            attackName = "Silver Arrow";
                            break;

                        default:
                            Console.WriteLine("You entered an invalid option.");
                            ClearScreen();
                            break;

                    }
                }
                catch
                {
                    Console.WriteLine("You entered an invalid option.");
                    ClearScreen();
                }
            } while (userInput > 1 && userInput > 6);

            return attackName;
        }

        public override int CalculateDamage(Player myHero, string attack)
        {
            int damage = 0;
            bool CarryOn = true;


            switch (attack)
            {
                case "Quick Shot":
                    damage = myHero.damage;
                    myHero.energy += 25;
                    if (myHero.energy >= myHero.maxEnergy)
                        myHero.energy = myHero.maxEnergy;
                        break;

                case "Power Shot":
                    if (myHero.energy >= 750)
                    {
                        damage = myHero.damage * 5;
                        myHero.energy -= 750;
                     }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Rapid Fire":
                    if (myHero.energy >= 500)
                    {
                        damage = myHero.damage * 4;
                        myHero.energy -= 500;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Destructive Shot":
                    if (myHero.energy >= 900)
                    {
                        damage = myHero.damage * 6;
                        myHero.energy -= 900;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Distracting Shot":
                    if (myHero.energy >= 100)
                    {
                        damage = (myHero.damage / 2);
                        myHero.energy -= 100;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Silver Arrow":
                    if (myHero.energy == myHero.maxEnergy)
                    {
                        damage = myHero.damage * 10;
                        myHero.energy -= 1000;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                default:
                    Console.WriteLine("Uh oh, something went wrong");
                    CarryOn = false;
                    ClearScreen();
                    break;
            }

            if (CarryOn)
            {
                damage = rand.Next(1, damage);

                int roll = 0;
                roll = rand.Next(1, 101);
                roll += (int)myHero.critChance;
                if (roll >= 100)
                    damage *= (int)myHero.critDamage;
            }
            else
            {
                damage = 0;
            }

            return damage;
        }

    }
}
