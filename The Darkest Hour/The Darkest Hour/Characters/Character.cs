using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters
{

    [System.Xml.Serialization.XmlInclude(typeof(Player))]
    public class Character
    {
        public string Identifier;
        public int strength, agility, damage, intelligence, vitality, defence, magic, gold, experience, health, getDamage, getMagic, getHeal, maxHealth, damageMin, damageMax, magicMin, magicMax, level, energy, xp;
    }
}