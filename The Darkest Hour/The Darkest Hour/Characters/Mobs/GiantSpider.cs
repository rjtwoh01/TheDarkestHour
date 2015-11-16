using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class GiantSpider : Mob
    {
        public GiantSpider()
        {
            this.damageMin = 15;
            this.damageMax = 25;
            this.health = 110;
            this.maxHealth = 110;
            this.level = 1;
            this.gold = 10;
            this.xp = 25;
            this.Identifier = "Giant Spider";
        }
    }
}