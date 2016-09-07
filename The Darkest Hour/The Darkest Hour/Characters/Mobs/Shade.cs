using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Shade : Mob
    {
        public Shade()
        {
            this.damageMin = 8;
            this.damageMax = 16;
            this.health = 115;
            this.maxHealth = 115;
            this.level = 1;
            this.gold = 25;
            this.xp = 25;
            this.Identifier = "Shade";
        }
    }
}
