using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns.Watertown;

namespace The_Darkest_Hour.Locations.Actions
{
    class LoadSavedGameAction : LocationAction
    {
        public LoadSavedGameAction()
        {
            this.Name = "Load Saved Game";
            this.Description = "Load Saved Game";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            if (LoadSave.CheckForLoadSavedGame())
            {
                returnData = new Watertown().GetStartingLocation();
            }

            this.ClearScreen();

            return returnData;
        }

    }
}