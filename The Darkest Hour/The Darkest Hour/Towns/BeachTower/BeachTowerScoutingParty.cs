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
    class BeachTowerScoutingParty : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTownScoutingParty.Entrace";
        public const string FOREST_PATH_KEY = "BeachTower.BeachTownScoutingParty.ForestPath";
        public const string TENT_ENTRANCE_KEY = "BeachTower.BeachTownScoutingParty.TentEntrance";
        public const string TENT_CLUSTER_KEY = "BeachTower.BeachTownScoutingParty.TentCluster";
        public const string SCOUT_LEADER_TENT_KEY = "BeachTower.BeachTownScoutingParty.ScoutLederTent";
        public const string FOREST_PATH_MOBS = "BeachTower.BeachTownScoutingParty.ForestPathMobs";
        public const string TENT_ENTRANCE_MOBS = "BeachTower.BeachTownScoutingParty.TentEntranceMobs";
        public const string TENT_CLUSTER_MOBS = "BeachTower.BeachTownScoutingParty.TentClusterMobs";
        public const string SCOUT_LEADER = "BeachTower.BeachTownScoutingParty.ScoutLeader";
        public const string TREASURE = "BeachTower.BeachTownScoutingParty.Treasure";

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
            returnData.Name = "Scouting Party Landing Area";
            returnData.Description = "The landing area for the scouting party. There are a few small boats washed up on the shore, and a few abandoned supplies. The forest begins to the right and there are foot prints leading into it.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBeachHead.GetTownInstance().GetPathNorthDefintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetForestPathDefinition();
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
                returnData.Name = "Scouting Party Landing Area";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Forest Path

        public Location LoadForestPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Forest Path";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.FOREST_PATH_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small forest path that leads from the beach head to whereabouts unknown. There are a few scouts straggling behind the main group walking down the path.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                CombatAction combatAction = new CombatAction("Scouts", mobs);
                combatAction.PostCombat += ForestPathMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small forest path that leads from the beach head to whereabouts unknown.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetTentEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void ForestPathMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.FOREST_PATH_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(FOREST_PATH_KEY);
            }
        }

        public LocationDefinition GetForestPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOREST_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Forest Path";
                returnData.DoLoadLocation = LoadForestPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Tent Entrance

        public Location LoadTentEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Tent Entrance";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TENT_ENTRANCE_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The start of the tents is a little bit down the forest path. There aren't that many tents, this must be a small scouting party. There are a few scouts guarding the entrance.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                CombatAction combatAction = new CombatAction("Scouts", mobs);
                combatAction.PostCombat += TentEntranceMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The start of the tents is a little bit down the forest path. There aren't that many tents, this must be a small scouting party.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetForestPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetTentClusterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TentEntranceMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TENT_ENTRANCE_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(TENT_ENTRANCE_KEY);
            }
        }

        public LocationDefinition GetTentEntranceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TENT_ENTRANCE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Tent Entrance";
                returnData.DoLoadLocation = LoadTentEntrance;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TENT_CLUSTER_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The main group of tents is loosely clustered together. There are scouts mingling about, preparing for whatever activity they have planned.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                mobs.Add(new Scout());
                CombatAction combatAction = new CombatAction("Scouts", mobs);
                combatAction.PostCombat += TentClusterMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The main group of tents is loosely clustered together. There are dead scouts all over the camp.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetTentEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetScoutLeaderTentDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TentClusterMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TENT_CLUSTER_MOBS, true);

                //Reload 
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

        #region Scout Leader's Tent

        public Location LoadScoutLeaderTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Scout Leader's Tent";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.SCOUT_LEADER));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TREASURE));

            string before = "The Scout Leader looks up from his maps and smiles evily at you. He walks up to you saying, ''Well, well, well. If it isn't, " + GameState.Hero.Identifier + ". You think you're going to stop the invasion? You're a fool, " + GameState.Hero.Identifier + ". There is no way you are going to stop the storm that is to come. Blood will fall in Asku. And there is nothing you can do to stop it.''";
            string after = "The Scout Leader collapses to the ground, coughing up blood. With his last breath he looks up to you and gasp out, ''You think... This changes things? We sail toward Asku now. The Beach Head will fall first. Then the whole country. Beware the dawn.''";

            if (!defeatedMobs)
            {
                returnData.Description = "The scout leaders tent is located at the eastern edge of the tent cluster. The Scout Leader is inside pouring over maps of Asku.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ScoutLeader());
                CombatAction combatAction = new CombatAction("Scout Leader", mobs, before, after);
                combatAction.PostCombat += ScoutLeader;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookTreasure)
            {
                returnData.Description = "The scout leaders tent is located at the eastern edge of the tent cluster. The Scout Leader lies dead in the middle of his tent. There is an unopened treasure chest on the side of the tent.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The scout leaders tent is located at the eastern edge of the tent cluster. The Scout Leader lies dead in the middle of his tent.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerScoutingParty.GetTownInstance().GetTentClusterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void ScoutLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.SCOUT_LEADER, true);

                //Reload 
                LocationHandler.ResetLocation(SCOUT_LEADER_TENT_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerScoutingParty.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(SCOUT_LEADER_TENT_KEY);
            }
        }

        public LocationDefinition GetScoutLeaderTentDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SCOUT_LEADER_TENT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Scout Leader's Tent";
                returnData.DoLoadLocation = LoadScoutLeaderTent;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerScoutingParty _BeachTownScoutingParty;

        public static BeachTowerScoutingParty GetTownInstance()
        {
            if (_BeachTownScoutingParty == null)
            {
                _BeachTownScoutingParty = new BeachTowerScoutingParty();
            }

            return _BeachTownScoutingParty;
        }

        #endregion
    }
}
