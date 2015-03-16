using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Spies : Mob
    {
        public Spies()
        {
            this.damageMin = 3;
            this.damageMax = 10;
            this.health = 50;
            this.maxHealth = 50;
            this.level = 1;
            this.gold = 5;
            this.xp = 25;
            this.Identifier = "Spy";
        }
    }
}
