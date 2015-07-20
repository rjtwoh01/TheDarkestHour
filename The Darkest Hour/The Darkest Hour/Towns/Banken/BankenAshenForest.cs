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
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetForestWildernessDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathWorshipRegionDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

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

        #region Forest Path Worship Region

        public Location LoadForestPathWorshipRegion()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ashen Forest Path - Worship Region";
            returnData.Description = "You enter the worship region of the Ashen Forest. Many people travel here to pay homage in some kind to whatever Gods they believe in. This is ancient ground, that some believe used to be holy. But now, a dark presence is defiling it. Faint, but there none-the-less.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestPathWorshipRegionDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_WORSHIP_REGION_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ashen Forest Path - Worship Region";
                returnData.DoLoadLocation = LoadForestPathWorshipRegion;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAshenForest _BeachTownScoutingParty;

        public static BankenAshenForest GetTownInstance()
        {
            if (_BeachTownScoutingParty == null)
            {
                _BeachTownScoutingParty = new BankenAshenForest();
            }

            return _BeachTownScoutingParty;
        }

        #endregion
    }
}
