using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class ReAnimatedStatue : Mob
    {
        public ReAnimatedStatue()
        {
            this.damageMin = 10;
            this.damageMax = 15;
            this.health = 200;
            this.maxHealth = 200;
            this.level = 1;
            this.gold = 50;
            this.xp = 25;
            this.Identifier = "Re-Animated Statue";
        }
    }
}
