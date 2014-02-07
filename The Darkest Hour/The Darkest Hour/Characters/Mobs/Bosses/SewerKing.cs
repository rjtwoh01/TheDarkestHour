using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class SewerKing : Mob
    {
        public SewerKing()
        {
            this.damageMin = 2;
            this.damageMax = 8;
            this.health = 50;
            this.maxHealth = 50;
            this.level = 1;
            this.gold = 30;
            this.xp = 75;
            this.Identifier = "Sewer King";
        }
    }
}
