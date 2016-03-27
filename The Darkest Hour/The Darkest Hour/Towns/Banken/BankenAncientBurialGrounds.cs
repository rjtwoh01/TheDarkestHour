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
using The_Darkest_Hour.Characters.Mobs.Bosses.Banken;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class BankenAncientBurialGrounds : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAncientBurialGrounds.Entrance";
        public const string DESECRATED_TOMB_STONES = "Banken.BankenAncientBurialGrounds.DesecratedTombStones";
        public const string SMALL_POND = "Banken.BankenAncientBurialGrounds.SmallPond";
        public const string WIDE_PATH = "Banken.BankenAncientBurialGrounds.WidePath";
        public const string DENSE_FOG = "Banken.BankenAncientBurialGrounds.DenseFog";
        public const string DESERTED_RITUAL_GROUNDS = "Banken.BankenAncientBurialGrounds.DesertedRitualGrounds";
        public const string DESECRATED_TOMB_STONES_SKELETONS = "Banken.BankenAncientBurialGrounds.DesecratedTombStonesSkeletons";
        public const string SMALL_POND_WATER_SPIRITS = "Banken.BankenAncientBurialGrounds.SmallPondWaterSpirits";
        public const string WIDE_PATH_SKELETONS = "Banken.BankenAncientBurialGrounds.WidePathSkeletons";
        public const string DENSE_FOG_SPIRITS = "Banken.BankenAncientBurialGrounds.DenseFogSpirits";
        public const string ACKHAN = "Banken.BankenAncientBurialGrounds.Ackhan";
        public const string TREASURE = "Banken.BankenAncientBurialGrounds.Treasure";

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
            returnData.Name = "Ancient Burial Grounds";
            returnData.Description = "The Ancient Burial Grounds reek of evil. A dark presence encloses your heart and you feel hope drain from your body. Proceed with caution.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesecratedTombStonesDefinition();
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
                returnData.Name = "Ancient Burial Grounds";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Desecrated Tomb Stones

        public Location LoadDesecratedTombStones()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Desecrated Tomb Stones";
            returnData.Description = "A small area of with several desecrated tomb stones scattered about. The ground is disturbed as if something has risen from it. There are skeletons wandering about.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetSmallPondDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDesecratedTombStonesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DESECRATED_TOMB_STONES;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Desecrated Tomb Stones";
                returnData.DoLoadLocation = LoadDesecratedTombStones;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Pond

        public Location LoadSmallPond()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Pond";
            returnData.Description = "A small pond is on the edge of the burial grounds. Several water spirits are pouring out of the pond, intent on attack.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesecratedTombStonesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetWidePathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSmallPondDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_POND;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Pond";
                returnData.DoLoadLocation = LoadSmallPond;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Wide Path

        public Location LoadWidePath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Wide Path";
            returnData.Description = "A wide path loops from the small pond deep into the heart of the ancient burial grounds. The path is patrolled by several strongly armed skeletons";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetSmallPondDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDenseFogDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWidePathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WIDE_PATH;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Wide Path";
                returnData.DoLoadLocation = LoadWidePath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dense Fog

        public Location LoadDenseFog()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dense Fog";
            returnData.Description = "At the end of the path lays a dense fog, clouding the air. The sacraficial ground lays on the other side but is blocked from sight. Evil Spirits are pouring out of the fog.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetWidePathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesertedRitualGroundsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDenseFogDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DENSE_FOG;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dense Fog";
                returnData.DoLoadLocation = LoadDenseFog;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Deserted Ritual Grounds

        public Location LoadDesertedRitualGrounds()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Deserted Ritual Grounds";
            returnData.Description = "On the other side of the dense fog is a circular arrea that used to be used as ritual grounds. The grounds have long since been abandoned. However, a new resident has taken up home here and is spewing dark magic into the lands. An evil necromancer, Ackhan, whom is part of the Necromancer Council stands in the middle of the circle chanting in some unknown tongue. Dark wisps leave his body and fly into the forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDenseFogDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDesertedRitualGroundsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DESERTED_RITUAL_GROUNDS;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Deserted Ritual Grounds";
                returnData.DoLoadLocation = LoadDesertedRitualGrounds;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAncientBurialGrounds _BankenAncientBurialGrounds;

        public static BankenAncientBurialGrounds GetTownInstance()
        {
            if (_BankenAncientBurialGrounds == null)
            {
                _BankenAncientBurialGrounds = new BankenAncientBurialGrounds();
            }

            return _BankenAncientBurialGrounds;
        }

        #endregion
    }
}
