using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditWarden : Mob
    {
        public BanditWarden()
        {
            this.damageMin = 50;
            this.damageMax = 60;
            this.health = 1000;
            this.maxHealth = 1000;
            this.level = 1;
            this.gold = 750;
            this.xp = 1200;
            this.Identifier = "Bandit Warden";
        }
    }
}
