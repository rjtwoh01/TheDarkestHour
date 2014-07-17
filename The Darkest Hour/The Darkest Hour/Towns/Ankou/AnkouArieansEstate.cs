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
    class AnkouArieansEstate : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouAriensEstate.Entrance";
        public const string ROOM_ONE_KEY = "Ankou.AnkouAriensEstate.RoomOne";
        public const string ROOM_TWO_KEY = "Ankou.AnkouAriensEstate.RoomTwo";
        public const string ROOM_THREE_KEY = "Ankou.AnkouAriensEstate.RoomThree";
        public const string LARGE_COORIDOR_KEY = "Ankou.AnkouAriensEstate.LargeCooridor";
        public const string LONG_HALLWAY_KEY = "Ankou.AnkouAriensEstate.LongHallway";
        public const string BARRACKS_KEY = "Ankou.AnkouAriensEstate.Barracks";
        public const string GREAT_HALL_KEY = "Ankou.AnkouAriensEstate.GreatHall";
        public const string STAIRS_KEY = "Ankou.AnkouAriensEstate.Stairs";
        public const string LANDING_KEY = "Ankou.AnkouAriensEstate.Landing";
        public const string ROOM_FOUR_KEY = "Ankou.AnkouAriensEstate.RoomFour";
        public const string MEETING_ROOM_KEY = "Ankou.AnkouAriensEstate.MeetingRoom";
        public const string COORIDOR_KEY = "Ankou.AnkouAriensEstate.Cooridor";
        public const string ROOM_FIVE_KEY = "Ankou.AnkouAriensEstate.RoomFive";
        public const string ROOM_SIX_KEY = "Ankou.AnkouAriensEstate.RoomSix";
        public const string ARMORY_KEY = "Ankou.AnkouAriensEstate.Armory";
        public const string STORAGE_ROOM_KEY = "Ankou.AnkouAriensEstate.StorageRoom";
        public const string ARIENS_MASTER_BEDROOM = "Ankou.AnkouAriensEstate.AriensMasterBedroom";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ariean's Estate";
            returnData.Description = "The estate's entrance is a large hall with two grand stair cases leading up to the second floor and a large door between them. The stairs are blocked and the door is bolted shut and cannot be opened. There is another door to the left.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

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
                returnData.Name = "Ariean's Estate";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room One

        public Location LoadRoomOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room One";
            returnData.Description = "A small room filled with four guards.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room One";
                returnData.DoLoadLocation = LoadRoomOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Two

        public Location LoadRoomTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Two";
            returnData.Description = "A medium sized room with three guards in it.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Two";
                returnData.DoLoadLocation = LoadRoomTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Three

        public Location LoadRoomThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Three";
            returnData.Description = "The first room that actually looks inhabitable. It's a medium sized room with a couch agains the wall. Three guards are sitting on it, chatting.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //locationDefinition = AnkouArieansEstate.GetTownInstance().GetLargeCooridorDefinition();
            //adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Three";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouArieansEstate _AnkouArieansEstate;

        public static AnkouArieansEstate GetTownInstance()
        {
            if (_AnkouArieansEstate == null)
            {
                _AnkouArieansEstate = new AnkouArieansEstate();
            }

            return _AnkouArieansEstate;
        }

        #endregion
    }
}
