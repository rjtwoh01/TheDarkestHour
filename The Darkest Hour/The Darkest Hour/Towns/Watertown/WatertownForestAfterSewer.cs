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
    class WatertownForestAfterSewer : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForestAfterSewer.Entrance";
        public const string NARROW_PATH_KEY = "WatertownForestAfterSewer.NarrowPath";
        public const string MEETING_GROUNDS_KEY = "WatertownForestAfterSewer.MeetingGrounds";
        public const string DEATH_CIRCLE_KEY = "WatertownForestAfterSewer.DeathCircle";
        public const string ENCLOSED_CLEARING_KEY = "WatertownForestAfterSewer.EnclosedClearing";
        public const string DEFEATED_ENTRANCE_SKELETONS = "WatertownForestAfterSewer.DefeatedClearingSkeletons";
        public const string DEFEATED_NARROW_PATH_SKELETONS = "WatertownForestAfterSewer.DefeatedNarrowPathSkeletons";
        public const string DEFATED_MEETING_GROUNDS_POSSESED_VILLAGERS = "WatertownForestAfterSewer.DefeatedGroundsPossessedVillagers";
        public const string DEFEATED_DEATH_CIRCLE_SKELETONS = "WatertownForestAfterSewer.DefeatedDeathCircleSkeletons";
        public const string DEFEATED_POSSESED_GUARD = "WatertownForestAfterSewer.DefeatedPossesedGuard";
        public const string OPENED_BOSS_CHEST_ENCLOSED_CLEARING = "WatertownForestAfterSewer.DefeatedPossesedGaurdBoss";


        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetForestClearingDefintion();
        }

        #region Sewer Right Entrance

        public Location LoadForestClearingEntrance()
        {
            Location returnData;
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_ENTRANCE_SKELETONS));
            returnData = new Location();
            returnData.Name = "Small Forest Clearing";

            //Actions

            if (defeatedSkeletons == false)
            {
                returnData.Description = "A small forest clearing. The air is dark and heavy with the presence of evil so near by. Skeletons block the path forward.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += EntranceSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletons)
                returnData.Description = "A small forest clearing. The air is dark and heavy with the presence of evil so near by. The bones of your foes are scattered agains the edges of the trees.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewerRight.GetTownInstance().GetRoomSixDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSkeletons)
            {
                locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetNarrowPathDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EntranceSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_ENTRANCE_SKELETONS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_KEY);

            }
        }

        public LocationDefinition GetForestClearingDefintion()
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
                returnData.Name = "Small Forest Clearing";
                returnData.DoLoadLocation = LoadForestClearingEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Narrow Path

        public Location LoadNarrowPath()
        {
            Location returnData;
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_NARROW_PATH_SKELETONS));

            returnData = new Location();
            returnData.Name = "Narrow Path";

            //Actions

            if (defeatedSkeletons == false)
            {
                returnData.Description = "A small narrow path. A red light can be seen in the distance. Skeletons are walking down the path.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += NarrowPathSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletons)
                returnData.Description = "A small narrow path. A red light can be seen in the distance.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetForestClearingDefintion();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            if (defeatedSkeletons)
            {
                locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetMeetingGroundsDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NarrowPathSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_NARROW_PATH_SKELETONS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(NARROW_PATH_KEY);

            }
        }

        public LocationDefinition GetNarrowPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NARROW_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Narrow Path";
                returnData.DoLoadLocation = LoadNarrowPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Meeting Grounds

        public Location LoadMeetingGrounds()
        {
            Location returnData;
            bool defeatedVillagers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFATED_MEETING_GROUNDS_POSSESED_VILLAGERS));
            returnData = new Location();
            returnData.Name = "Meeting Grounds";

            //Actions
            if (defeatedVillagers == false)
            {
                returnData.Description = "A circular enclosing lined with candles against the trees and a smaller circle a few feet from the trees lined with skulls. Two possesed villagers stand in the middle of the inner circle.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> villagers = new List<Mob>();
                villagers.Add(new PossesedVillager());
                villagers.Add(new PossesedVillager());
                CombatAction combatAction = new CombatAction("Possesed Villagers", villagers);
                combatAction.PostCombat += MeetingGroundsVillagers;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedVillagers)
                returnData.Description = "A circular enclosing lined with candles against the trees and a smaller circle a few feet from the trees lined with skulls.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetNarrowPathDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedVillagers)
            {
                locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetDeathCircleDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetEnclosedClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void MeetingGroundsVillagers(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFATED_MEETING_GROUNDS_POSSESED_VILLAGERS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(MEETING_GROUNDS_KEY);

            }
        }

        public LocationDefinition GetMeetingGroundsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MEETING_GROUNDS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Meeting Grounds";
                returnData.DoLoadLocation = LoadMeetingGrounds;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Death Circle

        public Location LoadDeathCircle()
        {
            Location returnData;
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_DEATH_CIRCLE_SKELETONS));

            returnData = new Location();
            returnData.Name = "Death Circle";

            //Actions

            if (defeatedSkeletons == false)
            {
                returnData.Description = "A circular area with skeletons meandering about.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += SkeletonBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletons)
                returnData.Description = "A circular area with crumpled bones littering the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetMeetingGroundsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void SkeletonBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_DEATH_CIRCLE_SKELETONS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DEATH_CIRCLE_KEY);

            }
        }

        public LocationDefinition GetDeathCircleDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DEATH_CIRCLE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Death Circle";
                returnData.DoLoadLocation = LoadDeathCircle;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Enclosed Clearing

        public Location LoadEnclosedClearing()
        {
            Location returnData;
            bool defeatedSkeletonKing = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_POSSESED_GUARD));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.OPENED_BOSS_CHEST_ENCLOSED_CLEARING));

            returnData = new Location();
            returnData.Name = "Enclosed Clearing";

            //Actions

            if (defeatedSkeletonKing == false)
            {
                returnData.Description = "A small enclosed clearing. A cabin sits in the back of it, with a small walkway leading up to its front door. The walk way is lined in skulls and candles. A possesed village guard blocks the door.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new PossesedGuardBoss());
                CombatAction combatAction = new CombatAction("Possesed Guard", guard);
                combatAction.PostCombat += GuardBossBattle;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedSkeletonKing)
            {
                if (openedChest == false)
                {
                    returnData.Description = "A small enclosed clearing. A cabin sits in the back of it, with a small walkway leading up to its front door. The walk way is lined in skulls and candles. The possesed guard lays to rest to the side of the path. His unopened chest appears off to the side.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += GuardChest;
                    returnData.Actions = locationActions;
                }
                else if (openedChest)
                    returnData.Description = "A small enclosed clearing. A cabin sits in the back of it, with a small walkway leading up to its front door. The walk way is lined in skulls and candles. The possesed guard lays to rest to the side of the path. His opened chest sits off to the side.";
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestAfterSewer.GetTownInstance().GetMeetingGroundsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSkeletonKing)
            {
                locationDefinition = WatertownForestCabin.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void GuardBossBattle(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.DEFEATED_POSSESED_GUARD, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENCLOSED_CLEARING_KEY);

            }
        }

        public void GuardChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestAfterSewer.OPENED_BOSS_CHEST_ENCLOSED_CLEARING, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENCLOSED_CLEARING_KEY);

            }
        }

        public LocationDefinition GetEnclosedClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENCLOSED_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Enclosed Clearing";
                returnData.DoLoadLocation = LoadEnclosedClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownForestAfterSewer _WatertownSewer;

        public static WatertownForestAfterSewer GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownForestAfterSewer();
            }

            return _WatertownSewer;
        }

        #endregion
    }
}