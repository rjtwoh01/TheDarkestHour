using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Towns;

namespace The_Darkest_Hour.Locations.Actions
{
    class CreateNewCharacterAction : LocationAction
    {
        public CreateNewCharacterAction()
        {
            this.Name = "Create New Character";
            this.Description = "Create New Character";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            GameState.Hero = new Player();
            GameState.Hero.Initialize();

            this.ClearScreen();

            returnData = GameState.StartingLocation;

            return returnData;
        }

    }
}