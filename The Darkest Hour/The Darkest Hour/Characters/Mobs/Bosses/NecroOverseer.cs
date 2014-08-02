using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class NecroOverseer : Mob
    {
        public NecroOverseer()
        {
            this.damageMin = 45;
            this.damageMax = 65;
            this.health = 1050;
            this.maxHealth = 1050;
            this.level = 1;
            this.gold = 500;
            this.xp = 1250;
            this.Identifier = "Necromancer Overseer";
        }
    }
}
