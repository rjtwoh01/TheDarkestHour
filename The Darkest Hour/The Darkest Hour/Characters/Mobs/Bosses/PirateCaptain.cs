using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class PirateCaptain : Mob
    {
        public PirateCaptain()
        {
            this.damageMin = 75;
            this.damageMax = 100;
            this.health = 1100;
            this.maxHealth = 1100;
            this.level = 1;
            this.gold = 500;
            this.xp = 1550;
            this.Identifier = "Pirate Captain";
        }
    }
}
