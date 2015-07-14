using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class MaskedBandit : Mob
    {
        public MaskedBandit()
        {
            this.damageMin = 100;
            this.damageMax = 160;
            this.health = 1300;
            this.maxHealth = 1300;
            this.level = 1;
            this.gold = 1300;
            this.xp = 1800;
            this.Identifier = "Masked Bandit";
        }
    }
}
