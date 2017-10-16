using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class EliteRanger : Mob
    {
        public EliteRanger()
        {
            this.damageMin = 50;
            this.damageMax = 75;
            this.health = 120;
            this.maxHealth = 120;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            this.Identifier = "Elite Ranger";
        }
    }
}
