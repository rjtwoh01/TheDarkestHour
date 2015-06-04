using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class NecroIntelligenceOfficer : Mob
    {
        public NecroIntelligenceOfficer()
        {
            this.damageMin = 85;
            this.damageMax = 145;
            this.health = 1200;
            this.maxHealth = 1200;
            this.level = 1;
            this.gold = 1200;
            this.xp = 1700;
            this.Identifier = "Spy Master";
        }
    }
}
