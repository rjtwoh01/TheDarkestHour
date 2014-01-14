using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditCaptain : Mob
    {
        public BanditCaptain()
        {
            this.damageMin = 3;
            this.damageMax = 10;
            this.health = 75;
            this.maxHealth = 75;
            this.level = 1;
            this.gold = 50;
            this.xp = 100;
            this.Identifier = "Bandit Captain";
        }
    }
}
