using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Locations.Actions
{
    class ArenaAction : LocationAction
    {
        public ArenaAction()
        {
            this.Name = "Arena";
            this.Description = "Arena";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            Battle battle = new Battle();
            Mob mob;
            Random rand = new Random();
            int temp = 0;

            temp = rand.Next(1, 3);
            if (temp == 1)
            {
                mob = new Skeleton();
            }
            else
            {
                mob = new Bandit();
            }

            Console.Clear();
            battle.DoBattle(GameState.Hero, mob);
            GameState.Hero.ResetHealth();

            this.ClearScreen();

            return returnData;
        }

    }
}
