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
    class WatertownForestCabin : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForestCabin.Entrance";
        public const string ROOM_TWO_KEY = "WatertownForestCabin.RoomTwo";
        public const string ROOM_THREE_KEY = "WatertownForestCabin.RoomThree";
        public const string ROOM_FOUR_KEY = "WatertownForestCabin.RoomFour";
        public const string INSPECTED_DEAD_BODIES = "WatertownForestCabin.InspectedDeadBodies";
        public const string KILLED_KITCHEN_NECROMANCERS = "WatertownForestCabin.KilledKitchenNecromancers";
        public const string DEFEATED_NECROMANCER_LEADER = "WatertownForestCabin.DefeatedNecromancerLeaderBoss";
        public const string OPENED_BOSS_CHEST_ROOM_SIX = "WatertownForestCabin.OpenedBossChestRoomSix";
        public const string TOOK_LETTER = "WatertownForestCabin.TookNecroLeaderLetter";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Cabin Entrance

        public Location LoadForestCabinEntrance()
        {
            Location returnData;
            bool inspectedBodies = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.INSPECTED_DEAD_BODIES));
            returnData = new Location();
            returnData.Name = "Cabin Entrance";
            returnData.Description = "The room has a mass of dead bodies strewn across the floor";
            string bodyInfo = "The bodies look like they're burned and scarred from knifes and dark magic.";

            //Actions

            if (inspectedBodies == false)
            {
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                TakeItemAction talismanAction = new TakeItemAction("Inspect", "Bodies", bodyInfo);

                talismanAction.PostItem += EntranceBodies;

                locationActions.Add(talismanAction);

                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetEnclosedClearingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (inspectedBodies)
            {
                locationDefinition = WatertownForestCabin.GetTownInstance().GetRoomTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EntranceBodies(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.INSPECTED_DEAD_BODIES, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_KEY);

            }
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
                returnData.Name = "Cabin Entrance";
                returnData.DoLoadLocation = LoadForestCabinEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Two

        public Location LoadRoomTwoEntrance()
        {
            Location returnData;
            bool defeatedNecromancers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.KILLED_KITCHEN_NECROMANCERS));
            returnData = new Location();
            returnData.Name = "Kitchen";
            
            //Actions

            if (defeatedNecromancers == false)
            {
                returnData.Description = "The kitchen smells of freshly cooked meat. There are necromancers in the process of handling the food.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necromancers = new List<Mob>();
                necromancers.Add(new Necromancer());
                necromancers.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", necromancers);
                combatAction.PostCombat += KitchenNecromancers;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecromancers)
                returnData.Description = "The kitchen smells of cooked meat. There are necromancers dead against the counter.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestCabin.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecromancers)
            {
                locationDefinition = WatertownForestCabin.GetTownInstance().GetRoomThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void KitchenNecromancers(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.KILLED_KITCHEN_NECROMANCERS, true);

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
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadRoomTwoEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Three

        public Location LoadRoomThree()
        {
            Location returnData;
            bool defeatedNecromancers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.KILLED_KITCHEN_NECROMANCERS));
            returnData = new Location();
            returnData.Name = "Living Room";
            returnData.Description = "There is a pentagram made of blood in the center of the room. Otherwise the living room is bare and empty.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestCabin.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForestCabin.GetTownInstance().GetRoomFourDefinition();
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
                returnData.Name = "Living Room";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Four

        public Location LoadRoomFour()
        {
            Location returnData;
            bool defeatedNecromancerLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.DEFEATED_NECROMANCER_LEADER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.OPENED_BOSS_CHEST_ROOM_SIX));
            bool takeLetter = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.TOOK_LETTER));

            returnData = new Location();
            returnData.Name = "Bedroom";

            //Actions

            if (defeatedNecromancerLeader == false)
            {
                returnData.Description = "A small bedroom. The necromancer leader sits in the middle of the room with his legs crossed, dark energy swirling around him.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new NecromancerLeader());
                CombatAction combatAction = new CombatAction("Necromancer Leader", necro);
                combatAction.PostCombat += NecromancerLeaderBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecromancerLeader)
            {
                if (openedChest == false)
                {
                    if (!takeLetter)
                        returnData.Description = "A small bedroom. The necromancer leader lays dead and broken on the ground. His unopened chest is against the far wall. A letter fell out of his pocket.";
                    else
                        returnData.Description = "A small bedroom. The necromancer leader lays dead and broken on the ground. His unopened chest is against the far wall.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += NecroChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeLetter)
                    returnData.Description = "A small bedroom. The necromancer leader lays dead and broken on the ground. His opened chest is against the far wall.";

                if (!takeLetter && openedChest)
                {
                    returnData.Description = "A small bedroom. The necromancer leader lays dead and broken on the ground. His opened chest is against the far wall. A letter fell out of his pocket.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Letter");
                    letterAction.PostItem += NecroLetter;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestCabin.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (takeLetter)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NecromancerLeaderBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.DEFEATED_NECROMANCER_LEADER, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_FOUR_KEY);

            }
        }

        public void NecroLetter(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.TOOK_LETTER, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_FOUR_KEY);

            }
        }

        public void NecroChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.OPENED_BOSS_CHEST_ROOM_SIX, true);

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
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownForestCabin _WaterForestCabin;

        public static WatertownForestCabin GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new WatertownForestCabin();
            }

            return _WaterForestCabin;
        }

        #endregion
    }
}
