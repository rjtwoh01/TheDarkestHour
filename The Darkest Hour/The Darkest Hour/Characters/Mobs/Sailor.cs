using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Sailor : Mob
    {
        public Sailor()
        {
            this.damageMin = 1;
            this.damageMax = 4;
            this.health = 25;
            this.maxHealth = 25;
            this.level = 0;
            this.gold = 0;
            this.xp = 25;
            Identifier = "Sailor";
        }
    }
}
