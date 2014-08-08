using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Mobs.Bosses
{
    class AttackCoordinator : Mob
    {
        public AttackCoordinator()
        {
            this.damageMin = 50;
            this.damageMax = 80;
            this.health = 925;
            this.maxHealth = 925;
            this.level = 1;
            this.gold = 150;
            this.xp = 1350;
            this.Identifier = "Attack Coordinator";
        }
    }
}
