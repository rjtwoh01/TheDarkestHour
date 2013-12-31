using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownSewer : Town
    {
        private Location _SewerEntrance;

        public override Location GetStartingLocation()
        {
            return GetSewerEntrance();
        }

        public Location GetSewerEntrance()
        {
            Location returnData;

            if (_SewerEntrance == null)
            {

                returnData = new Location();
                returnData.Name = "Watertown Sewer Entrance";
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. (no actions yet)";

                _SewerEntrance = returnData;

                /*
                List<LocationAction> locationActions = new List<LocationAction>();


                LocationAction locationAction = new ExitGame();
                locationActions.Add(locationAction);                 

                returnData.Actions = locationActions;
                */

                List<Location> adjacentLocations = new List<Location>();
                Watertown watertown = Watertown.GetTownInstance();
                adjacentLocations.Add(watertown.GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;
            }
            else
            {
                returnData = _SewerEntrance;
            }


            return returnData;
        }


        private static WatertownSewer _WatertownSewer;

        public static WatertownSewer GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownSewer();
            }

            return _WatertownSewer;
        }
    }
}
