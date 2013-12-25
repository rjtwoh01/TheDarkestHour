using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items_and_Inventory;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Bandit : Mob
    {
        public Bandit()
        {
            this.damageMin = 1;
            this.damageMax = 7;
            this.health = 40;
            this.maxHealth = 40;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            this.Identifier = "Bandit";
        }
    }
}
