using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditSpy : Mob
    {
        public BanditSpy()
        {
            this.damageMin = 35;
            this.damageMax = 45;
            this.health = 200;
            this.maxHealth = 200;
            this.level = 1;
            this.gold = 150;
            this.xp = 225;
            this.Identifier = "Bandit Spy";
        }
    }
}
