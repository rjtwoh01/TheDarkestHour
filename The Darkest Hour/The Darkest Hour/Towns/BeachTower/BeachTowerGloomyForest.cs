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
    class BeachTowerGloomyForest : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerGloomyForest.Entrace";
        public const string FOREST_PATH_ONE_KEY = "BeachTower.BeachTowerGloomyForest.ForestPathOne";
        public const string FOREST_PATH_TWO_KEY = "BeachTower.BeachTowerGloomyForest.ForestPathTwo";
        public const string FOREST_PATH_THREE_KEY = "BeachTower.BeachTowerGloomyForest.ForestPathThree";
        public const string FOREST_PATH_FOUR_KEY = "BeachTower.BeachTowerGloomyForest.ForestPathFour";


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
            returnData.Name = "Gloomy Forest";
            returnData.Description = "A vast gloomy forest stretches out as far as the eyes can see. A sense of foreboding eats away at your innards as you gaze into the darkness ahead.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMysteriousHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathOneDefinition();
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
                returnData.Name = "Gloomy Forest";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path One

        public Location LoadForestPathOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Forest Path One";
            returnData.Description = "A long dark natural path that leads deep within the forest. It stretches on for as far as eyes can see.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();


            //Town Center
            LocationDefinition locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestPathOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Forest Path One";
                returnData.DoLoadLocation = LoadForestPathOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path Two

        public Location LoadForestPathTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Forest Path Two";
            returnData.Description = "A long dark natural path that leads deep within the forest. It stretches on for as far as eyes can see.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathOneDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestPathTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Forest Path Two";
                returnData.DoLoadLocation = LoadForestPathTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path Three

        public Location LoadForestPathThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Forest Path Three";
            returnData.Description = "A long dark natural path that leads deep within the forest. It stretches on for as far as eyes can see.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathFourDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestPathThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Forest Path Three";
                returnData.DoLoadLocation = LoadForestPathThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path Four

        public Location LoadForestPathFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Forest Path Four";
            returnData.Description = "A long dark natural path that leads deep within the forest. It stretches on for as far as eyes can see.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetForestPathFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Forest Path Four";
                returnData.DoLoadLocation = LoadForestPathFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerGloomyForest _BeachTowerGloomyForest;

        public static BeachTowerGloomyForest GetTownInstance()
        {
            if (_BeachTowerGloomyForest == null)
            {
                _BeachTowerGloomyForest = new BeachTowerGloomyForest();
            }

            return _BeachTowerGloomyForest;
        }

        #endregion
    }
}