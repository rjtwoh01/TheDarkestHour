using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class PeasantLeader : Mob
    {
        public PeasantLeader()
        {
            this.damageMin = 40;
            this.damageMax = 70;
            this.health = 900;
            this.maxHealth = 900;
            this.level = 1;
            this.gold = 50;
            this.xp = 1300;
            this.Identifier = "Peasant Leader";
        }
    }
}
