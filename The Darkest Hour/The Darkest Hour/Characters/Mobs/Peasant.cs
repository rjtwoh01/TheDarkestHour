using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Peasant : Mob
    {
        public Peasant()
        {
            this.damageMin = 1;
            this.damageMax = 4;
            this.health = 35;
            this.maxHealth = 35;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            Identifier = "Peasant";
        }
    }
}
