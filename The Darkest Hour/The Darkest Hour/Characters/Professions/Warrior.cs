using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Characters.Professions
{
    public class Warrior : Profession
    {
        Random rand = new Random();

        public override int GetDamageMultipler(Player myHero)
        {
            return myHero.strength * 5;
        }

        public override void CreateInitialHero(Player myHero)
        {
            myHero.mainStatName = "Strength";
            myHero.requiredWeaponType = "Sword";
            myHero.requiredArmorType = "Mail";
            Weapon aSword = new Weapon("Simple Sword", "Sword", 5, 2, 0, 0, 2, 0, 0, 1, 0, 0, 5);
            myHero.Inventory.Add(aSword);
            aSword.Equip(aSword, myHero);
        }


        public override string GetAttack(Player myHero)
        {
            string attackName = "";
            string getUserInput = "";
            int userInput = 0;

            do
            {
                Console.WriteLine(@"
Choose your attack:
1) Sword Strike - 100% damage, adds 25 energy
2) Brutal Strike - 500% damage, subtracts 750 energy
3) Lunge -  400% damage, subtrats 500 energy
4) Neck Swipe - 600% damage, subtracts 900 energy
5) Low Cut - 50% damage, subtracts 100 energy, the enemey loses its next turn
6) Ferocious Strike - 1000% damage, subtracts 1,000 energy
");
                try
                {
                    getUserInput = Console.ReadLine();
                    userInput = Int32.Parse(getUserInput);

                    switch (userInput)
                    {
                        case 1:
                            attackName = "Sword Strike";
                            break;

                        case 2:
                            attackName = "Brutal Strike";
                            break;

                        case 3:
                            attackName = "Lunge";
                            break;

                        case 4:
                            attackName = "Neck Swipe";
                            break;

                        case 5:
                            attackName = "Low Cut";
                            break;

                        case 6:
                            attackName = "Ferocious Strike";
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
                case "Sword Strike":
                    damage = myHero.damage;
                    myHero.energy += 25;
                    if (myHero.energy >= myHero.maxEnergy)
                        myHero.energy = myHero.maxEnergy;
                    break;

                case "Brutal Strike":
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

                case "Lunge":
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

                case "Neck Swipe":
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

                case "Low Cut":
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

                case "Ferocious Strike":
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
