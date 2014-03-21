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
    class WatertownSewerLeft : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownSewerLeft.Entrance";
        public const string ROOM_TWO_KEY = "WatertownSewerLeft.RoomTwo";
        public const string ROOM_THREE_KEY = "WatertownSewerLeft.RoomThree";
        public const string HALLWAY_KEY = "WatertownSewerLeft.Hallway";
        public const string ROOM_FOUR_KEY = "WatertownSewerLeft.RoomFour";
        public const string DEFEATED_FIRST_ROOM_RATS = "DefeatedFirstRoomRats";
        public const string TOOK_GOLD_KEY = "TookRoomTwoGold";
        public const string OPENED_CHEST_ROOM_THREE = "OpenedChestInRoomThree";
        public const string DEFEATED_HALLWAY_RATS = "DefeatedHallwayRatsSewerLeft";
        public const string DEFEATED_OUTLAW_BOSS = "DefeatedOutlawBossSewerLeft";


        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetSewerLeftEntranceDefinition();
        }

        #region Sewer Left Entrance

        public Location LoadSewerLeftEntrance()
        {
            Location returnData;
            bool defeatedSewerRats = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_FIRST_ROOM_RATS));

            returnData = new Location();
            returnData.Name = "Watertown Sewer Left";

            //Actions

            if (defeatedSewerRats == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. A vicious pack of sewer rats impeede your progress";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> sewerRats = new List<Mob>();
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                CombatAction combatAction = new CombatAction("Sewer Rats", sewerRats);
                combatAction.PostCombat += FirstRoomRats;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSewerRats)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. A pack of sewer rats lay dead on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceFinalDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSewerRats)
            {
                locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void FirstRoomRats(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_FIRST_ROOM_RATS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_KEY);

            }
        }

        public LocationDefinition GetSewerLeftEntranceDefinition()
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
                returnData.Name = "Watertown Sewer Left";
                returnData.DoLoadLocation = LoadSewerLeftEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 2

        public Location LoadRoomTwo()
        {
            Location returnData;
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.TOOK_GOLD_KEY));

            returnData = new Location();
            returnData.Name = "Yucky Room";

            //Actions

            if (tookGold == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. A bag of gold lays forgotten on the floor";
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(50);
                locationActions.Add(itemAction);
                itemAction.PostItem += RoomTwoGold;
                returnData.Actions = locationActions;
            }
            if (tookGold)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. An empty bag of gold lays forgotten on the floor";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerLeft.GetTownInstance().GetSewerLeftEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.TOOK_GOLD_KEY, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_TWO_KEY);

            }
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
                returnData.Name = "Yucky Room";
                returnData.DoLoadLocation = LoadRoomTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 3

        public Location LoadRoomThree()
        {
            Location returnData;
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.OPENED_CHEST_ROOM_THREE));

            returnData = new Location();
            returnData.Name = "Plain Room";

            //Actions

            if (openedChest == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. A treasure chest sits against a wall.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(2);
                locationActions.Add(itemAction);
                itemAction.PostItem += RoomThreeChest;
                returnData.Actions = locationActions;
            }
            
            if (openedChest)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. An opened treasure chest sits against a wall.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownSewerLeft.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomThreeChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.OPENED_CHEST_ROOM_THREE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_THREE_KEY);

            }
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
                returnData.Name = "Plain Room";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Hallway

        public Location LoadHallway()
        {
            Location returnData;
            bool defeatedSewerRats = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_HALLWAY_RATS));

            returnData = new Location();
            returnData.Name = "Hallway";

            //Actions

            if (defeatedSewerRats == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. Sewer Rats block your path";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> sewerRats = new List<Mob>();
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                CombatAction combatAction = new CombatAction("Sewer Rats", sewerRats);
                combatAction.PostCombat += HallwayRats;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }

            if (defeatedSewerRats)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. Sewer Rats lay dead at your feet";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSewerRats)
            {
                locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomFourDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void HallwayRats(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_HALLWAY_RATS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(HALLWAY_KEY);

            }
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

        #region Room 4

        public Location LoadRoomFour()
        {
            Location returnData;
            bool defeatedOutlawBoss = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_OUTLAW_BOSS));

            returnData = new Location();
            returnData.Name = "Giant Room";

            //Actions

            if (defeatedOutlawBoss == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. The Outlaw Boss stands in the middle of the room";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> outlawBoss = new List<Mob>();
                outlawBoss.Add(new OutlawBoss());
                CombatAction combatAction = new CombatAction("Outlaw Boss", outlawBoss);
                combatAction.PostCombat += OutlawBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedOutlawBoss)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. The Outlaw Boss's dead body decomposes on the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerLeft.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedOutlawBoss)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void OutlawBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_OUTLAW_BOSS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_FOUR_KEY);

            }
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
                returnData.Name = "Giant Room";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownSewerLeft _WatertownSewer;

        public static WatertownSewerLeft GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownSewerLeft();
            }

            return _WatertownSewer;
        }

        #endregion
    }
}
