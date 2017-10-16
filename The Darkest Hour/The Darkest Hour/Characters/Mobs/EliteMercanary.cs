using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class EliteMercanary : Mob
    {
        public EliteMercanary()
        {
            this.damageMin = 35;
            this.damageMax = 50;
            this.health = 150;
            this.maxHealth = 150;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            this.Identifier = "Elite Mercanary";
        }
    }
}
