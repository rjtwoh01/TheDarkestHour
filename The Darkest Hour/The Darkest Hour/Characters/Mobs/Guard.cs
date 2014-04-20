using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Guard : Mob
    {
        public Guard()
        {
            this.damageMin = 1;
            this.damageMax = 5;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 5;
            this.gold = 5;
            this.xp = 25;
            this.Identifier = "Guard";
        }
    }
}
