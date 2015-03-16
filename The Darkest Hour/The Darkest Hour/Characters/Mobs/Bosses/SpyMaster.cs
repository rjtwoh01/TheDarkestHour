using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class SpyMaster : Mob
    {
        public SpyMaster()
        {
            this.damageMin = 75;
            this.damageMax = 135;
            this.health = 1100;
            this.maxHealth = 1100;
            this.level = 1;
            this.gold = 1100;
            this.xp = 1650;
            this.Identifier = "Spy Master";
        }
    }
}
