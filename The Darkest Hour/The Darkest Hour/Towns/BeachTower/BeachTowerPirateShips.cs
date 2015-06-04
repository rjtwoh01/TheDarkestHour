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
    class BeachTowerPirateShips : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerPirateShips.Entrace";
        public const string SHIP_ONE_KEY = "BeachTower.BeachTowerPirateShips.ShipOne";
        public const string SHIP_TWO_KEY = "BeachTower.BeachTowerPirateShips.ShipTwo";
        public const string SHIP_THREE_KEY = "BeachTower.BeachTowerPirateShips.ShipThree";
        public const string SHIP_FOUR_KEY = "BeachTower.BeachTowerPirateShips.ShipFour";
        public const string FLEET_MASTERS_SHIP_KEY = "BeachTower.BeachTowerPirateShips.FleetMastersShip";
        public const string SHIP_ONE_MOBS = "BeachTower.BeachTowerPirateShips.ShipOneMobs";
        public const string SHIP_TWO_MOBS = "BeachTower.BeachTowerPirateShips.ShipTwoMobs";
        public const string SHIP_THREE_MOBS = "BeachTower.BeachTowerPirateShips.ShipThreeMobs";
        public const string SHIP_FOUR_MOBS = "BeachTower.BeachTowerPirateShips.ShipFourMobs";
        public const string FLEET_MASTER = "BeachTower.BeachTowerPirateShips.PirateFleetMaster";

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
            returnData.Name = "Boat to Pirate Ships";
            returnData.Description = "A small boat on the shoreline meant to take you to the pirate ships hanging out near the shore.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBeachHead.GetTownInstance().GetWestTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipOneDefinition();
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
                returnData.Name = "Boat to Pirate Ships";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ship One

        public Location LoadShipOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Pirate Ship One";
            returnData.Description = "A large ship full of pirates and food.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerPirateShips.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetShipOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SHIP_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Pirate Ship One";
                returnData.DoLoadLocation = LoadShipOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ship Two

        public Location LoadShipTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Pirate Ship Two";
            returnData.Description = "A large ship full of pirates and arms.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipOneDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetShipTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SHIP_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Pirate Ship Two";
                returnData.DoLoadLocation = LoadShipTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ship Three

        public Location LoadShipThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Pirate Ship Three";
            returnData.Description = "A large ship full of pirate slave masters and slaves.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipFourDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetShipThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SHIP_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Pirate Ship Three";
                returnData.DoLoadLocation = LoadShipThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ship Four

        public Location LoadShipFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Pirate Ship Four";
            returnData.Description = "A large ship full of the pirate's elite raiders";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerPirateShips.GetTownInstance().GetPirateFleetMastersShipDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetShipFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SHIP_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Pirate Ship Four";
                returnData.DoLoadLocation = LoadShipFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Pirate Fleet Master's Ship

        public Location LoadPirateFleetMastersShip()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Pirate Fleet Master's Ship";
            returnData.Description = "A large ship belonging to the pirate fleet master. He is standing at the bridge of the ship with one hand on the wheel, observing the shore.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerPirateShips.GetTownInstance().GetShipFourDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetPirateFleetMastersShipDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FLEET_MASTERS_SHIP_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Pirate Fleet Master's Ship";
                returnData.DoLoadLocation = LoadPirateFleetMastersShip;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerPirateShips _BeachTowerPirateShips;

        public static BeachTowerPirateShips GetTownInstance()
        {
            if (_BeachTowerPirateShips == null)
            {
                _BeachTowerPirateShips = new BeachTowerPirateShips();
            }

            return _BeachTowerPirateShips;
        }

        #endregion
    }
}
