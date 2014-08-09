using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditAssaultLeader : Mob
    {
        public BanditAssaultLeader()
        {
            this.damageMin = 60;
            this.damageMax = 100;
            this.health = 1000;
            this.maxHealth = 1000;
            this.level = 1;
            this.gold = 250;
            this.xp = 1400;
            this.Identifier = "Bandit Assault Leader";
        }

    }
}
