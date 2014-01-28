using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditSupplyCaptain : Mob
    {
        public BanditSupplyCaptain()
        {
            this.damageMin = 5;
            this.damageMax = 15;
            this.health = 125;
            this.maxHealth = 125;
            this.level = 1;
            this.gold = 75;
            this.xp = 125;
            this.Identifier = "Bandit Supply Captain";
        }
    }
}
