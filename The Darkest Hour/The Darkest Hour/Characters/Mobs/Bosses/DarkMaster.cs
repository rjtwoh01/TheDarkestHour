using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class DarkMaster : Mob
    {
        public DarkMaster()
        {
            this.damageMin = 65;
            this.damageMax = 125;
            this.health = 1000;
            this.maxHealth = 1000;
            this.level = 1;
            this.gold = 1000;
            this.xp = 1600;
            this.Identifier = "Dark Master";
        }
    }
}
