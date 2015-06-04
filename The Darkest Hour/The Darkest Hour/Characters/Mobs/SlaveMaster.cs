using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class SlaveMaster : Mob
    {
        public SlaveMaster()
        {
            this.damageMin = 6;
            this.damageMax = 15;
            this.health = 70;
            this.maxHealth = 70;
            this.level = 1;
            this.gold = 15;
            this.xp = 25;
            this.Identifier = "Slave Master";
        }
    }
}
