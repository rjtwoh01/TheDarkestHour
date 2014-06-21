using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class NecromancerEliteGuard : Mob
    {
        public NecromancerEliteGuard()
        {
            this.damageMin = 50;
            this.damageMax = 75;
            this.health = 50;
            this.maxHealth = 50;
            this.level = 1;
            this.gold = 10;
            this.xp = 25;
            this.Identifier = "Necromancer Elite Guard";
        }
    }
}
