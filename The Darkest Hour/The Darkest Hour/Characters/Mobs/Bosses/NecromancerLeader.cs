using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class NecromancerLeader : Mob
    {
        public NecromancerLeader()
        {
            this.damageMin = 15;
            this.damageMax = 30;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 100;
            this.xp = 175;
            this.Identifier = "Necromancer Leader";
        }
    }
}
