using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class Zulien : Mob
    {
        public Zulien()
        {
            this.damageMin = 125;
            this.damageMax = 175;
            this.health = 1250;
            this.maxHealth = 1250;
            this.level = 1;
            this.gold = 700;
            this.xp = 700;
            this.Identifier = "Zulien";
        }
    }
}
