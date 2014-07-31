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

        #region FLOOR ONE

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

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetLargeCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

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

        #region Large Cooridor

        public Location LoadLargeCooridor()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Cooridor";
            returnData.Description = "A large cooridor filled with priceless art and statues.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLargeCooridorDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_COORIDOR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Cooridor";
                returnData.DoLoadLocation = LoadLargeCooridor;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Long Hallway

        public Location LoadLongHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Long Hallway";
            returnData.Description = "A long hallway with torches lining the walls and large paintings hanging above them.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLargeCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetBarracksDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetGreatHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLongHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LONG_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Long Hallway";
                returnData.DoLoadLocation = LoadLongHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Barracks

        public Location LoadBarracks()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Barracks";
            returnData.Description = "A medium sized room full of armor and weapns. There are six guards sitting around inside.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetBarracksDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BARRACKS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Barracks";
                returnData.DoLoadLocation = LoadBarracks;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Great Hall

        public Location LoadGreatHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Great Hall";
            returnData.Description = "A large great hall full of many nobles partaking in Ariean's party.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetGreatHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = GREAT_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Great Hall";
                returnData.DoLoadLocation = LoadGreatHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region STAIRS       

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";
            returnData.Description = "A large marble stair case connecting the first and second floor of Ariean's Estate.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetGreatHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Stairs";
                returnData.DoLoadLocation = LoadStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region FLOOR TWO

        #region Landing

        public Location LoadLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Landing";
            returnData.Description = "A large landing that overlooks the great hall beneath it. There are six guards blocking further access to the second floor.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LANDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Landing";
                returnData.DoLoadLocation = LoadLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Four

        public Location LoadRoomFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Four";
            returnData.Description = "A small room that contains a treasure chest that's pushed up against the wall.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Four";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Meeting Room

        public Location LoadMeetingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Meeting Room";
            returnData.Description = "A medium sized room with a large table in the center. There are four nobles discussing current politics at the table.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetMeetingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MEETING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Meeting Room";
                returnData.DoLoadLocation = LoadMeetingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cooridor

        public Location LoadCooridor()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cooridor";
            returnData.Description = "A narrow cooridor.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetCooridorDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COORIDOR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cooridor";
                returnData.DoLoadLocation = LoadCooridor;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Five

        public Location LoadRoomFive()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Five";
            returnData.Description = "An empty room with four guards blocking further access to the second floor.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomSixDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetArmoryDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetStorageRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomFiveDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_FIVE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Five";
                returnData.DoLoadLocation = LoadRoomFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Six

        public Location LoadRoomSix()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Six";
            returnData.Description = "A medium sized room with eight guards blocking access to Ariean's master bedroom. They all have the swords and shields drawn.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetArieansMasterBedroomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRoomSixDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_SIX_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Six";
                returnData.DoLoadLocation = LoadRoomSix;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Armory

        public Location LoadArmory()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Armory";
            returnData.Description = "A small armory holding a few more weapons and armor. Two guards are inspecting the equipment.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetArmoryDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARMORY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Armory";
                returnData.DoLoadLocation = LoadArmory;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage Room

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            returnData.Description = "A small storage room. There is a bag and a treasure chest within the room.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStorageRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadStorageRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ariean's Master Bedroom

        public Location LoadArieansMasterBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ariean's Master Bedroom";
            returnData.Description = "A large room with very expensive furniture and decorations. There is a large master bed in the center of the room. Ariean is sitting on it, staring calmly at the door.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetArieansMasterBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARIENS_MASTER_BEDROOM;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ariean's Master Bedroom";
                returnData.DoLoadLocation = LoadArieansMasterBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

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
