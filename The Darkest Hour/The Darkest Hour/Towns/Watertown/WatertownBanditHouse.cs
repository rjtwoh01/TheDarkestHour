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
    class WatertownBanditHouse : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownBanditHouse.Entrance";
        public const string ROOM_TWO_KEY = "WatertownBanditHouse.RoomTwo";
        public const string ROOM_THREE_KEY = "WatertownBanditHouse.RoomThree";
        public const string STAIR_WAY_KEY = "WatertownBanditHouse.StairWay";
        public const string ROOM_FOUR_KEY = "WatertownBanditHouse.RoomFour";
        public const string HALL_WAY_KEY = "WatertownBanditHouse.HallWay";
        public const string ROOM_FIVE_KEY = "WatertownBanditHouse.RoomFive";
        public const string ROOM_SIX_KEY = "WatertownBanditHouse.RoomSix";
        public const string DEFEATED_ROOM_TWO_BANDITS = "WatertownBanditHouse.DefeatedRoomTwoBandits";
        public const string TOOK_ROOM_THREE_DOCUMENTS = "WatertownBanditHouse.TookRoomThreeDocuments";
        public const string DEFEATED_ROOM_FOUR_BANDITS = "WatertownBanditHouse.DefeatedRoomFourBandits";
        public const string TOOK_ROOM_FIVE_GOLD = "WatertownBanditHouse.TookRoomFiveGold";
        public const string DEFATED_BANDIT_SPY = "WatertownBanditHouse.DefeatedBanditSpy";
        public const string TOOK_SPY_LETTER = "WatertownBanditHouse.TookSpyLetter";
        public const string OPENED_SPY_CHEST = "WatertownBanditHouse.OpenedSpyChest";

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
            returnData = new Location();
            returnData.Name = "Bandit House Entrance";
            returnData.Description = "The room is full of uncomfortable looking furniture. The chair in the corner looks like it has a large blood stain on it.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomTwoDefinition();
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
                returnData.Name = "Bandit House Entrance";
                returnData.DoLoadLocation = LoadForestCabinEntrance;

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
            returnData.Name = "Small Room";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFEATED_ROOM_TWO_BANDITS));

            if (!defeatedBandits)
            {
                returnData.Description = "This room has several bandits sitting on a couch.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += RoomTwoBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedBandits)
                returnData.Description = "Bandits lay dead on the couch.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFEATED_ROOM_TWO_BANDITS, true);

                // Reload
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
                returnData.Name = "Small Room";
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
            returnData.Name = "Study";
            bool tookDocuments = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_ROOM_THREE_DOCUMENTS));

            if (!tookDocuments)
            {
                returnData.Description = "This room has a desk in the middle of it with a stack of documents on it.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction documentsAction = new TakeItemAction("Documents");
                documentsAction.PostItem += RoomThreeDocuments;
                locationActions.Add(documentsAction);
                returnData.Actions = locationActions;
            }
            if (tookDocuments)
                returnData.Description = "There is an empty desk in the middle of the room.";


            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (tookDocuments)
            {
                locationDefinition = WatertownBanditHouse.GetTownInstance().GetStairWayDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomThreeDocuments(object sender, TakeItemEventArgs takeItemsEventArgs)
        {
            if (takeItemsEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_ROOM_THREE_DOCUMENTS, true);

                // Reload
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
                returnData.Name = "Study";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region StairWay

        public Location LoadStairWay()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stair Way";
            returnData.Description = "A small stair way.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStairWayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STAIR_WAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Stair Way";
                returnData.DoLoadLocation = LoadStairWay;

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
            returnData.Name = "Second Floor Landing";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFEATED_ROOM_FOUR_BANDITS));

            if (!defeatedBandits)
            {
                returnData.Description = "A small landing on the top of the stairs. There are two bandits headed toward the stairs..";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += RoomFourBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedBandits)
                returnData.Description = "Bandits lay dead on the couch.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetStairWayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = WatertownBanditHouse.GetTownInstance().GetHallwayDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFourBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFEATED_ROOM_FOUR_BANDITS, true);

                // Reload
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
                returnData.Name = "Second Floor Landing";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Hall Way

        public Location LoadHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hall Way";
            returnData.Description = "A plain and narrow hall way.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HALL_WAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hall Way";
                returnData.DoLoadLocation = LoadHallway;

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
            returnData.Name = "Storage Room";
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_ROOM_FIVE_GOLD));

            if (!tookGold)
            {
                returnData.Description = "A small room with mostly empty boxes and crates. Within one of the boxes is a bag of gold forgotten and left behind";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(75);
                locationActions.Add(itemAction);
                itemAction.PostItem += RoomFiveGold;
                returnData.Actions = locationActions;
            }
            if (tookGold)
                returnData.Description = "A small room with empty boxes and crates.";


            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomSixDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFiveGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_ROOM_FIVE_GOLD, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_FIVE_KEY);

            }
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
                returnData.Name = "Storage Room";
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
            bool defeatedNecromancerLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFATED_BANDIT_SPY));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.OPENED_SPY_CHEST));
            bool takeLetter = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_SPY_LETTER));

            returnData = new Location();
            returnData.Name = "Bedroom";

            //Actions

            if (defeatedNecromancerLeader == false)
            {
                returnData.Description = "A large luxurious bedroom with a large comfortable bed against the back wall. A bandit spy is sitting on the bed playing with one of his knives..";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> spy = new List<Mob>();
                spy.Add(new BanditSpy());
                CombatAction combatAction = new CombatAction("Bandit Spy", spy);
                combatAction.PostCombat += BanditSpyBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecromancerLeader)
            {
                if (openedChest == false)
                {
                    if (!takeLetter)
                        returnData.Description = "A large luxurious bedroom with a large comfortable bed against the back wall. The bandit spy lays dead on his bed with a letter on his night stand and a chest under his bed";
                    else
                        returnData.Description = "A large luxurious bedroom with a large comfortable bed against the back wall. The bandit spy lays dead on his bed with a chest under his bed";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += SpyChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeLetter)
                    returnData.Description = "A large luxurious bedroom with a large comfortable bed against the back wall. The bandit spy lays dead on his bed with a chest under his bed";

                if (!takeLetter && openedChest)
                {
                    returnData.Description = "A large luxurious bedroom with a large comfortable bed against the back wall. The bandit spy lays dead on his bed with a letter on his night stand and a chest under his bed";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Letter");
                    letterAction.PostItem += SpyLetter;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownBanditHouse.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (takeLetter)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BanditSpyBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.DEFATED_BANDIT_SPY, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_SIX_KEY);

            }
        }

        public void SpyLetter(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.TOOK_SPY_LETTER, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_SIX_KEY);

            }
        }

        public void SpyChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditHouse.OPENED_SPY_CHEST, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_SIX_KEY);

            }
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
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadRoomSix;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownBanditHouse _WaterForestCabin;

        public static WatertownBanditHouse GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new WatertownBanditHouse();
            }

            return _WaterForestCabin;
        }

        #endregion
    }
}
