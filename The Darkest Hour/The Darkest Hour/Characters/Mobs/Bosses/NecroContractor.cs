using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class NecroContractor : Mob
    {
        public NecroContractor()
        {
            this.damageMin = 70;
            this.damageMax = 97;
            this.health = 1450;
            this.maxHealth = 1450;
            this.level = 1;
            this.gold = 1000;
            this.xp = 1100;
            this.Identifier = "Necromancer Contractor";
        }
    }
}
