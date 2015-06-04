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
