using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class LordArgus : Mob
    {
        public LordArgus()
        {
            this.damageMin = 60;
            this.damageMax = 120;
            this.health = 1200;
            this.maxHealth = 1200;
            this.level = 1;
            this.gold = 500;
            this.xp = 1500;
            this.Identifier = "Lord Argus";
        }
    }
}
