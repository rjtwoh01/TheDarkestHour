using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class ScummyMurderer : Mob
    {
        public ScummyMurderer()
        {
            this.damageMin = 50;
            this.damageMax = 80;
            this.health = 1300;
            this.maxHealth = 1300;
            this.level = 1;
            this.gold = 275;
            this.xp = 800;
            this.Identifier = "Scummy Murderer";
        }
    }
}
