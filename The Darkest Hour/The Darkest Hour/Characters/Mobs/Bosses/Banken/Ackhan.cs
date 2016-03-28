using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class Ackhan : Mob
    {
        public Ackhan()
        {
            this.damageMin = 160;
            this.damageMax = 220;
            this.health = 1750;
            this.maxHealth = 1750;
            this.level = 1;
            this.gold = 1750;
            this.xp = 2250;
            this.Identifier = "Ackhan";
        }
    }
}
