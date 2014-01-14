using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters
{
    public class Mob : Character
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

        public void Scale()
        {
            if (this.level > 1)
            {
                this.level = GameState.Hero.level;
                this.health = this.health + (this.level * 2);
                this.maxHealth = this.maxHealth + (this.level * 2);
                this.damageMin = this.damageMin + (this.level * 2);
                this.damageMax = this.damageMax + (this.level * 2);
                this.gold = this.gold + (this.level / 2);
                this.xp = this.xp + (this.level / 2);
            }
        }
    }
}