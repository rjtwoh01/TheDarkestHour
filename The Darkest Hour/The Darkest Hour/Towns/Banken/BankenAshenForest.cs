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
        public const string NORTHERN_PATH_THREE_KEY = "Banken.BankenAshenForest.NorthernPathThree";
        public const string NORTHERN_PATH_FOUR_KEY = "Banken.BankenAshenForest.NorthernPathFour";
        public const string NORTHERN_PATH_FIVE_KEY = "Banken.BankenAshenForest.NorthernPathFive";
        public const string NORTHERN_FOREST_EDGE_KEY = "Banken.BankenAshenForest.NorthernForestEdgeKey";
        public const string LOOK_FOR_BURIAL_GROUNDS = "Banken.BankenAshenForest.LookForBurialGrounds";
        public const string EASTERN_PATH_ONE_KEY = "Banken.BankenAshenForest.EasternPathOne";
        public const string EASTERN_PATH_TWO_KEY = "Banken.BankenAshenForest.EasternPathTwo";
        public const string EASTERN_PATH_THREE_KEY = "Banken.BankenAshenForest.EasternPathThree";
        public const string EASTERN_FOREST_EDGE_KEY = "Banken.BankenAshenForest.EasternForestEdge";


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

            Accomplishment banditCamp = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Bandit Camp"));
            if (GameState.Hero.Accomplishments.Contains(banditCamp))
            {
                locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathOneDefinition();
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

        #region Northern Path

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

            Accomplishment oldForestRuins = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Old Forest Ruins"));
            if (GameState.Hero.Accomplishments.Contains(oldForestRuins))
            {
                locationDefinition = BankenOldForestRuins.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            Accomplishment inconspiciousCave = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Inconspicious Cave"));
            if (GameState.Hero.Accomplishments.Contains(inconspiciousCave))
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathFourDefinition();
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

        #region Northern Part Four
        public Location LoadNorthernPathFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Path Four";
            returnData.Description = "The path leads north, deep into the forest. The air is lighter now";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNorthernPathFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_PATH_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northen Path Four";
                returnData.DoLoadLocation = LoadNorthernPathFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion
        
        #region Northern Part Five
        public Location LoadNorthernPathFive()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Path Five";
            returnData.Description = "The path leads north, deep into the forest. The air is significantly lighter here.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernForestEdgeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNorthernPathFiveDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_PATH_FIVE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northen Path Five";
                returnData.DoLoadLocation = LoadNorthernPathFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Northern Forest Edge
        public Location LoadNorthernForestEdge()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Northern Forest Edge";
            returnData.Description = "The Northen Edge of the Ashen Forest. The air is light and clean, far away from ancient evils now.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment swampland = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Swampland"));
            if (GameState.Hero.Accomplishments.Contains(swampland))
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNorthernForestEdgeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_FOREST_EDGE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Northen Forest Edge";
                returnData.DoLoadLocation = LoadNorthernForestEdge;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Eastern Path

        #region Eastern Forest Path One
        public Location LoadEasternForestPathOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Eastern Forest Path One";
            returnData.Description = "The path turns east and goes deep into the forest";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetEasternForestPathOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_PATH_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Eastern Forest Path One";
                returnData.DoLoadLocation = LoadEasternForestPathOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eastern Forest Path Two
        public Location LoadEasternForestPathTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Eastern Forest Path Two";
            returnData.Description = "The Forest Path continues east. The trees are thick but the air feels clean and calm";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetEasternForestPathTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_PATH_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Eastern Forest Path Two";
                returnData.DoLoadLocation = LoadEasternForestPathTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eastern Forest Path Three
        public Location LoadEasternForestPathThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Eastern Forest Path Three";
            returnData.Description = "The Forest Path continues east. The trees have thinned out. The edge of the forest can be seen not that far ahead";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestEdgeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetEasternForestPathThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_PATH_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Eastern Forest Path Three";
                returnData.DoLoadLocation = LoadEasternForestPathThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eastern Forest Edge
        public Location LoadEasternForestEdge()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Eastern Forest Edge";
            returnData.Description = "The Ashen Forest has ended. There are mountains a little further East. The road continues on, leading through the mountains toward Asku's east coast.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestPathThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment banditCamp = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Bandit Camp"));
            if (GameState.Hero.Accomplishments.Contains(banditCamp))
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetEasternForestEdgeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_FOREST_EDGE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Eastern Forest Edge";
                returnData.DoLoadLocation = LoadEasternForestEdge;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

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
