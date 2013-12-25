using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters
{
    class Mob : Character
    {
        Random rand = new Random();

        public int GetDamage(Mob mob)
        {
            int damage;
            damage = rand.Next(damageMin, (damageMax + 1));
            return damage;
        }

        public int GetMagic()
        {
            int magic;
            magic = rand.Next(magicMin, (magicMax + 1));
            return magic;
        }

        public int ResetHealth(Mob mob)
        {
            health = maxHealth;
            return health;
        }
    }
}