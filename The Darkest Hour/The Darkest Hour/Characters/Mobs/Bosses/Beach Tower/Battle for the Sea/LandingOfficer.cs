using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class LandingOfficer : Mob
    {
        public LandingOfficer()
        {
            this.damageMin = 135;
            this.damageMax = 195;
            this.health = 1550;
            this.maxHealth = 1550;
            this.level = 1;
            this.gold = 1550;
            this.xp = 2050;
            this.Identifier = "Landing Officer";
        }
    }
}
