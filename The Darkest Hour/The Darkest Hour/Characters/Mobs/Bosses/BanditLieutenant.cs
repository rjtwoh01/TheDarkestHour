using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditLieutenant : Mob
    {
        public BanditLieutenant()
        {
            this.damageMin = 5;
            this.damageMax = 12;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 75;
            this.xp = 125;
            this.Identifier = "Bandit Lieutenant";
        }
    }
}