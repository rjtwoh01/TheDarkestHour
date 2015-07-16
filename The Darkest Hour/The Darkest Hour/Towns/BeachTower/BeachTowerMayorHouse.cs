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
        public const string DUMBY_KEY_DOOR = "BeachTower.BeachTowerMayorHouse.DumbyKeyDoor"; //A dumby key to try to open the door since need one

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.LIVING_ROOM_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A large living room with several pieces of furniture and a table in the middle. There are cards scattered about the table from an abandoned game. There are bandits inspecting different parts of the room, but holding off theft or ransacking for some odd reason.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += LivingRoomMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large living room with several pieces of furniture and a table in the middle. There are cards scattered about the table from an abandoned game.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LivingRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.LIVING_ROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(LIVING_ROOM_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.KITCHEN_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A large kitchen. There is both a cooking area and a large table to serve many guest at once. It is clear that the Mayor is used to entertaining a lot of people for meals. There are several bandits going through the Mayor's food stores.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += KitchenMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large kitchen. There is both a cooking area and a large table to serve many guest at once. It is clear that the Mayor is used to entertaining a lot of people for meals.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetMeetingRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void KitchenMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.KITCHEN_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(KITCHEN_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.MEETING_ROOM_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "This is a relatively small room compared to the others in the house. However it is still rather large compared to rooms in most houses. There is a large table in the middle of the room with documents scattered about, dealing with various parts of the town. There are some necromancers inspecting the documents.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += MeetingRoomMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "This is a relatively small room compared to the others in the house. However it is still rather large compared to rooms in most houses. There is a large table in the middle of the room with documents scattered about, dealing with various parts of the town.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetStairsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MeetingRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.MEETING_ROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MEETING_ROOM_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.UPSTAIRS_HALLWAY_MOBS));
            bool haveKey = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.STOLEN_KEY_TO_MASTER_BEDROOM));
            bool doorUnlocked = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.STOLEN_KEY_USED));

            if (!defeatedMobs)
            {
                returnData.Description = "A large hallway with only two rooms connected to it. There are some bandits standing guard at both doors.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += HallwayMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            
            //Add an action to try and open the Master Bedroom Door for as long as player doesn't have the stolen key
            //i.e. if(!stolenKey) { //Open Door }
            //Once the player has the stolen key they will actually have to unlock it with an action
            //i.e. if(stolenKey && !stolenKeyUsed) { //Unlock Door }
            //Once the player unlocks the door an adjacent location for the Master Bedroom will appear

            else if (!haveKey && defeatedMobs)
            {
                returnData.Description = "A large hallway with only two rooms connected to it.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Open", "Door to Master Bedroom", "You try to open the door. It's locked. Maybe you should go find a key.");
                itemAction.PostItem += TryDoor;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }

            else if (haveKey && defeatedMobs)
            {
                returnData.Description = "A large hallway with only two rooms connected to it.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Unlock", "Door to Master Bedroom", "You unlock the door to the master bedroom. You may now enter.");
                itemAction.PostItem += UnlockDoor;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }

            else
                returnData.Description = "A large hallway with only two rooms connected to it. The master bedroom is now unlocked.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetGuestBedroomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && doorUnlocked)
            {
                locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetMasterBedroomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void HallwayMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {                
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.UPSTAIRS_HALLWAY_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_HALLWAY_KEY);
            }
        }

        public void TryDoor(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                //This may or may not work. If it works it may only work once. That's not acceptable
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.DUMBY_KEY_DOOR, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_HALLWAY_KEY);
            }
        }

        public void UnlockDoor(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.STOLEN_KEY_USED, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_HALLWAY_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.GUEST_BEDROOM_MOBS));
            bool freeVillagers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.CAPTURED_VILLAGERS_GUEST_BEDROOM));
            bool tookKey = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.STOLEN_KEY_TO_MASTER_BEDROOM));

            if (!defeatedMobs)
            {
                returnData.Description = "A rather simple bedroom. There is a bed in a corner with a nightstand next to it. There is a bookshelf on the wall next to the window. The bookshelf has a mix of books on this part of Asku and some fictional books. There are several villagers tied up and shoved in the corner next to the bookshelf.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += GuestBedroomMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            //After defeating the mobs there will be an action to take a stolen key that you see on a bandit's body
            //Remember action to free prisoners

            else if (defeatedMobs && !freeVillagers)
            {
                returnData.Description = "A rather simple bedroom. There is a bed in a corner with a nightstand next to it. There is a bookshelf on the wall next to the window. The bookshelf has a mix of books on this part of Asku and some fictional books. There are several villagers tied up and shoved in the corner next to the bookshelf.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Free", "Captured Villagers", "You free the captured villagers. You inform them to head to the Beach Tower to recieve medical attention. You let them know that soldiers are stationed throughout the city helping with the clean up and that they will help escort them. As one of the villagers rushes to leave the room, she trips over a dead bandit's body, knocking it over and revealing a key tied to his belt.");
                itemAction.PostItem += TryDoor;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }

            else if (defeatedMobs && freeVillagers && !tookKey)
            {
                returnData.Description = "A rather simple bedroom. There is a bed in a corner with a nightstand next to it. There is a bookshelf on the wall next to the window. The bookshelf has a mix of books on this part of Asku and some fictional books. One of the dead bandit's has a key tied to his belt.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Take", "Key from the dead Bandit", "You cut the piece of leather tying the key to the bandit's belt and put it in your pocket. This key might be useful later.");
                itemAction.PostItem += TakeKey;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A rather simple bedroom. There is a bed in a corner with a nightstand next to it. There is a bookshelf on the wall next to the window. The bookshelf has a mix of books on this part of Asku and some fictional books.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetUpstairsHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void GuestBedroomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.GUEST_BEDROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_GUEST_BEDROOM_KEY);
            }
        }

        public void FreeVillagers(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.CAPTURED_VILLAGERS_GUEST_BEDROOM, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_GUEST_BEDROOM_KEY);
            }
        }

        public void TakeKey(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.STOLEN_KEY_TO_MASTER_BEDROOM, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_GUEST_BEDROOM_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.DEFEAT_BANDIT_RAID_LEADER));
            bool freeMayor = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.CAPTURED_MAYOR));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.TREASURE_CHEST));

            if (!defeatedMobs)
            {
                returnData.Description = "A large bedroom with a large elegent bed in the center of the fall wall. There are several bookshelves full of a wide variety of literature. There is a desk against a side wall with several documents and parchment scattered about it. It is clear the Mayor is quite a scholar. The Mayor is tied up to the front of his bed post, and a Bandit Raid Leader is standing in front of him with his sword drawn and pointed to the Mayor's neck.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new BanditRaidLeader());
                CombatAction combatAction = new CombatAction("Bandit Raid Leader", mobs);
                combatAction.PostCombat += BanditRaidLeader;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            else if (defeatedMobs && !freeMayor)
            {
                returnData.Description = "A large bedroom with a large elegent bed in the center of the fall wall. There are several bookshelves full of a wide variety of literature. There is a desk against a side wall with several documents and parchment scattered about it. It is clear the Mayor is quite a scholar. The Mayor is tied up to the front of his bed post.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Free", "Mayor", "You cut the ties that are binding the mayor to the bed. He thanks you and promptly leaves the house to asses the damage done to his town. You should report back to Mike at the Beach Tower to let him know that the Mayor is free and the town has been completely liberated.");
                itemAction.PostItem += FreeMayor;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }

            else if (defeatedMobs && freeMayor && !tookTreasure)
            {
                returnData.Description = "A large bedroom with a large elegent bed in the center of the fall wall. There are several bookshelves full of a wide variety of literature. There is a desk against a side wall with several documents and parchment scattered about it. It is clear the Mayor is quite a scholar.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            returnData.Description = "A large bedroom with a large elegent bed in the center of the fall wall. There are several bookshelves full of a wide variety of literature. There is a desk against a side wall with several documents and parchment scattered about it. It is clear the Mayor is quite a scholar. The Mayor is tied up to the front of his bed post.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerMayorHouse.GetTownInstance().GetUpstairsHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && freeMayor)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BanditRaidLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.DEFEAT_BANDIT_RAID_LEADER, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_MASTER_BEDROOM_KEY);
            }
        }

        public void FreeMayor(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.CAPTURED_MAYOR, true);

                //Reload 
                LocationHandler.ResetLocation(UPSTAIRS_MASTER_BEDROOM_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerMayorHouse.TREASURE_CHEST, true);

                //Reload
                LocationHandler.ResetLocation(UPSTAIRS_MASTER_BEDROOM_KEY);
            }
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