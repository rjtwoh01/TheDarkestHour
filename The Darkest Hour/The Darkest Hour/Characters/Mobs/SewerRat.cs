using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class SewerRat : Mob
    {
        public SewerRat()
        {
            this.damageMin = 1;
            this.damageMax = 3;
            this.health = 20;
            this.maxHealth = 20;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            Identifier = "Sewer Rat";
        }
    }
}
