using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class SailorCaptain : Mob
    {
        public SailorCaptain()
        {
            this.damageMin = 140;
            this.damageMax = 200;
            this.health = 1600;
            this.maxHealth = 1600;
            this.level = 1;
            this.gold = 1600;
            this.xp = 2100;
            this.Identifier = "Sailor Captain";
        }
    }
}
