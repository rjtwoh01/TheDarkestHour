using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class SkeletonKing : Mob
    {
        public SkeletonKing()
        {
            this.damageMin = 5;
            this.damageMax = 15;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 50;
            this.xp = 125;
            this.Identifier = "Skeleton King";
        }
    }
}
