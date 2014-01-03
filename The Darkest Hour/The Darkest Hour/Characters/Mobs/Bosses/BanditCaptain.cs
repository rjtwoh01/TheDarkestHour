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
            this.damageMin = 5;
            this.damageMax = 12;
            this.health = 200;
            this.maxHealth = 200;
            this.level = 2;
            this.gold = 50;
            this.xp = 100;
            this.Identifier = "Bandit Captain";
        }
    }
}
