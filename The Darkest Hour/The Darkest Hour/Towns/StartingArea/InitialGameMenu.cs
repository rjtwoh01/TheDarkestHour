using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.StartingArea
{
    class InitialGameMenu : Town
    {
        private Location _LoadSaveGameMenu;

        public override Location GetStartingLocation()
        {
            return GetLoadSaveGameMenu();
        }



        public Location GetLoadSaveGameMenu()
        {
            Location returnData;
            LocationAction locationAction;

            if (_LoadSaveGameMenu == null)
            {

                returnData = new Location();
                returnData.Name = "Game Menu";
                returnData.Description = "Please choose an initial starting action.";

                _LoadSaveGameMenu = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                locationAction = new CreateNewCharacterAction();
                locationActions.Add(locationAction);

                if (LoadSave.SavedGameExists())
                {
                    locationAction = new LoadSavedGameAction();
                    locationActions.Add(locationAction);
                }

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

            }
            else
            {
                returnData = _LoadSaveGameMenu;
            }


            return returnData;
        }
    }
}
