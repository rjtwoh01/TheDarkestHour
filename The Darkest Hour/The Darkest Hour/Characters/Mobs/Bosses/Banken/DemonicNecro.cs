using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses.Banken
{
    class DemonicNecro : Mob
    {
        public DemonicNecro()
        {
            this.damageMin = 150;
            this.damageMax = 210;
            this.health = 1650;
            this.maxHealth = 1650;
            this.level = 1;
            this.gold = 1650;
            this.xp = 2150;
            this.Identifier = "Demonic Necromancer";
        }
    }
}