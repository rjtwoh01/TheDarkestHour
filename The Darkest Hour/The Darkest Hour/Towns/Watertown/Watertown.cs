using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Towns.Watertown
{
    class Watertown : Town
    {

        #region Instance Properties and Methods
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

                locationAction = new MainMenuAction();
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

        // TODO: Probably should change the design of the GetTownCenter, etc..
        // to public Get properties as this is exactly how they are operating.
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

                locationAction = new MainMenuAction();
                locationActions.Add(locationAction);

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetArena());
                adjacentLocations.Add(GetInn());
                // TODO: Will eventually check to see if they have heard the Sewer King rumor.
                // And then only display the sewer entrance.
                adjacentLocations.Add(WatertownSewer.GetTownInstance().GetStartingLocation());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _TownCenter;
            }


            return returnData;
        }

        #endregion

        #region Static Properties and Methods
        private static WatertownAccomplishments _WatertownAccomplishments;

        public static WatertownAccomplishments GetWatertownAccomplishments()
        {
            if (_WatertownAccomplishments != null)
            {
                _WatertownAccomplishments = new WatertownAccomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Sewer King Rumor";
                accomplishment.Description = "Has heard the rumor of the sewer king.   Tales of gold and rewards in the Watertown sewer.";
            }

            return _WatertownAccomplishments;
        }

        private static Watertown _Watertown;

        public static Watertown GetTownInstance()
        {
            if (_Watertown == null)
            {
                _Watertown = new Watertown();
            }

            return _Watertown;
        }
        #endregion
    }
}
