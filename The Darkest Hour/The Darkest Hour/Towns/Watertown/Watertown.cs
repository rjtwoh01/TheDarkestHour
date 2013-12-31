using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class Watertown : Town
    {
        private Location _Arena;
        private Location _TownCenter;
        private Location _Inn;

        public override Location GetStartingLocation()
        {
            return GetTownCenter();
        }

        public Location GetArena()
        {
            Location returnData;

            if (_Arena == null)
            {

                returnData = new Location();
                returnData.Name = "Watertown Arena";
                returnData.Description = "Prepare to Die!";

                _Arena = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                LocationAction locationAction = new ArenaAction();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;


                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _Arena;
            }

            return returnData;
        }

        public Location GetInn()
        {
            Location returnData;

            if (_Inn == null)
            {

                returnData = new Location();
                returnData.Name = "Prancing Pony";
                returnData.Description = "You belly up to the bar!";

                _Inn = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                LocationAction locationAction = new SaveAction();
                locationActions.Add(locationAction);

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _Arena;
            }

            return returnData;
        }


        public Location GetTownCenter()
        {
            Location returnData;
            LocationAction locationAction;

            if (_TownCenter == null)
            {

                returnData = new Location();
                returnData.Name = "Watertown Town Center";
                returnData.Description = "Welcome to the cozy Watertown Town Center.";

                _TownCenter = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                locationAction = new DisplayStatsAction();
                locationActions.Add(locationAction);

                locationAction = new DisplayInventoryAction();
                locationActions.Add(locationAction);

                locationAction = new SellItemsAction();
                locationActions.Add(locationAction);

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetArena());
                adjacentLocations.Add(GetInn());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _TownCenter;
            }


            return returnData;
        }
    }
}
