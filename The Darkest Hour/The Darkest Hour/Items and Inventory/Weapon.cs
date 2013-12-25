using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Items_and_Inventory
{
    class Weapon : Item
    {
        public string GetName { get { return this.name; } }
        public Weapon()
        {
            //DoNothing because nothing was passed into the constructor
        }

        public Weapon(string name, string weaponType, int damage, int strength, int agility, int intelligence, int health, double goldFind, double magicFind, int requiredLevel, double critChance, double critDamage, int worth)
        {
            this.name = name;
            this.itemType = weaponType;
            this.damage = damage;
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
            this.itemArchType = "Weapon";
            this.worth = worth;
        }

        public override string ToString()
        {
            var sw = new System.IO.StringWriter();
            sw.WriteLine("Item Name - \"{0}\"", name);
            sw.WriteLine("Item Type - \"{0}\"", itemType);
            if (damage != 0) { sw.WriteLine("Damage - {0}", damage); }
            if (strength != 0) { sw.WriteLine("Strength - {0}", strength); }
            if (agility != 0) { sw.WriteLine("Agility - {0}", agility); }
            if (intelligence != 0) { sw.WriteLine("Intelligence - {0}", intelligence); }
            if (health != 0) { sw.WriteLine("Health - {0}", health); }
            if (critChance != 0) { sw.WriteLine("Crit Chance - {0}", critChance); }
            if (critDamage != 0) { sw.WriteLine("Crit Damage - {0}", critDamage); }
            if (magicFind != 0) { sw.WriteLine("Magic Find - {0}", magicFind); }
            if (goldFind != 0) { sw.WriteLine("Gold Find - {0}", goldFind); }
            sw.WriteLine("Required Level: {0} ", requiredLevel);
            sw.WriteLine("Worth: {0} gold", worth);
            if (isEquipped) { sw.WriteLine("Equipped"); }
            return sw.ToString();
        }


        public void Equip(Item item, Player myHero)
        {
            if (myHero.level >= requiredLevel)
            {
                this.isEquipped = true;
                myHero.damage += damage;
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
            bool isFull;

            if (myHero.WeaponsFull)
            {
                Console.WriteLine("\nArmor Slot is full");
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