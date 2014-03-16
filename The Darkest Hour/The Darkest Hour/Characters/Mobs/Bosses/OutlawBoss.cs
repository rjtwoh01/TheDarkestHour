using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class OutlawBoss : Mob
    {
        public OutlawBoss()
        {
            this.damageMin = 3;
            this.damageMax = 9;
            this.health = 60;
            this.maxHealth = 60;
            this.level = 1;
            this.gold = 35;
            this.xp = 85;
            this.Identifier = "Outlaw Boss";
        }
    }
}
