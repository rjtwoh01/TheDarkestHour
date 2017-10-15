using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class William : Mob
    {
        public William()
        {
            this.damageMin = 175;
            this.damageMax = 235;
            this.health = 1900;
            this.maxHealth = 1900;
            this.level = 1;
            this.gold = 1900;
            this.xp = 1200;
            this.Identifier = "William";
        }
    }
}
