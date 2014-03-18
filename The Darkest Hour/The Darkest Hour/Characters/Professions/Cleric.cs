﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Characters.Professions
{
    public class Cleric : Profession
    {

        public override string Name { get { return "Cleric"; } }

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
                DarkestHourWindow.WriteLine(@"
Choose your attack:
1) Smite - 100% damage, adds 250 energy
2) Holy Strike - 500% damage, subtracts 750 energy
3) Expulsing Light -  400% damage, subtrats 500 energy
4) Wrath - 600% damage, subtracts 900 energy
5) Blinding Light - 50% damage, subtracts 100 energy, the enemey loses its next turn
6) Exorcise - 1000% damage, subtracts 1,000 energy
");
                try
                {
                    getUserInput = Console.ReadLine();
                    userInput = Int32.Parse(getUserInput);

                    switch (userInput)
                    {
                        case 1:
                            attackName = "Smite";
                            break;

                        case 2:
                            attackName = "Holy Strike";
                            break;

                        case 3:
                            attackName = "Expulsing Light";
                            break;

                        case 4:
                            attackName = "Wrath";
                            break;

                        case 5:
                            attackName = "Blinding Light";
                            break;

                        case 6:
                            attackName = "Exorcise";
                            break;

                        default:
                            DarkestHourWindow.WriteLine("You entered an invalid option.");
                            ClearScreen();
                            break;

                    }
                }
                catch
                {
                    DarkestHourWindow.WriteLine("You entered an invalid option.");
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
                case "Smite":
                    damage = myHero.damage;
                    myHero.energy += 250;
                    if (myHero.energy >= myHero.maxEnergy)
                        myHero.energy = myHero.maxEnergy;
                    break;

                case "Holy Strike":
                    if (myHero.energy >= 750)
                    {
                        damage = myHero.damage * 5;
                        myHero.energy -= 750;
                    }
                    else
                    {
                        DarkestHourWindow.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Expulsing Light":
                    if (myHero.energy >= 500)
                    {
                        damage = myHero.damage * 4;
                        myHero.energy -= 500;
                    }
                    else
                    {
                        DarkestHourWindow.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Wrath":
                    if (myHero.energy >= 900)
                    {
                        damage = myHero.damage * 6;
                        myHero.energy -= 900;
                    }
                    else
                    {
                        DarkestHourWindow.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Blinding Light":
                    if (myHero.energy >= 100)
                    {
                        damage = (myHero.damage / 2);
                        myHero.energy -= 100;
                    }
                    else
                    {
                        DarkestHourWindow.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                case "Exorcise":
                    if (myHero.energy == myHero.maxEnergy)
                    {
                        damage = myHero.damage * 10;
                        myHero.energy -= 1000;
                    }
                    else
                    {
                        DarkestHourWindow.WriteLine("Sorry, you don't have enough energy.");
                        CarryOn = false;
                        damage = 0;
                        ClearScreen();
                    }
                    break;

                default:
                    DarkestHourWindow.WriteLine("Uh oh, something went wrong");
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
