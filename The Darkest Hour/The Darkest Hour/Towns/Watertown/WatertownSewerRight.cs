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
    class WatertownSewerRight : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownSewerRight.Entrance";
        public const string ROOM_TWO_KEY = "WatertownSewerRight.RoomTwo";
        public const string ROOM_THREE_KEY = "WatertownSewerRight.RoomThree";
        public const string ROOM_FOUR_KEY = "WatertownSewerRight.RoomFour";
        public const string ROOM_FIVE_KEY = "WatertownSewerRight.RoomFive";
        public const string ROOM_SIX_KEY = "WatertownSewerRight.RoomSix";
        public const string DEFEATED_SECOND_ROOM_RATS = "WatertownSewerRight.DefeatedSecondRoomRats";
        public const string DEFEATED_FIFTH_ROOM_SKELETONS = "WatertownSewerRight.DefeatedFifthRoomSkeletons";
        public const string DEFEATED_SKELETON_KING = "WatertownSewerRight.DefeatedSkeletonKing";
        public const string INSPECTED_TALISMAN = "WatertownSewerRight.InspectedEvilTalisman";
        public const string OPENED_SKELETON_KING_CHEST = "WatertownSewerRight.OpenedSkeletonKingChest";


        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetSewerRightEntranceDefinition();
        }

        #region Sewer Right Entrance

        public Location LoadSewerRightEntrance()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Watertown Sewer Right";
            returnData.Description = "Mud and slime and poopoo. The floor is littered with dead bodies.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceFinalDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetSewerRightEntranceDefinition()
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
                returnData.Name = "Watertown Sewer Right";
                returnData.DoLoadLocation = LoadSewerRightEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 2

        public Location LoadRoomTwo()
        {
            Location returnData;
            bool defeatedSewerRats = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_SECOND_ROOM_RATS));

            returnData = new Location();
            returnData.Name = "Small Room";

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
                combatAction.PostCombat += RoomTwoRats;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSewerRats)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. Sewer Rats lay dead at your feet";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetSewerRightEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            if (defeatedSewerRats)
            {
                locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoRats(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_SECOND_ROOM_RATS, true);

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

        #region Room 3

        public Location LoadRoomThree()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Dirty Room";
            returnData.Description = "Mud and slime and poopoo.  What a nasty place. The floor is covered with the dead skeletons of rats.";
                           
            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomFourDefinition();
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
                returnData.Name = "Dirty Room";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 4

        public Location LoadRoomFour()
        {
            Location returnData;
            bool inspectedTalisman = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.INSPECTED_TALISMAN));

            returnData = new Location();
            returnData.Name = "Dark Room";
            string talismanInfo = "This talisman has a sense of forboding about it.";

            //Actions

            if (inspectedTalisman == false)
            {
                returnData.Description = "Mud and slime and poopoo.  There is a talisman on the ground with dark colors pouring out of it in a misty form.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                TakeItemAction talismanAction = new TakeItemAction("Inspect", "Talisman", talismanInfo);

                talismanAction.PostItem += RoomFourTalisman;

                locationActions.Add(talismanAction);

                returnData.Actions = locationActions;
            }

            if (inspectedTalisman)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. There's a scorch mark where the talisman used to lay.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (inspectedTalisman)
            {
                locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomFiveDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFourTalisman(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.INSPECTED_TALISMAN, true);

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
                returnData.Name = "Dark Room";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 5

        public Location LoadRoomFive()
        {
            Location returnData;
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_FIFTH_ROOM_SKELETONS));

            returnData = new Location();
            returnData.Name = "Stuffy Room";

            //Actions

            if (defeatedSkeletons == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. Skeletons block your path.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += SkeletonBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletons)
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. The bones of your vanquished enemies are scattered upon the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSkeletons)
            {
                locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomSixDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void SkeletonBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_FIFTH_ROOM_SKELETONS, true);

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
                returnData.Name = "Stuffy Room";
                returnData.DoLoadLocation = LoadRoomFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 6

        public Location LoadRoomSix()
        {
            Location returnData;
            bool defeatedSkeletonKing = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_SKELETON_KING));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.OPENED_SKELETON_KING_CHEST));
            Accomplishment forestExplorationAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Explore the Forest"));

            returnData = new Location();
            returnData.Name = "Room of Death";

            //Actions

            if (defeatedSkeletonKing == false)
            {
                returnData.Description = "Mud and slime and poopoo.  What a nasty place. Bones come from the corners of the room to form the Skeleton King.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new SkeletonKing());
                CombatAction combatAction = new CombatAction("Skeleton King", skeletons);
                combatAction.PostCombat += SkeletonKingBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletonKing)
            {
                if (openedChest == false)
                {
                    returnData.Description = "Mud and slime and poopoo.  What a nasty place. The Skeleton King rest in pieces on the ground. His unopened chest appears in the middle of the room.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += SkeletonKingChest;
                    returnData.Actions = locationActions;
                }
                else if (openedChest)
                    returnData.Description = "Mud and slime and poopoo.  What a nasty place. The Skeleton King rest in pieces on the ground. His opened chest sits in the middle of the room.";
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (GameState.Hero.Accomplishments.Contains(forestExplorationAccomplishment))
            {
                locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetStartingLocationDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            if (defeatedSkeletonKing)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void SkeletonKingBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_SKELETON_KING, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_SIX_KEY);

            }
        }

        public void SkeletonKingChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.OPENED_SKELETON_KING_CHEST, true);

                // Reload
                LocationHandler.ResetLocation(ROOM_THREE_KEY);

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
                returnData.Name = "Room of Death";
                returnData.DoLoadLocation = LoadRoomSix;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownSewerRight _WatertownSewer;

        public static WatertownSewerRight GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownSewerRight();
            }

            return _WatertownSewer;
        }

        #endregion
    }
}