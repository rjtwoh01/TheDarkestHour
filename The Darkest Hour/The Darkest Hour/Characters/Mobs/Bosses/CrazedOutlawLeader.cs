using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class CrazedOutlawLeader : Mob
    {
        public CrazedOutlawLeader()
        {
            this.damageMin = 35;
            this.damageMax = 60;
            this.health = 500;
            this.maxHealth = 500;
            this.level = 1;
            this.gold = 200;
            this.xp = 250;
            this.Identifier = "Crazed Outlaw Leader";
        }
    }
}
