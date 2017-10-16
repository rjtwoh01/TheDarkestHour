using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Mercanary : Mob
    {
        public Mercanary()
        {
            this.damageMin = 5;
            this.damageMax = 15;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            this.Identifier = "Mercanary";
        }
    }
}
