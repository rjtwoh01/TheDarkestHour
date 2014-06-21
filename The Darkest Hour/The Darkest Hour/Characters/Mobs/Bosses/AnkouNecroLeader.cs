using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class AnkouNecroLeader : Mob
    {
        public AnkouNecroLeader()
        {
            this.damageMin = 85;
            this.damageMax = 100;
            this.health = 60;
            this.maxHealth = 60;
            this.level = 1;
            this.gold = 250;
            this.xp = 250;
            this.Identifier = "Necromancer Leader";
        }
    }
}
