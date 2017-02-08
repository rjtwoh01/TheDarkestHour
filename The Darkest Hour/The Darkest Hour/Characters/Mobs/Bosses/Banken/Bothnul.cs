using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class Bothnul : Mob
    {
        public Bothnul()
        {
            this.damageMin = 100;
            this.damageMax = 150;
            this.health = 1200;
            this.maxHealth = 1200;
            this.level = 1;
            this.gold = 650;
            this.xp = 650;
            this.Identifier = "Bothnul";
        }
    }
}
