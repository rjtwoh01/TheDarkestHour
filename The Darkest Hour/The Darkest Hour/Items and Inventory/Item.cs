using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using System.IO;

namespace The_Darkest_Hour.Items_and_Inventory
{
    public class Item
    {
        public string name, itemType, itemArchType;
        public int damage, strength, agility, intelligence, health, requiredLevel, armor, energyHeal, healthHeal, worth;
        public double magicFind, goldFind, critChance, critDamage;
        public bool isEquipped, full;
        public bool isEquipable = false;
        public bool isPotion = false;

        public void Equip(Item item, Player myHero)
        {
            if (myHero.level >= requiredLevel)
            {
                this.isEquipped = true;
                myHero.damage += damage;
                myHero.armor += armor;
                myHero.strength += strength;
                myHero.agility += agility;
                myHero.intelligence += intelligence;
                myHero.health += health;
                myHero.magicFind += magicFind;
                myHero.goldFind += goldFind;
                myHero.critChance += critChance;
                myHero.critDamage += critDamage;
                myHero.WeaponsFull = true;

                if (myHero.critChance > 1)
                    myHero.critChance = 1;
            }
            else
                Console.WriteLine("\nYou cannot equip that yet, you do not meet the required level.\n");
        }

        public void DeEquip(Item item, Player myHero)
        {
            this.isEquipped = false;
            myHero.damage -= damage;
            myHero.armor -= armor;
            myHero.strength -= strength;
            myHero.agility -= agility;
            myHero.intelligence -= intelligence;
            myHero.health -= health;
            myHero.magicFind -= magicFind;
            myHero.goldFind -= goldFind;
            myHero.WeaponsFull = false;
        }

        public bool SlotCheck(Player myHero)
        {
            bool isFull = false;

            if (itemArchType == "Weapon")
            {
                if (myHero.WeaponsFull)
                {
                    Console.WriteLine("\nWeapon slot is full");
                    isFull = true;
                }
                else
                {
                    isFull = false;
                }
            }

            else if (itemArchType == "Armor")
            {
                if (myHero.ArmorFull)
                {
                    Console.WriteLine("\nArmor slot is full");
                    isFull = true;
                }
                else
                {
                    isFull = false;
                }
            }

            else if (itemArchType == "Helmet")
            {
                if (myHero.HelmetFull)
                {
                    Console.WriteLine("\nHelmet slot is full");
                    isFull = true;
                }
                else
                {
                    isFull = false;
                }
            }

            else if (itemArchType == "Amulet")
            {
                if (myHero.AmuletFull)
                {
                    Console.WriteLine("\nAmulet slot is full");
                    isFull = true;
                }
                else
                {
                    isFull = false;
                }
            }

            else if (itemArchType == "Potion")
            {
                isFull = true;
            }

            return isFull;
        }


    }
}