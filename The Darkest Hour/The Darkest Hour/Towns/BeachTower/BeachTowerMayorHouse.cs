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
    class BeachTowerMayorHouse : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerMayorHouse.Entrace";
        public const string LIVING_ROOM_KEY = "BeachTower.BeachTowerMayorHouse.LivingRoom";
        public const string KITCHEN_KEY = "BeachTower.BeachTowerMayorHouse.Kitchen";
        public const string MEETING_ROOM_KEY = "BeachTower.BeachTowerMayorHouse.MeetingRoom";
        public const string STAIRS_KEY = "BeachTower.BeachTowerMayorHouse.Stairs";
        public const string UPSTAIRS_HALLWAY_KEY = "BeachTower.BeachTowerMayorHouse.UpstairsHallway";
        public const string UPSTAIRS_GUEST_BEDROOM_KEY = "BeachTower.BeachTowerMayorHouse.UpstairsGuestBedroom";
        public const string UPSTAIRS_MASTER_BEDROOM_KEY = "BeachTower.BeachTowerMayorHouse.UpstairsMasterBedroom";
        public const string LIVING_ROOM_MOBS = "BeachTower.BeachTowerMayorHouse.LivingRoomMobs";
        public const string KITCHEN_MOBS = "BeachTower.BeachTowerMayorHouse.KitchenMobs";
        public const string MEETING_ROOM_MOBS = "BeachTower.BeachTowerMayorHouse.RightTombMobs";
        public const string UPSTAIRS_HALLWAY_MOBS = "BeachTower.BeachTowerMayorHouse.UpstairsHallwayMobs";
        public const string GUEST_BEDROOM_MOBS = "BeachTower.BeachTowerMayorHouse.GuestBedroomMobs";
        public const string CAPTURED_VILLAGERS_GUEST_BEDROOM = "BeachTower.BeachTowerMayorHouse.CapturedVillagersGuestBedroom";
        public const string STOLEN_KEY_TO_MASTER_BEDROOM = "BeachTower.BeachTowerMayorHouse.StolenKeyMasterBedroom";
        public const string CAPTURED_MAYOR = "BeachTower.BeachTowerMayorHouse.CapturedMayor";
        public const string DEFEAT_BANDIT_RAID_LEADER = "BeachTower.BeachTowerMayorHouse.DefeatBanditRaidLeader";
        public const string TREASURE_CHEST = "BeachTower.BeachTowerMayorHouse.TreasureChest";
        public const string STOLEN_KEY_USED = "BeachTower.BeachTowerMayorHouse.StolenKeyUsed";

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
            returnData.Name = "Mayor's House";
            returnData.Description = "An large house that shows off the wealth of the small town in a humble and simplistic way.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetMayorsHouseDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetLivingRoomDefinition();
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
                returnData.Name = "Opened Catacomb";
                returnData.DoLoadLocation = LoadEntrance;

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
            returnData.Description = "A large living room with several pieces of furniture and a table in the middle. There are cards scattered about the table from an abandoned game. There are bandits inspecting different parts of the room, but holding off theft or ransacking for some odd reason.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetKitchenDefinition();
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

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";
            returnData.Description = "A large kitchen. There is both a cooking area and a large table to serve many guest at once. It is clear that the Mayor is used to entertaining a lot of people for meals. There are several bandits going through the Mayor's food stores.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetMeetingRoomDefinition();
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

        #region Meeting Room

        public Location LoadMeetingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Meeting Room";
            returnData.Description = "This is a relatively small room compared to the others in the house. However it is still rather large compared to rooms in most houses. There is a large table in the middle of the room with documents scattered about, dealing with various parts of the town. There are some necromancers inspecting the documents.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

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

        #region Stairs

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";
            returnData.Description = "A large and twisting staircase, with ornate railing.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetUpstairsHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

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
                returnData.Name = "Meeting Room";
                returnData.DoLoadLocation = LoadStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Upstairs Hallway

        public Location LoadUpstairsHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Upstairs Hallway";
            returnData.Description = "A large hallway with only two rooms connected to it. There are some bandits standing guard at both doors.";

            //Add an action to try and open the Master Bedroom Door for as long as player doesn't have the stolen key
            //i.e. if(!stolenKey) { //Open Door }
            //Once the player has the stolen key they will actually have to unlock it with an action
            //i.e. if(stolenKey && !stolenKeyUsed) { //Unlock Door }
            //Once the player unlocks the door an adjacent location for the Master Bedroom will appear

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetGuestBedroomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetMasterBedroomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetUpstairsHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = UPSTAIRS_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Upstairs Hallway";
                returnData.DoLoadLocation = LoadUpstairsHallway;
                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Guest Bedroom

        public Location LoadGuestBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Guest Bedroom";
            returnData.Description = "A rather simple bedroom. There is a bed in a corner with a nightstand next to it. There is a bookshelf on the wall next to the window. The bookshelf has a mix of books on this part of Asku and some fictional books. There are several villagers tied up and shoved in the corner next to the bookshelf. There are several bandits watching over them.";

            //After defeating the mobs there will be an action to take a stolen key that you see on a bandit's body
            //Remember action to free prisoners

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetUpstairsHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetGuestBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = UPSTAIRS_GUEST_BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Guest Bedroom";
                returnData.DoLoadLocation = LoadGuestBedroom;
                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Master Bedroom

        public Location LoadMasterBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Master Bedroom";
            returnData.Description = "A large bedroom with a large elegent bed in the center of the fall wall. There are several bookshelves full of a wide variety of literature. There is a desk against a side wall with several documents and parchment scattered about it. It is clear the Mayor is quite a scholar. The Mayor is tied up to the front of his bed post, and a Bandit Raid Leader is standing in front of him with his sword drawn and pointed to the Mayor's neck.";

            //Remember action to free the Mayor

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetUpstairsHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMasterBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = UPSTAIRS_MASTER_BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Master Bedroom";
                returnData.DoLoadLocation = LoadMasterBedroom;
                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerMayorHouse _BeachTowerMayorHouse;

        public static BeachTowerMayorHouse GetTownInstance()
        {
            if (_BeachTowerMayorHouse == null)
            {
                _BeachTowerMayorHouse = new BeachTowerMayorHouse();
            }

            return _BeachTowerMayorHouse;
        }

        #endregion
    }
}