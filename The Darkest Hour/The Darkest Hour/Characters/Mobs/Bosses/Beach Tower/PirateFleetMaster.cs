using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class PirateFleetMaster : Mob
    {
        public PirateFleetMaster()
        {
            this.damageMin = 90;
            this.damageMax = 150;
            this.health = 1250;
            this.maxHealth = 1250;
            this.level = 1;
            this.gold = 1250;
            this.xp = 1750;
            this.Identifier = "Pirate Fleet Master";
        }
    }
}
