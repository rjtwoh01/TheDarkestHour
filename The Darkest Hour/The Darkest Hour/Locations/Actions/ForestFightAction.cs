using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Locations.Actions
{
    class ForestFightAction : LocationAction
    {
        public ForestFightAction()
        {
            this.Name = "Fight Bandits";
            this.Description = "Fight Bandits";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            Battle battle = new Battle();
            Mob mob = new Bandit();
            Console.Clear();
            for (int i = 0; i <= 4; i++)
            {
                battle.DoBattle(GameState.Hero, mob);
            }

            GameState.Hero.CanMove = true;
            
            return returnData;
        }
    }
}
