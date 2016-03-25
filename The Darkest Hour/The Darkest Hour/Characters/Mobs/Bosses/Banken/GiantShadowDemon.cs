using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class GiantShadowDemon : Mob
    {
        public GiantShadowDemon()
        {
            this.damageMin = 155;
            this.damageMax = 215;
            this.health = 1700;
            this.maxHealth = 1700;
            this.level = 1;
            this.gold = 1700;
            this.xp = 2200;
            this.Identifier = "Giant Shadow Demon";
        }
    }
}
