using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class ShadeLord : Mob
    {
        public ShadeLord()
        {
            this.damageMin = 165;
            this.damageMax = 225;
            this.health = 1800;
            this.maxHealth = 1800;
            this.level = 1;
            this.gold = 1750;
            this.xp = 2300;
            this.Identifier = "Shade Lord";
        }
    }
}