using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Combat;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class BankenAshenForest : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAshenForest.Entrace";
        public const string FOREST_PATH_START_KEY = "Banken.BankenAshenForest.ForestPathStart";
        public const string FOREST_WILDERNESS_KEY = "Banken.BankenAshenForest.ForestWilderness";
        public const string FOREST_PATH_WORSHIP_REGION_KEY = "Banken.BankenAshenForest.ForestPathWorshipRegion";
        public const string FOREST_NORTHERN_PATH_ONE_KEY = "Banken.BankenAshenForest.NorthernPathOneKEY";
        public const string NORTHERN_PATH_TWO_KEY = "Banken.BankenAshenForest.NorthernPathTwoKey";
        public const string NORTHERN_PATH_THREE_KEY = "Banken.BankenAshenForest.NorthernPathThreeKey";
        public const string LOOK_FOR_BURIAL_GROUNDS = "Banken.BankenAshenForest.LookForBurialGrounds";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entrance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest";
            returnData.Description = "The Ashen Forest is a grey forest, full of a life of darkness and light. The whole area feels as if it can birth evil at any moment.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEntranceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path Start

        public Location LoadForestPathStart()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Path Beginning";
            returnData.Description = "The beginning of the Path in the Ashen Forest stems from one of the makeshift roads through Banken. It goes deep within the forest for miles, forking and turning unexpectedly. It is easy to get lost on.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetForestWildernessDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment rescueRangers = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Rescue Rangers"));
            if (GameState.Hero.Accomplishments.Contains(rescueRangers))
            {
                locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            Accomplishment burialGrounds = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Ancient Burial Grounds"));
            if (GameState.Hero.Accomplishments.Contains(burialGrounds))
            {
                locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathOneDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetForestPathStartDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_START_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Path Beginning";
                returnData.DoLoadLocation = LoadForestPathStart;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Wilderness

        public Location LoadForestWilderness()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Wilderness";
            returnData.Description = "The path forks off, the left side leading to the wilderness. The area is thick with trees both dead and alive. There is an eviling feeling in the air. You should turn back now.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment shadeLord = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Shade Lord"));
            if (GameState.Hero.Accomplishments.Contains(shadeLord))
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestWildernessDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_WILDERNESS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Wilderness";
                returnData.DoLoadLocation = LoadForestWilderness;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Northren Path One

        public Location LoadNorthenPathOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Path One";
            returnData.Description = "The path leads north, deep into the forest. The air feels fouler the further you go.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNorthernPathOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_NORTHERN_PATH_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northern Path One";
                returnData.DoLoadLocation = LoadNorthenPathOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Northren Path Two

        public Location LoadNorthernPathTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Path Two";
            returnData.Description = "The path leads north, deep into the forest. The air feels fouler the further you go.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNorthernPathTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_PATH_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northen Path Two";
                returnData.DoLoadLocation = LoadNorthernPathTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Northren Path Three

        public Location LoadNorthernPathThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Path Three";
            bool lookForBurialGrounds = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForest.LOOK_FOR_BURIAL_GROUNDS));
            returnData.Description = "The path leads north, deep into the forest. The air feels at its foulest here. The Ancient Burial Grounds must be near.";

            if (!lookForBurialGrounds)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                locationActions = new List<LocationAction>();
                TakeItemAction lookActiopn = new TakeItemAction("Look for ", "the Ancient Burial Grounds", "You search desparately for the Ancient Burial Grounds. The darkness closes in around your heart the further north you go. Eventually you stumble upon their location");
                locationActions.Add(lookActiopn);
                lookActiopn.PostItem += LookForBurialGrounds;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (lookForBurialGrounds)
            {
                locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            locationDefinition = OldForestRuins.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LookForBurialGrounds(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForest.LOOK_FOR_BURIAL_GROUNDS, true);

                //Reload
                LocationHandler.ResetLocation(NORTHERN_PATH_THREE_KEY);
            }
        }

        public LocationDefinition GetNorthernPathThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_PATH_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northen Path Three";
                returnData.DoLoadLocation = LoadNorthernPathThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        
        //#region Forest Path Worship Region

        //public Location LoadForestPathWorshipRegion()
        //{
        //    Location returnData;
        //    returnData = new Location();
        //    returnData.Name = "Ashen Forest Path - Worship Region";
        //    returnData.Description = "You enter the worship region of the Ashen Forest. Many people travel here to pay homage in some kind to whatever Gods they believe in. This is ancient ground, that some believe used to be holy. But now, a dark presence is defiling it. Faint, but there none-the-less.";

        //    //Adjacent Locations
        //    Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

        //    //Town Center
        //    LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
        //    adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

        //    returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

        //    return returnData;
        //}

        //public LocationDefinition GetForestPathWorshipRegionDefinition()
        //{
        //    LocationDefinition returnData = new LocationDefinition();
        //    string locationKey = FOREST_PATH_WORSHIP_REGION_KEY;

        //    if (LocationHandler.LocationExists(locationKey))
        //    {
        //        returnData = LocationHandler.GetLocation(locationKey);
        //    }
        //    else
        //    {
        //        returnData.LocationKey = locationKey;
        //        returnData.Name = "Ashen Forest Path - Worship Region";
        //        returnData.DoLoadLocation = LoadForestPathWorshipRegion;

        //        LocationHandler.AddLocation(returnData);
        //    }

        //    return returnData;
        //}

        //#endregion

        #endregion

        #region Get Town Instance

        private static BankenAshenForest _BankenAshenForest;

        public static BankenAshenForest GetTownInstance()
        {
            if (_BankenAshenForest == null)
            {
                _BankenAshenForest = new BankenAshenForest();
            }

            return _BankenAshenForest;
        }

        #endregion
    }
}
