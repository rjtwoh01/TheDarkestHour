using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs
{
    class EvilSpirit : Mob
    {
        public EvilSpirit()
        {
            this.damageMin = 6;
            this.damageMax = 12;
            this.health = 100;
            this.maxHealth = 100;
            this.level = 1;
            this.gold = 25;
            this.xp = 25;
            this.Identifier = "Evil Spirit";
        }
    }
}
