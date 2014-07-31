using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Noble : Mob
    {
        public Noble()
        {
            this.damageMin = 1;
            this.damageMax = 1;
            this.health = 1;
            this.maxHealth = 1;
            this.level = 1;
            this.gold = 1;
            this.xp = 5;
            this.Identifier = "Noble";
        }
    }
}
