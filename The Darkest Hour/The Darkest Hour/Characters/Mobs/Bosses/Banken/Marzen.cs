using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class Marzen : Mob
    {
        public Marzen()
        {
            this.damageMin = 170;
            this.damageMax = 230;
            this.health = 1850;
            this.maxHealth = 1850;
            this.level = 1;
            this.gold = 1850;
            this.xp = 2350;
            this.Identifier = "Marzen, High Necromancer";
        }
    }
}
