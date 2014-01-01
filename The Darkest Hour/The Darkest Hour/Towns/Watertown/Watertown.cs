﻿using System;
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
        #region Location Keys

        public const string ARENA_KEY = "Watertown.Arena";
        public const string TOWN_CENTER_KEY = "Watertown.TownCenter";
        public const string INN_KEY = "Watertown.Inn";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetTownCenterDefinition();
        }

        public Location LoadArena()
        {
            Location returnData;
            LocationAction locationAction;

            returnData = new Location();
            returnData.Name = "Watertown Arena";
            returnData.Description = "Prepare to Die!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            locationAction = new ArenaAction();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationKeys = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationKeys = adjacentLocationKeys;

            /*
            List<Location> adjacentLocations = new List<Location>();

            adjacentLocations.Add(GetTownCenter());

            returnData.AdjacentLocations = adjacentLocations;                 
            */

            return returnData;
        }


        public LocationDefinition GetArenaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARENA_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Arena";
                returnData.DoLoadLocation = LoadArena;

                Location.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadInn()
        {
            Location returnData;


            returnData = new Location();
            returnData.Name = "Prancing Pony";
            returnData.Description = "You belly up to the bar!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction = new RumorAction("Bartender", this.InnKeepersRumors);
            locationActions.Add(locationAction);


            locationAction = new SaveAction();
            locationActions.Add(locationAction);

            locationAction = new MainMenuAction();
            locationActions.Add(locationAction);

            locationAction = new ExitGame();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationKeys = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationKeys = adjacentLocationKeys;

            /*
            List<Location> adjacentLocations = new List<Location>();

            adjacentLocations.Add(GetTownCenter());

            returnData.AdjacentLocations = adjacentLocations;
            */

            return returnData;
        }


        public LocationDefinition GetInnDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = INN_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Prancing Pony";
                returnData.DoLoadLocation = LoadInn;

                Location.AddLocation(returnData);
            }

            return returnData;


        }

        public Location LoadTownCenter()
        {
            Location returnData;
            LocationAction locationAction;


            returnData = new Location();
            returnData.Name = "Watertown Town Center";
            returnData.Description = "Welcome to the cozy Watertown Town Center.";

            // Location Actions
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



            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationKeys = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetArenaDefinition();
            adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = GetInnDefinition();
            adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationKeys = adjacentLocationKeys;
                        
            Accomplishment sewerKingAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            if (GameState.Hero.Accomplishments.Contains(sewerKingAccomplishment))
            {
                locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceDefinition();
                adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);
            }


            /*
            List<Location> adjacentLocations = new List<Location>();

            adjacentLocations.Add(GetArena());
            adjacentLocations.Add(GetInn());

            Accomplishment sewerKingAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            if (GameState.Hero.Accomplishments.Contains(sewerKingAccomplishment))
            {
                adjacentLocations.Add(WatertownSewer.GetTownInstance().GetStartingLocation());
            }

            returnData.AdjacentLocations = adjacentLocations;
            */

            return returnData;
        }


        // TODO: Probably should change the design of the GetTownCenter, etc..
        // to public Get properties as this is exactly how they are operating.
        public LocationDefinition GetTownCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_CENTER_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

                Location.AddLocation(returnData);
            }

            return returnData;
        }      

        #endregion

        #region Rumors

        private List<Rumor> _InnKeepersRumors;

        private List<Rumor> InnKeepersRumors
        {
            get
            {
                if (_InnKeepersRumors == null)
                {
                    _InnKeepersRumors = new List<Rumor>();

                    Rumor rumor = new Rumor("Sewer King", "There are tales of a Sewer King with hoards of riches and gold.  The entrance to the sewers can be found in the Town Center.");
                    rumor.Accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
                    rumor.OnHeardRumor += this.HeardSewerKingRumor;
                    _InnKeepersRumors.Add(rumor);
                    _InnKeepersRumors.Add(new Rumor("Not Much", "Not much happening around here these days."));
                    _InnKeepersRumors.Add(new Rumor("Stay awhile", "Stay a while and listen to our bard play music and sing songs of great tales."));
                }

                return _InnKeepersRumors;
            }
        }


        public void HeardSewerKingRumor()
        {
            // TODO: need to keep duplicate accomplishments from happening.
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the sewer
            Location.ResetLocation(TOWN_CENTER_KEY);

            // TODO: this is not working.  Currently, you need to save your character and reload the game for this to work
            // So, just need to handle the memory management a little better so I can easily flush out a cached location.
            //_TownCenter = null;
            //_TownCenter = GetTownCenter();
        }


        #endregion

        #region Accomplishments
        private static WatertownAccomplishments _WatertownAccomplishments;

        public static WatertownAccomplishments GetWatertownAccomplishments()
        {
            if (_WatertownAccomplishments == null)
            {
                _WatertownAccomplishments = new WatertownAccomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Sewer King Rumor";
                accomplishment.Description = "Has heard the rumor of the sewer king.   Tales of gold and rewards in the Watertown sewer.";
                _WatertownAccomplishments.Add(accomplishment);

                // TODO: Can add more accomplishments here;
            }

            return _WatertownAccomplishments;
        }

#endregion

        #region Get Town Instance

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
