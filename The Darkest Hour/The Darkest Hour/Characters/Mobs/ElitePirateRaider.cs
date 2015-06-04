using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class ElitePirateRaider : Mob
    {
        public ElitePirateRaider()
        {
            this.damageMin = 14;
            this.damageMax = 30;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 25;
            this.xp = 25;
            this.Identifier = "Elite Pirate Raider";
        }
    }
}
