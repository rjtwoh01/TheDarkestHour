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
    class MagesRetreatHouse : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.MagesRetreatHouse.Entrance";
        public const string HALLWAY_KEY = "Banken.MagesRetreatHouse.Hallway";
        public const string DININING_ROOM_KEY = "Banken.MagesRetreatHouse.DiningRoom";
        public const string KITCHEN_KEY = "Banken.MagesRetreatHouse.Kitchen";
        public const string LIVING_ROOM_KEY = "Banken.MagesRetreatHouse.LivingRoom";
        public const string BEDROOM_KEY = "Banken.MagesRetreatHouse.Bedroom";


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
            returnData.Name = "Mage's Retreat House";
            returnData.Description = "A small house built just off the Worship Region of Banken's forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetReligiousShrineClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
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
                returnData.Name = "Mage's Retreat Shack";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Hallway

        public Location LoadHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hallway";
            returnData.Description = "A hallway lays just inside the front door of the house. There are summoned spirits left over from some recent battle.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetDiningRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hallway";
                returnData.DoLoadLocation = LoadHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dining Room

        public Location LoadDiningRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dining Room";
            returnData.Description = "A dining room, made to fit a small family or group of friends. There are several bandits sitting at the table laughing as they drink beer, most likely stolen from the mage who lives here.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDiningRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DININING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dining Room";
                returnData.DoLoadLocation = LoadDiningRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";
            returnData.Description = "A small kitchen. There are cabnits thrown open and boxes of food strewn across the floor. There are two bandits rummaging through the different food stores.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetDiningRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetKitchenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = KITCHEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadKitchen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Living Room

        public Location LoadLivingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Living Room";
            returnData.Description = "The living room has a couch and a couple chairs. There is a fireplace in the corner. There are four bandits sitting about, talking about their various adventures.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetBedroomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetLivingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LIVING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Living Room";
                returnData.DoLoadLocation = LoadLivingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bedroom

        public Location LoadBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bedroom";
            returnData.Description = "A small bedroom with a bed against the back wall and a desk against a side wall. A Pyschotic Bandit is going through the mage's desk and is throwing papers about everywhere.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static MagesRetreatHouse _MagesRetreatHouse;

        public static MagesRetreatHouse GetTownInstance()
        {
            if (_MagesRetreatHouse == null)
            {
                _MagesRetreatHouse = new MagesRetreatHouse();
            }

            return _MagesRetreatHouse;
        }

        #endregion
    }
}