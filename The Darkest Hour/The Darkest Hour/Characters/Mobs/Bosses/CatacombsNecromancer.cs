using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class CatacombsNecromancer : Mob
    {
        public CatacombsNecromancer()
        {
            this.damageMin = 110;
            this.damageMax = 170;
            this.health = 1350;
            this.maxHealth = 1350;
            this.level = 1;
            this.gold = 1350;
            this.xp = 1850;
            this.Identifier = "Catacombs Necromancer";
        }
    }
}
