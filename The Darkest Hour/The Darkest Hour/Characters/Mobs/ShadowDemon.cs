using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class ShadowDemon : Mob
    {
        public ShadowDemon()
        {
            this.damageMin = 8;
            this.damageMax = 15;
            this.health = 110;
            this.maxHealth = 110;
            this.level = 1;
            this.gold = 25;
            this.xp = 25;
            this.Identifier = "Shadow Demon";
        }
    }
}
