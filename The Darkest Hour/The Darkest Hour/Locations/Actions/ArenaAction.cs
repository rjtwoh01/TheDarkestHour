using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Locations.Actions
{
    class ArenaAction : LocationAction
    {
        public ArenaAction()
        {
            this.Name = "Battle Monster";
            this.Description = "Battle Monster";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

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

            mob.Scale();
            Console.Clear();
            battle.DoBattle(GameState.Hero, mob);
            //Eventually going to remove this and have an option to rest
            //in the inn to reset your health. Otherwise you'll have to rely
            //on potions to reset your health
            GameState.Hero.ResetHealth();

            //Commented this out for a smoother experience. The battle code contains
            //a clear screen so there may be no need for double clear screen
            //will check to verify later
            //this.ClearScreen();

            return returnData;
        }

    }
}
