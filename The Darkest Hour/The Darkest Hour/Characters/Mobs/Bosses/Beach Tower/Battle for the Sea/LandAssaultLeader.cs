using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class LandAssaultLeader : Mob
    {
        public LandAssaultLeader()
        {
            this.damageMin = 130;
            this.damageMax = 190;
            this.health = 1500;
            this.maxHealth = 1500;
            this.level = 1;
            this.gold = 1500;
            this.xp = 2000;
            this.Identifier = "Land Assault Leader";
        }
    }
}