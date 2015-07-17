using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Scout : Mob
    {
        public Scout()
        {
            this.damageMin = 8;
            this.damageMax = 15;
            this.health = 70;
            this.maxHealth = 70;
            this.level = 1;
            this.gold = 5;
            this.xp = 25;
            this.Identifier = "Scout";
        }
    }
}
