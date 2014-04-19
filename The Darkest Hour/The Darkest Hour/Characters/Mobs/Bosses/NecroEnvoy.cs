using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class NecroEnvoy : Mob
    {
        public NecroEnvoy()
        {
            this.damageMin = 40;
            this.damageMax = 65;
            this.health = 400;
            this.maxHealth = 400;
            this.level = 1;
            this.gold = 200;
            this.xp = 250;
            this.Identifier = "Necromancer Envoy";
        }
    }
}
