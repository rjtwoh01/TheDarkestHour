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
            returnData.Description = "A large cluster of tents. There are several necromancers mingling about.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetCookingAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A large cooking area for the necromancers. There are three necromancers and three slaves working on the night's dinner.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetTentClusterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEatingAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A large area for the necromancers to eat their meals. There are make shift tables, crudely cut from wood. Also, there are several logs that haven been evened off for seats placed in several places. There are ten necromancers eating in the area.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetCookingAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetNarrowStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
                returnData.DoLoadLocation = LoadCookingArea;

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
            returnData.Description = "A large clearing, with grotesque displays of hanging bodies off the sides of the path. There is a rather large tent on the back end of the clearing. Four necromancers in elite guard robes stand at the entrance to the tent, blocking all progress forward.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetNarrowStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetLeaderTentDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A large tent, full of many dark items. The necromancer leader sits at his desk, twirling a long, sharp knife in his hand.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetLargeClearingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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