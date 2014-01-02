using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Characters.Professions
{
    public class Mage : Profession
    {

        public override string Name { get { return "Mage"; } }

        Random rand = new Random();

        public override int GetDamageMultipler(Player myHero)
        {
            return myHero.intelligence * 5;
        }


        public override void CreateInitialHero(Player myHero)
        {

            myHero.mainStatName = "Intelligence";
            myHero.requiredWeaponType = "Staff";
            myHero.requiredArmorType = "Cloth";
            Weapon aStaff = new Weapon("Simple Staff", "Staff", 5, 0, 0, 2, 2, 0, 0, 1, 0, 0, 5);
            myHero.Inventory.Add(aStaff);
            aStaff.Equip(aStaff, myHero);
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
1) Energy Missile - 100% damage, adds 200 energy
2) Fire Ball - 500% damage, subtracts 750 energy
3) Ice Blast -  400% damage, subtrats 500 energy
4) Howling Winds - 600% damage, subtracts 900 energy
5) Frozen - 50% damage, subtracts 100 energy, the enemey loses its next turn
6) Raging Inferno - 1000% damage, subtracts 1,000 energy
");
                try
                {
                    getUserInput = Console.ReadLine();
                    userInput = Int32.Parse(getUserInput);

                    switch (userInput)
                    {
                        case 1:
                            attackName = "Energy Missile";
                            break;

                        case 2:
                            attackName = "Fire Ball";
                            break;

                        case 3:
                            attackName = "Ice Blast";
                            break;

                        case 4:
                            attackName = "Howling Winds";
                            break;

                        case 5:
                            attackName = "Frozen";
                            break;

                        case 6:
                            attackName = "Raging Inferno";
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
                case "Energy Missile":
                    damage = myHero.damage;
                    myHero.energy += 200;
                    if (myHero.energy >= myHero.maxEnergy)
                        myHero.energy = myHero.maxEnergy;
                    break;

                case "Fire Ball":
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

                case "Ice Blast":
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

                case "Howling Winds":
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

                case "Frozen":
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

                case "Raging Inferno":
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
