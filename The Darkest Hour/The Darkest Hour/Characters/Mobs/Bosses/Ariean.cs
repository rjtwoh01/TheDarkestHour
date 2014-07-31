using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class Ariean : Mob
    {
        public Ariean()
        {
            this.damageMin = 70;
            this.damageMax = 90;
            this.health = 1350;
            this.maxHealth = 1350;
            this.level = 1;
            this.gold = 2000;
            this.xp = 900;
            this.Identifier = "Ariean";
        }
    }
}
