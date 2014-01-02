using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownForest : Town
    {
        public bool ClearedPath = false;

        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForest.Entrance";
        public const string SIDE_AREA_KEY = "WatertownForest.Side";
        public const string STRAIGHT_AHEAD_KEY = "WatertownForest.Straight";
        public const string CLEARING_KEY = "WatertownForest.Clearing";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetForestEntranceDefinition();
        }

        public Location LoadSideArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Watertown Forest Side Area";
            returnData.Description = "You move off to a little side area you saw. There is nothing here but more trees.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetStartingLocationDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public Location LoadStraight()
        {
            Location returnData = new Location();
            returnData.Name = "Watertown Forest Straight Path";
            if (!GameState.Hero.CanMove)
                returnData.Description = "You walk forward on the path and encounter bandits. You must conquer them to move on";
            else
                returnData.Description = "The dead bodies of bandits lay strewn across the ground.";

            LocationAction locationAction;
            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!GameState.Hero.CanMove)
            {
                locationAction = new ForestFightAction();
                locationActions.Add(locationAction);
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetForestEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (GameState.Hero.CanMove)
            {
                locationDefinition = WatertownForest.GetTownInstance().GetClearingDefinition();
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public Location LoadClearing()
        {
            Location returnData = new Location();
            returnData.Name = "Watertown Forest Clearing";
            if (!GameState.Hero.CanMoveTwo)
            {
                returnData.Description = "The Bandit Captain stands in the clearing and stares at you, daring you to challenge him. \nYou can't fight him yet. He is not implemented into the game";
            }
            else
                returnData.Description = "The Bandit Captain lays dead in the clearing";

            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetStraightDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (GameState.Hero.CanMoveTwo)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }


        public Location LoadForestEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Watertown Forest Entrance";
            returnData.Description = "A dense yet surprisingly bright forest. You can hear the laughter of the bandits off in the distance";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForest.GetTownInstance().GetSideAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForest.GetTownInstance().GetStraightDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }


        public LocationDefinition GetSideAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SIDE_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Side Area";
                returnData.DoLoadLocation = LoadSideArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public LocationDefinition GetStraightDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_AHEAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Straight Path";
                returnData.DoLoadLocation = LoadStraight;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public LocationDefinition GetClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Clearing";
                returnData.DoLoadLocation = LoadClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public LocationDefinition GetForestEntranceDefinition()
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
                returnData.Name = "Watertown Forest Entrance";
                returnData.DoLoadLocation = LoadForestEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Get Town Entrance

        private static WatertownForest _WatertownForest;

        public static WatertownForest GetTownInstance()
        {
            if (_WatertownForest == null)
            {
                _WatertownForest = new WatertownForest();
            }

            return _WatertownForest;
        }

        #endregion

    }
}
