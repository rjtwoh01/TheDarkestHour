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
using The_Darkest_Hour.Characters.Mobs.Bosses.Banken;
using The_Darkest_Hour.Common;
namespace The_Darkest_Hour.Towns.Watertown
{
    class BankenBanditCamp : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenBanditCamp.Entrance";
        public const string BLOCKED_ROAD_KEY = "Banken.BankenBanditCamp.BlockedRoad";
        public const string WESTERN_TENTS_KEY = "Banken.BankenBanditCamp.WesternTents";
        public const string WESTERN_TENTS_TWO_KEY = "Banken.BankenBanditCamp.WesternTentsTwo";
        public const string CAMP_CENTER_KEY = "Banken.BankenBanditCamp.CampCenter";
        public const string NORTHERN_TENTS_KEY = "Banken.BankenBanditCamp.NorthernTents";
        public const string WOODED_EDGE_KEY = "Banken.BankenBanditCamp.WoodedEdge";
        public const string EASTERN_TENTS_KEY = "Banken.BankenBanditCamp.EasternTents";
        public const string EASTERN_TENTS_TWO_KEY = "Banken.BankenBanditCamp.EasternTentsTwo";
        public const string MOUNTAIN_STAIRS_KEY = "Banken.BankenBanditCamp.StairsUpMountain";
        public const string MOUNTAIN_TENTS_KEY = "Banken.BankenBanditCamp.MountainTents";
        public const string MOUNTAIN_TENTS_TWO_KEY = "Banken.BankenBanditCamp.MountainTentsTwo";
        public const string COMMAND_ENCLOUSER_KEY = "Banken.BankenBanditCamp.CommandEnclouser";
        public const string COMMAND_TENT_KEY = "Banken.BankenBanditCamp.CommandTent";

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
            returnData.Name = "Bandit Camp";
            returnData.Description = "The BanditCamp is much larger than you were led to believe. This camp is located at a major pass through the mountains, were all travelers from the East have to travel through. The bandits have blocked all passage through the camp";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestEdgeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetBlockedRoadDefinition();
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
                returnData.Name = "Bandit Camp";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Blocked Road

        public Location LoadBlockedRoad()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Blocked Road";
            returnData.Description = "The bandits have blocked the road leading through the mountains. Four bandits stand gaurd at the barricade";            

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetBlockedRoadDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BLOCKED_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Blocked Road";
                returnData.DoLoadLocation = LoadBlockedRoad;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Western Tents

        public Location LoadWesternTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Western Tents";
            returnData.Description = "The Western tents lay at the edge of the camp. The tents are smaller than the ones further in. These tents just belong to the rank and file. Several bandits are sitting and standing about, laughing and joking with each other.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetBlockedRoadDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWesternTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WESTERN_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Western Tents";
                returnData.DoLoadLocation = LoadWesternTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Western Tents Two

        public Location LoadWesternTentsTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Western Tents 2";
            returnData.Description = "The Western section of the tents goes further in. As the tents progress closer to the camp center, they grow larger as they belong to more senior bandits. There are several bandits standing about talking with each other. They are joking but there is a more serious look in their eyes as they converse.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWesternTentsTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WESTERN_TENTS_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Western Tents 2";
                returnData.DoLoadLocation = LoadWesternTentsTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Camp Center

        public Location LoadCampCenter()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Camp Center";
            returnData.Description = "The center of the camp has large tents belonging to a mix of mercanaries and bandits. The tents stand further a part with a large bonfire in the middle of the camp's center. Mercanaries and bandits are cooking food in the fire.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetNorthernTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCampCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CAMP_CENTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Camp Center";
                returnData.DoLoadLocation = LoadCampCenter;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Northern Tents

        public Location LoadNorthernTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Northern Tents";
            returnData.Description = "The northern tents belong to a group of mercanaries that joined the larger bandit force recently. The tents are medium sized but modest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetWoodedEdgeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetNorthernTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTHERN_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Northern Tents";
                returnData.DoLoadLocation = LoadNorthernTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Camp Center

        public Location LoadWoodedEdge()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Wooded Edge";
            returnData.Description = "The end of the tents has come and the camp once again fades back into the woods. There are several spiders coming forward, smelling food to eat.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetNorthernTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWoodedEdgeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WOODED_EDGE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Wooded Edge";
                returnData.DoLoadLocation = LoadWoodedEdge;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eastern Tents

        public Location LoadEasternTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Eastern Tents";
            returnData.Description = "The eastern tents are medium sized and belong to a mixed group of mercanaries and bandits. The enemies are lounging in their tents, relaxing for the moment. You can sneak by them if you're careful.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEasternTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Eastern Tents";
                returnData.DoLoadLocation = LoadEasternTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Eastern Tents Two

        public Location LoadEasternTentsTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Eastern Tents 2";
            returnData.Description = "The eastern edge of the tents goes up to the mountain itself. These tents are quite large and expensive. There are several enemies standing guard, ready to block anyone that wants to pass through. There are two rangers amongst there, deserters of Gilan's Ranger Company";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEasternTentsTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EASTERN_TENTS_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Eastern Tents 2";
                returnData.DoLoadLocation = LoadEasternTentsTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mountain Stairs

        public Location LoadMountainStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Mountain Stairs";
            returnData.Description = "The stairs climb up the mountain, leading to a ledge thats rather high up. A large group of mercanaries and rangers patrol the stairs";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMountainStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MOUNTAIN_STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Mountain Stairs";
                returnData.DoLoadLocation = LoadMountainStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mountain Tents

        public Location LoadMountainTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Mountain Tents";
            returnData.Description = "The tents up on a ledge in the mountain are a mix between extravagent tents that belong to rather rich mercanaries and rather small and simple tents belonging to the rangers.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMountainTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MOUNTAIN_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Mountain Tents";
                returnData.DoLoadLocation = LoadMountainTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mountain Tents Two

        public Location LoadMountainTentsTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Mountain Tents 2";
            returnData.Description = "These tents are all small and simple, belonging to the ranger deserters. They havve boxes of stolen goods piled up next to the tents";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandEnclouserDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMountainTentsTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MOUNTAIN_TENTS_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Mountain Tents 2";
                returnData.DoLoadLocation = LoadMountainTentsTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mountain Tents Two

        public Location LoadCommandEnclouser()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Command Enclouser";
            returnData.Description = "A small enclouser made for the leaders of the camp to discuss task with their elite soldiers. There are currently elite mercanaries and rangers standing guard";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandTentDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCommandEnclouserDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COMMAND_ENCLOUSER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Command Enclouser";
                returnData.DoLoadLocation = LoadCommandEnclouser;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mountain Tents Two

        public Location LoadCommandTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Command Tent";
            returnData.Description = "A large tent home to the leaders of the mercanaries and rangers. The two leaders, Matthew and William are standing hunched over a table, looking over a map and in deep discussion about an assault that they're planning";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandEnclouserDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCommandTentDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COMMAND_TENT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Command Tent";
                returnData.DoLoadLocation = LoadCommandTent;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenBanditCamp _BanditCamp;

        public static BankenBanditCamp GetTownInstance()
        {
            if (_BanditCamp == null)
            {
                _BanditCamp = new BankenBanditCamp();
            }

            return _BanditCamp;
        }

        #endregion
    }
}