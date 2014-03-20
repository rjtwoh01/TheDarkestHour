using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class PossesedGuardBoss : Mob
    {
        public PossesedGuardBoss()
        {
            this.damageMin = 10;
            this.damageMax = 20;
            this.health = 110;
            this.maxHealth = 110;
            this.level = 1;
            this.gold = 75;
            this.xp = 150;
            this.Identifier = "Possesed Guard";
        }
    }
}
