using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Ranger : Mob
    {
        public Ranger()
        {
            this.damageMin = 10;
            this.damageMax = 25;
            this.health = 80;
            this.maxHealth = 80;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            this.Identifier = "Ranger";
        }
    }
}
