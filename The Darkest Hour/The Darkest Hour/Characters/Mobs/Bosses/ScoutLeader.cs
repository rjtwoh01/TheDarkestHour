using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class ScoutLeader : Mob
    {
        public ScoutLeader()
        {
            this.damageMin = 125;
            this.damageMax = 185;
            this.health = 1450;
            this.maxHealth = 1450;
            this.level = 1;
            this.gold = 1450;
            this.xp = 1950;
            this.Identifier = "Scout Leader";
        }
    }
}
