using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class BanditRaidLeader : Mob
    {
        public BanditRaidLeader()
        {
            this.damageMin = 120;
            this.damageMax = 180;
            this.health = 1400;
            this.maxHealth = 1400;
            this.level = 1;
            this.gold = 1400;
            this.xp = 1900;
            this.Identifier = "Bandit Raid Leader";
        }
    }
}
