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
    class OldForestRuins : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.OldForestRuins.Entrance";
        public const string MAIN_ROAD_KEY = "Banken.OldForestRuins.MainRoad";
        public const string TOWN_CENTER_KEY = "Banken.OldForestRuins.TownCenter";
        public const string INN_KEY = "Banken.OldForestRuins.Inn";
        public const string LOCKED_HOUSE_KEY = "Banken.OldForestRuins.LockedHouse";
        public const string TOWN_HALL_KEY = "Banken.OldForestRuins.TownHall";

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
            returnData.Name = "Old Forest Ruins";
            returnData.Description = "Ruins of an old town, overcome by the forest. Vines are growing on buildings that have long since crumpled to the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = OldForestRuins.GetTownInstance().GetMainRoadDefinition();
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
                returnData.Name = "Old Forest Ruins";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Main Road

        public Location LoadMainRoad()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Main Road";
            returnData.Description = "This is the main run that used to connect the city to the outside world. Now the stones are covered in overgrown moss and several are broken. Bandits walk this road.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = OldForestRuins.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = OldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMainRoadDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MAIN_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Main Road";
                returnData.DoLoadLocation = LoadMainRoad;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Center

        public Location LoadTownCenter()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Center";
            returnData.Description = "What used to be the town center now lays in ruins. It appears to have once been a nice, charming place. Now the air that circles it reeks of death and decay.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = OldForestRuins.GetTownInstance().GetMainRoadDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = OldForestRuins.GetTownInstance().GetInnDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = OldForestRuins.GetTownInstance().GetLockedHouseDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = OldForestRuins.GetTownInstance().GetTownHallDefiniton();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTownCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_CENTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Inn

        public Location LoadInn()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Inn";
            returnData.Description = "This inn used to be nice and cozy. Now the wood is crumbling. Four bandits are searching it to see if anything of value remains";

            //ACTIONS:
            // 1) Fight bandits
            // 2) Search the inn
            // 3) Take the key (will unlock the locked house, which you also access from the town hall

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = OldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetInnDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = INN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Inn";
                returnData.DoLoadLocation = LoadInn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Locked House

        public Location LoadLockedHouse()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Locked House";
            returnData.Description = "This battered house appears locked with no way in. Try searching for a key somewhere within the ruins.";

            //ACTIONS:
            // 1) Unlock with key the player recieved from the inn
            // 2) Escort family too safety

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = OldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetLockedHouseDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LOCKED_HOUSE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Locked House";
                returnData.DoLoadLocation = LoadLockedHouse;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Hall

        public Location LoadTownHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Hall";
            returnData.Description = "The town hall for what must have been a once proud people. Now it's nothing but ruins. There are three bandits that appear to be fighting with each other.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = OldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTownHallDefiniton()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Town Hall";
                returnData.DoLoadLocation = LoadTownHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static OldForestRuins _OldForestRuins;

        public static OldForestRuins GetTownInstance()
        {
            if (_OldForestRuins == null)
            {
                _OldForestRuins = new OldForestRuins();
            }

            return _OldForestRuins;
        }

        #endregion
    }
}