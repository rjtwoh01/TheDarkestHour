using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Items
{
    public class Helmet : Item
    {
        public string GetName { get { return this.name; } }
        public Helmet()
        {
            //DoNothing because nothing was passed into the constructor
        }

        public Helmet(string name, string weaponType, int armor, int strength, int agility, int intelligence, int health, double goldFind, double magicFind, int requiredLevel, double critChance, double critDamage, int worth)
        {
            this.name = name;
            this.itemType = weaponType;
            this.armor = armor;
            this.strength = strength;
            this.agility = agility;
            this.intelligence = intelligence;
            this.health = health;
            this.goldFind = goldFind;
            this.magicFind = magicFind;
            this.requiredLevel = requiredLevel;
            this.critChance = critChance;
            this.critDamage = critDamage;
            this.isEquipable = true;
            this.itemArchType = "Helmet";
            this.worth = worth;
        }

        public override string ToString()
        {
            var sw = new System.IO.StringWriter();
            sw.WriteLine("Item Name - \"{0}\"", name);
            sw.WriteLine("Item Type - \"{0}\"", itemType);
            if (armor != 0) { sw.WriteLine("Armor - {0}", armor); }
            if (strength != 0) { sw.WriteLine("Strength - {0}", strength); }
            if (agility != 0) { sw.WriteLine("Agility - {0}", agility); }
            if (intelligence != 0) { sw.WriteLine("Intelligence - {0}", intelligence); }
            if (health != 0) { sw.WriteLine("Health - {0}", health); }
            if (critChance != 0) { sw.WriteLine("Crit Chance - {0}", critChance); }
            if (critDamage != 0) { sw.WriteLine("Crit armor - {0}", critDamage); }
            if (magicFind != 0) { sw.WriteLine("Magic Find - {0}", magicFind); }
            if (goldFind != 0) { sw.WriteLine("Gold Find - {0}", goldFind); }
            sw.WriteLine("Required Level: {0} ", requiredLevel);
            sw.WriteLine("Worth: {0} gold", worth);
            if (isEquipped) { sw.WriteLine("Equipped"); }
            return sw.ToString();
        }


        public override void Equip(Item item, Player myHero)
        {
            if (myHero.level >= requiredLevel)
            {
                this.isEquipped = true;
                myHero.armor += armor;
                myHero.strength += strength;
                myHero.agility += agility;
                myHero.intelligence += intelligence;
                myHero.health += health;
                myHero.magicFind += magicFind;
                myHero.goldFind += goldFind;
                myHero.critChance += critChance;
                myHero.critDamage += critDamage;
                myHero.HelmetFull = true;

                if (myHero.critChance > 1)
                    myHero.critChance = 1;
            }
            else
                Console.WriteLine("\nYou cannot equip that yet, you do not meet the required level.\n");
        }

        public override void DeEquip(Item item, Player myHero)
        {
            this.isEquipped = false;
            myHero.armor -= armor;
            myHero.strength -= strength;
            myHero.agility -= agility;
            myHero.intelligence -= intelligence;
            myHero.health -= health;
            myHero.magicFind -= magicFind;
            myHero.goldFind -= goldFind;
            myHero.HelmetFull = false;
        }

        public override bool SlotCheck(Player myHero)
        {
            bool isFull;

            if (myHero.HelmetFull)
            {
                Console.WriteLine("\nHelmet Slot is full");
                isFull = true;
            }
            else
            {
                isFull = false;
            }

            return isFull;
        }
    }
}