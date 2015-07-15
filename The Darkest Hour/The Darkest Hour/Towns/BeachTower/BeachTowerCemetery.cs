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
    class BeachTowerCemetery : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerCemetery.Entrace";
        public const string OLD_GRAVES_KEY = "BeachTower.BeachTowerCemetery.OldGraves";
        public const string NEW_GRAVES_KEY = "BeachTower.BeachTowerCemetery.NewGraves";
        public const string CATACOMBS_KEY = "BeachTower.BeachTowerCemetery.Catacombs";

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
            returnData.Name = "Cemetery";
            returnData.Description = "A small cemetery within walking distance of the village. There is a foul stench in the air. You can feel that an evil presence is nearby but you cannot see anything suspicious.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCemetery.GetTownInstance().GetOldGravesDefinition();
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
                returnData.Name = "Cemetery";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Old Graves

        public Location LoadOldGraves()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Old Graves";
            returnData.Description = "These graves are ancient. The foul stench still feels faint.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCemetery.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCemetery.GetTownInstance().GetNewGravesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetOldGravesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = OLD_GRAVES_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Old Graves";
                returnData.DoLoadLocation = LoadOldGraves;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region New Graves

        public Location LoadNewGraves()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "New Graves";
            returnData.Description = "These graves are rather new. You wonder how many graves will be added to this section from the pirate raid. The foul stench grows stronger.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCemetery.GetTownInstance().GetOldGravesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCemetery.GetTownInstance().GetCatacombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetNewGravesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NEW_GRAVES_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "New Graves";
                returnData.DoLoadLocation = LoadNewGraves;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Catacombs

        public Location LoadCatacombs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Catacombs";
            returnData.Description = "There are several ancient catacombs in this section of the cemetery. The foul stench in the air is oppressing here. You can feel evil seeping into your bones.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCemetery.GetTownInstance().GetNewGravesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCatacombsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CATACOMBS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Catacombs";
                returnData.DoLoadLocation = LoadCatacombs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerCemetery _BeachTowerCemetery;

        public static BeachTowerCemetery GetTownInstance()
        {
            if (_BeachTowerCemetery == null)
            {
                _BeachTowerCemetery = new BeachTowerCemetery();
            }

            return _BeachTowerCemetery;
        }

        #endregion
    }
}
