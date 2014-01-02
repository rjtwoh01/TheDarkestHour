using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;

namespace The_Darkest_Hour.Locations.Actions
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Could probably make a generic Combat Action passing in a collection
    /// of mobs to fight.  (see rumor action as an example).
    /// Also.  Need a way to pass back if all of the MOBs were defeated or 
    /// not.
    /// </remarks>
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
