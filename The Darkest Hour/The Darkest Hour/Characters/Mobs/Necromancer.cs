using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Necromancer : Mob
    {
        public Necromancer()
        {
            this.damageMin = 4;
            this.damageMax = 8;
            this.health = 40;
            this.maxHealth = 40;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            Identifier = "Necromancer";
        }
    }
}
