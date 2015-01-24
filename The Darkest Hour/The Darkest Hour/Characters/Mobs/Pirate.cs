using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Pirate : Mob
    {
        public Pirate()
        {
            this.damageMin = 4;
            this.damageMax = 10;
            this.health = 60;
            this.maxHealth = 60;
            this.level = 1;
            this.gold = 5;
            this.xp = 25;
            this.Identifier = "Pirate";
        }
    }
}
