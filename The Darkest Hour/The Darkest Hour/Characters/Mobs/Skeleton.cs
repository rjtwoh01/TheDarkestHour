using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Characters.Mobs
{
    class Skeleton : Mob
    {
        public Skeleton()
        {
            this.damageMin = 1;
            this.damageMax = 5;
            this.health = 50;
            this.maxHealth = 50;
            this.level = 1;
            this.gold = 1;
            this.xp = 25;
            Identifier = "Skeleton";
        }
    }
}
