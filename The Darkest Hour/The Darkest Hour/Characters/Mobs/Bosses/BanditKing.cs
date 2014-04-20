using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditKing : Mob
    {
        public BanditKing()
        {
            this.damageMin = 60;
            this.damageMax = 100;
            this.health = 2000;
            this.maxHealth = 2000;
            this.level = 1;
            this.gold = 250;
            this.xp = 750;
            this.Identifier = "Bandit King";
        }
    }
}
