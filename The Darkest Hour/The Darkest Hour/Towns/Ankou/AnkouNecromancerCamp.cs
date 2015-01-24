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
    class AnkouNecromancerCamp : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouNecromancerCamp.Entrance";
        public const string TENT_CLUSTER_KEY = "Ankou.AnkouNecromancerCamp.TentCluster";
        public const string COOKING_AREA_KEY = "Ankou.AnkouNecromancerCamp.CookingArea";
        public const string EATING_AREA_KEY = "Ankou.AnkouNecromancerCamp.EatingArea";
        public const string NARROW_STAIRS_KEY = "Ankou.AnkouNecromancerCamp.NarrowStairs";
        public const string LARGE_CLEARING_KEY = "Ankou.AnkouNecromancerCamp.LargeClearing";
        public const string LEADER_TENT_KEY = "Ankou.AnkouNecromancerCamp.LeaderTent";
        public const string DEFEATED_CLUSTER_TENT_NECRO = "Ankou.AnkouNecromancerCamp.DefeatedTentClusterNecros";
        public const string DEFEATED_COOKING_AREA_MOBS = "Ankou.AnkouNecromancerCamp.DefeatedCookingAreaMobs";
        public const string DEFEATED_EATING_AREA_MOBS = "Ankou.AnkouNecromancerCamp.DefeatedEatingAreaMobs";
        public const string DEFEATED_CLEARING_ELITE_NECRO_GUARD = "Ankou.AnkouNecromancerCamp.DefeatedEliteNecroGuard";
        public const string DEFEATED_NECRO_LEADER = "Ankou.AnkouNecromancerCamp.DefeatedNecroLeader";
        public const string OPENED_CHEST = "Ankou.AnkouNecromancerCamp.OpenedChest";
        public const string TOOK_JOURNAL = "Ankou.AnkouNecromancerCamp.TookJournal";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadNecroCampHiddenEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Necromancer's Camp Hidden Entrance";
            returnData.Description = "This entrance was hidden by bushes. There are several skulls on pikes placed as a warning to any that stumble upon the entrance accidentally.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetLeftThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetTentClusterDefinition();
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
                returnData.Name = "Necromancer's Camp Hidden Entrance";
                returnData.DoLoadLocation = LoadNecroCampHiddenEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Tent Cluster

        public Location LoadTentCluster()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Tent Cluster";
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_CLUSTER_TENT_NECRO));

            if (!defeatedNecros)
            {
                returnData.Description = "A large cluster of tents. There are several necromancers mingling about.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", necro);
                combatAction.PostCombat += ClusterTentNecros;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecros)
                returnData.Description = "A large cluster of tents. There are several dead necromancer bodies laying bloodied and beaten on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecros)
            {
                locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetCookingAreaDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ClusterTentNecros(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_CLUSTER_TENT_NECRO, true);

                // Reload
                LocationHandler.ResetLocation(TENT_CLUSTER_KEY);

            }
        }

        public LocationDefinition GetTentClusterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TENT_CLUSTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Tent Cluster";
                returnData.DoLoadLocation = LoadTentCluster;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cooking Area

        public Location LoadCookingArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cooking Area";
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_COOKING_AREA_MOBS));

            if (!defeatedNecros)
            {
                returnData.Description = "A large cooking area for the necromancers. There are three necromancers and three slaves working on the night's dinner";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new Necromancer());
                necro.Add(new Slave());
                necro.Add(new Necromancer());
                necro.Add(new Slave());
                necro.Add(new Slave());
                necro.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers and Slaves", necro);
                combatAction.PostCombat += CookingAreaMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecros)
                returnData.Description = "A large cooking area for the necromancers. The blood of the dead is now staining the food and drink.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetTentClusterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecros)
            {
                locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEatingAreaDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void CookingAreaMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_COOKING_AREA_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(COOKING_AREA_KEY);

            }
        }

        public LocationDefinition GetCookingAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COOKING_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cooking Area";
                returnData.DoLoadLocation = LoadCookingArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eating Area

        public Location LoadEatingArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Eating Area";
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_EATING_AREA_MOBS));

            if (!defeatedNecros)
            {
                returnData.Description = "A large area for the necromancers to eat their meals. There are make shift tables, crudely cut from wood. Also, there are several logs that haven been evened off for seats placed in several places. There are ten necromancers eating in the area.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", necro);
                combatAction.PostCombat += EatingAreaMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecros)
                returnData.Description = "A large area for the necromancers to eat their meals. There are make shift tables, crudely cut from wood. Also, there are several logs that haven been evened off for seats placed in several places. The necromancers lay dead with their food growing cold due to no one being there to eat it.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetCookingAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecros)
            {
                locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetNarrowStairsDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EatingAreaMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_EATING_AREA_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(EATING_AREA_KEY);

            }
        }

        public LocationDefinition GetEatingAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EATING_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Eating Area";
                returnData.DoLoadLocation = LoadEatingArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Narrow Stairs

        public Location LoadNarrowStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Narrow Stairs";
            returnData.Description = "A long, but narrow stone stair set leading up to a clearing with a very large tent at the back of it. The stairs are lined with skulls on both borders of the stairs.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEatingAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetLargeClearingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetNarrowStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NARROW_STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Narrow Stairs";
                returnData.DoLoadLocation = LoadNarrowStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Clearing

        public Location LoadLargeClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Clearing";
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_CLEARING_ELITE_NECRO_GUARD));

            if (!defeatedNecros)
            {
                returnData.Description = "A large clearing, with grotesque displays of hanging bodies off the sides of the path. There is a rather large tent on the back end of the clearing. Four necromancers in elite guard robes stand at the entrance to the tent, blocking all progress forward.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new NecromancerEliteGuard());
                necro.Add(new NecromancerEliteGuard());
                necro.Add(new NecromancerEliteGuard());
                necro.Add(new NecromancerEliteGuard());
                CombatAction combatAction = new CombatAction("Necromancer Elite Guard", necro);
                combatAction.PostCombat += ClearingGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecros)
                returnData.Description = "A large clearing, with grotesque displays of hanging bodies off the sides of the path. There is a rather large tent on the back end of the clearing. The crumpled bodies of the necromancer guards are scattered across the clearing. There is no more resistance to the entrance of the tent.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetNarrowStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecros)
            {
                locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetLeaderTentDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ClearingGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_CLEARING_ELITE_NECRO_GUARD, true);

                // Reload
                LocationHandler.ResetLocation(LARGE_CLEARING_KEY);

            }
        }

        public LocationDefinition GetLargeClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Clearing";
                returnData.DoLoadLocation = LoadLargeClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Leader's Tent

        public Location LoadLeaderTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Necromancer Leader's Tent";
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_NECRO_LEADER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.OPENED_CHEST));
            bool takeJournal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.TOOK_JOURNAL));

            if (!defeatedNecros)
            {
                returnData.Description = "A large tent, full of many dark items. The necromancer leader sits at his desk, twirling a long, sharp knife in his hand.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new AnkouNecroLeader());
                CombatAction combatAction = new CombatAction("Necromancer Leader", necro);
                combatAction.PostCombat += NecroLeader;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedNecros)
            {
                if (!openedChest)
                {
                    if (!takeJournal)
                        returnData.Description = "A large tent, full of many dark items. The necromancer leader is dead on the ground. There is a journal on his desk and an unopened treasure chest.";
                    else
                        returnData.Description = "A large tent, full of many dark items. The necromancer leader is dead on the ground. There is an unopened treasure chest.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += Chest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeJournal)
                    returnData.Description = "A large tent, full of many dark items. The necromancer leader is dead on the ground. There is a opened treasure chest.";
                if (!takeJournal && openedChest)
                {
                    returnData.Description = "A large tent, full of many dark items. The necromancer leader is dead on the ground. There is a journal on his desk and an opened treasure chest.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Necromancer Leader's Journal");
                    letterAction.PostItem += LeaderJournal;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetLargeClearingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedNecros && takeJournal)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NecroLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.DEFEATED_NECRO_LEADER, true);

                // Reload
                LocationHandler.ResetLocation(LEADER_TENT_KEY);

            }
        }

        public void Chest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.OPENED_CHEST, true);

                // Reload
                LocationHandler.ResetLocation(LEADER_TENT_KEY);

            }
        }

        public void LeaderJournal(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.TOOK_JOURNAL, true);

                // Reload
                LocationHandler.ResetLocation(LEADER_TENT_KEY);

            }
        }

        public LocationDefinition GetLeaderTentDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEADER_TENT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Necromancer Leader's Tent";
                returnData.DoLoadLocation = LoadLeaderTent;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouNecromancerCamp _AnkouNecromancerCamp;

        public static AnkouNecromancerCamp GetTownInstance()
        {
            if (_AnkouNecromancerCamp == null)
            {
                _AnkouNecromancerCamp = new AnkouNecromancerCamp();
            }

            return _AnkouNecromancerCamp;
        }

        #endregion
    }
}