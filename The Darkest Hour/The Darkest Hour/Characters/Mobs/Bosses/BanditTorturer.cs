using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditTorturer : Mob
    {
        public BanditTorturer()
        {
            this.damageMin = 75;
            this.damageMax = 95;
            this.health = 1400;
            this.maxHealth = 1400;
            this.level = 1;
            this.gold = 550;
            this.xp = 1000;
            this.Identifier = "Bandit Torturer";
        }
    }
}
