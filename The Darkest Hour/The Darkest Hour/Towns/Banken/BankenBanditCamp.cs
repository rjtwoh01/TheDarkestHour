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
        public const string BLOCKED_ROAD_MOBS = "Banken.BankenBanditCamp.BlockedRoadMobs";
        public const string BURN_BLOCKADE = "Banken.BankenBanditCamp.BurnBlockade";
        public const string WESTERN_TENTS_MOBS = "Banken.BankenBanditCamp.WesternTentsMobs";
        public const string WESTERN_TENTS_TREASURE = "Banken.BankenBanditCamp.WesternTentsTreasure";
        public const string WESTERN_TENTS_TWO_MOBS = "Banken.BankenBanditCamp.WesternTentsTwoMobs";
        public const string WESTERN_TENTS_TWO_GOLD = "Banken.BankenBanditCamp.WesternTentsTwoGold";
        public const string CAMP_CENTER_MOBS = "Banken.BankenBanditCamp.CampCenterMobs";
        public const string NORTHERN_TENTS_MOBS = "Banken.BankenBanditCamp.NorthernTentsMobs";
        public const string WOODED_EDGE_MOBS = "Banken.BankenBanditCamp.WoodedEdgeMobs";
        public const string EASTERN_TENTS_MOBS = "Banken.BankenBanditCamp.EasternTentsMobs";
        public const string EASTERN_TENTS_TWO_MOBS = "Banken.BankenBanditCamp.EasternTentsTwoMobs";
        public const string MOUNTAIN_STAIRS_MOBS = "Banken.BankenBanditCamp.MountainStairsMobs";
        public const string MOUNTAIN_TENTS_MOBS = "Banken.BankenBanditCamp.MountainTentsMobs";
        public const string MOUNTAIN_TENTS_TWO_MOBS = "Banken.BankenBanditCamp.MountainTentsTwoMobs";
        public const string MOUNTAIN_TENTS_TWO_STOLEN_GOODS = "Banken.BankenBanditCamp.MountainTentsTwoStolenGoods";
        public const string COMMAND_ENCLOUSER_MOBS = "Banken.BankenBanditCamp.CommandEnclouserMobs";
        public const string MATHEW_AND_WILLIAM = "Banken.BankenBanditCamp.MathewAndWilliam";
        public const string TAKE_LETTER = "Banken.BankenBanditCamp.TakeLetter";
        public const string TREASURE = "Banken.BankenBanditCamp.Treasure";

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.BLOCKED_ROAD_MOBS));
            bool burnBlockade = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.BURN_BLOCKADE));

            if (!defeatedMobs)
            {
                returnData.Description = "The bandits have blocked the road leading through the mountains. Four bandits stand gaurd at the barricade";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += BlockedRoadMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!burnBlockade)
            {
                returnData.Description = "The bandits have blocked the road leading through the mountains. The barricade still blocks your path forward";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Burn", "Blockade", "You light a torch and take to the bandit blockade. It goes up in flames within seconds. You watch it burn to the ground.");
                locationActions.Add(itemAction);
                itemAction.PostItem += BurnBlockade;
                returnData.Actions = locationActions;
            }
            else
            {                
                returnData.Description = "The ashes of the bandit blockade litter the ground. The path forward is now clear for travellers.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && burnBlockade)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BlockedRoadMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.BLOCKED_ROAD_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(BLOCKED_ROAD_KEY);
            }
        }

        public void BurnBlockade(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.BURN_BLOCKADE, true);

                //Reload
                LocationHandler.ResetLocation(BLOCKED_ROAD_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_MOBS));
            bool treasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TREASURE));

            if (!defeatedMobs)
            {
                returnData.Description = "The Western tents lay at the edge of the camp. The tents are smaller than the ones further in. These tents just belong to the rank and file. Several bandits are sitting and standing about, laughing and joking with each other.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += WesternTentsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The Western tents lay at the edge of the camp. The tents are smaller than the ones further in. These tents just belong to the rank and file.";
            }

            if (defeatedMobs && !treasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += WesternTentsTreasure;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetBlockedRoadDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsTwoDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WesternTentsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(WESTERN_TENTS_KEY);
            }
        }

        public void WesternTentsTreasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(WESTERN_TENTS_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TWO_MOBS));
            bool gold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TWO_GOLD));

            if (!defeatedMobs)
            {
                returnData.Description = "The Western section of the tents goes further in. As the tents progress closer to the camp center, they grow larger as they belong to more senior bandits.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += WesternTentsTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The Western section of the tents goes further in. As the tents progress closer to the camp center, they grow larger as they belong to more senior bandits. There are several bandits standing about talking with each other. They are joking but there is a more serious look in their eyes as they converse.";
            }

            if (defeatedMobs && !gold)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(1000);
                locationActions.Add(itemAction);
                itemAction.PostItem += WesternTentsTwoGold;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WesternTentsTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(WESTERN_TENTS_TWO_KEY);
            }
        }

        public void WesternTentsTwoGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WESTERN_TENTS_TWO_GOLD, true);

                //Reload
                LocationHandler.ResetLocation(WESTERN_TENTS_TWO_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.CAMP_CENTER_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The center of the camp has large tents belonging to a mix of mercanaries and bandits. The tents stand further a part with a large bonfire in the middle of the camp's center. Mercanaries and bandits are cooking food in the fire.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Bandit());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits and Mercanaries", mobs);
                combatAction.PostCombat += CampCenterMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The center of the camp has large tents belonging to a mix of mercanaries and bandits. The tents stand further a part with a large bonfire in the middle of the camp's center.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetWesternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetNorthernTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CampCenterMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.CAMP_CENTER_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CAMP_CENTER_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.NORTHERN_TENTS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The northern tents belong to a group of mercanaries that joined the larger bandit force recently. The tents are medium sized but modest. There is a large group of mercanaries lazing about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                CombatAction combatAction = new CombatAction("Mercanaries", mobs);
                combatAction.PostCombat += NorthernTentsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The northern tents belong to a group of mercanaries that joined the larger bandit force recently. The tents are medium sized but modest.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetWoodedEdgeDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void NorthernTentsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.NORTHERN_TENTS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(NORTHERN_TENTS_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WOODED_EDGE_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The end of the tents has come and the camp once again fades back into the woods. There are several spiders coming forward, smelling food to eat.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += WoodedEdgeMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The end of the tents has come and the camp once again fades back into the woods. The carcasses of several giant spiders lays rotting on the ground.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetNorthernTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WoodedEdgeMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.WOODED_EDGE_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(WOODED_EDGE_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.EASTERN_TENTS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The eastern tents are medium sized and belong to a mixed group of mercanaries and bandits. The enemies are lounging in their tents, relaxing for the moment. You can sneak by them if you're careful.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Mercanary());
                mobs.Add(new Bandit());
                mobs.Add(new Mercanary());
                CombatAction combatAction = new CombatAction("Bandits and Mercanaries", mobs);
                combatAction.PostCombat += EasternTentsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The eastern tents are medium sized and belong to a mixed group of mercanaries and bandits. The enemies lay dead in their tents";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCampCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void EasternTentsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.EASTERN_TENTS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(EASTERN_TENTS_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.EASTERN_TENTS_TWO_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The eastern edge of the tents goes up to the mountain itself. These tents are quite large and expensive. There are several enemies standing guard, ready to block anyone that wants to pass through. There are two rangers amongst there, deserters of Gilan's Ranger Company";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Ranger());
                mobs.Add(new Ranger());
                CombatAction combatAction = new CombatAction("Bandits, Mercanaries, and Rangers", mobs);
                combatAction.PostCombat += EasternTentsTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The eastern edge of the tents goes up to the mountain itself. These tents are quite large and expensive";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainStairsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void EasternTentsTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.EASTERN_TENTS_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(EASTERN_TENTS_TWO_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_STAIRS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The stairs climb up the mountain, leading to a ledge thats rather high up. A group of mercanaries and rangers patrol the stairs";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                CombatAction combatAction = new CombatAction("Mercanaries", mobs);
                combatAction.PostCombat += MountainStairsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The stairs climb up the mountain, leading to a ledge thats rather high up";
            }
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetEasternTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MountainStairsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_STAIRS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MOUNTAIN_TENTS_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The tents up on a ledge in the mountain are a mix between extravagent tents that belong to rather rich mercanaries and rather small and simple tents belonging to the rangers. There is a group of enemies milling about the area";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Ranger());
                mobs.Add(new Ranger());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());                
                mobs.Add(new Ranger());
                mobs.Add(new Ranger());
                CombatAction combatAction = new CombatAction("Mercanaries and Rangers", mobs);
                combatAction.PostCombat += MountainTentsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The tents up on a ledge in the mountain are a mix between extravagent tents that belong to rather rich mercanaries and rather small and simple tents belonging to the rangers.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsTwoDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MountainTentsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MOUNTAIN_TENTS_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_TWO_MOBS));
            bool retrieveGoods = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_TWO_STOLEN_GOODS));

            if (!defeatedMobs)
            {
                returnData.Description = "These tents are all small and simple, belonging to the ranger deserters. They have boxes of stolen goods piled up next to the tents. There is currently a large group of enemies blocking the way forward";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Ranger());
                mobs.Add(new Ranger());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Mercanary());
                mobs.Add(new Ranger());
                mobs.Add(new Ranger());
                CombatAction combatAction = new CombatAction("Mercanaries and Rangers", mobs);
                combatAction.PostCombat += MountainTentsTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!retrieveGoods)
            {
                returnData.Description = "These tents are all small and simple, belonging to the ranger deserters. They have boxes of stolen goods piled up next to the tents";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Retrieve", "Stolen Goods", "You retrieve the stolen goods to return to the people of Banken");
                locationActions.Add(itemAction);
                itemAction.PostItem += StolenGoods;
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "These tents are all small and simple, belonging to the ranger deserters.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && retrieveGoods)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandEnclouserDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MountainTentsTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MOUNTAIN_TENTS_TWO_KEY);
            }
        }

        public void StolenGoods(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MOUNTAIN_TENTS_TWO_STOLEN_GOODS, true);

                //Reload
                LocationHandler.ResetLocation(MOUNTAIN_TENTS_TWO_KEY);
            }
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.COMMAND_ENCLOUSER_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small enclouser made for the leaders of the camp to discuss task with their elite soldiers. There are currently elite mercanaries and rangers standing guard";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new EliteMercanary());
                mobs.Add(new EliteMercanary());
                mobs.Add(new EliteMercanary());
                mobs.Add(new EliteMercanary());
                mobs.Add(new EliteRanger());
                mobs.Add(new EliteRanger());
                mobs.Add(new EliteRanger());
                mobs.Add(new EliteRanger());
                CombatAction combatAction = new CombatAction("Elite Mercanaries and Elite Rangers", mobs);
                combatAction.PostCombat += CommandEnclouserMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }            
            else
            {
                returnData.Description = "A small enclouser made for the leaders of the camp to discuss task with their elite soldiers.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetMountainTentsTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandTentDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CommandEnclouserMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.COMMAND_ENCLOUSER_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(COMMAND_ENCLOUSER_KEY);
            }
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

        #region Mountain Command Tent

        public Location LoadCommandTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Command Tent";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MATHEW_AND_WILLIAM));
            bool tookLetter = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.TAKE_LETTER));
            bool treasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.TREASURE));
            string before = "As you enter the tent, the two men look up at you. You raise your weapon and yell at William, 'Traitor!'"
               + "\n\nWilliam replies back, 'I am no traitor! I've seen the coming darkness. I will not go down with the rest of you.'" 
               + "\n\nWith that, the two leaders leap forward and attack!";
            string after = "William collapses to the ground, spluttering out blood. He reaches out to grab at you. You bend down and lay a hand on his shoulder, pinning him to the ground. He coughs up blood and splutters out, 'The darkness... It's coming... You cannot fight it.'\n\n He coughs up blood one more time, and then goes silent.";

            if (!defeatedMobs)
            {
                returnData.Description = "A large tent home to the leaders of the mercanaries and rangers. The two leaders, Matthew and William are standing hunched over a table, looking over a map and in deep discussion about an assault that they're planning";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Mathew());
                mobs.Add(new William());
                CombatAction combatAction = new CombatAction("Mathew and William", mobs, before, after);
                combatAction.PostCombat += MathewAndWilliam;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookLetter)
            {
                returnData.Description = "A large tent home to the leaders of the mercanaries and rangers. There is a sealed letter sitting upon the map that Mathew and William were discussing.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Take", "Letter", "You take the letter, resisting the urge to open it. You will look over its contents with Gilan when you head back to Banken");
                locationActions.Add(itemAction);
                itemAction.PostItem += TakeLetter;
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A large tent home to the leaders of the mercanaries and rangers.";
            }

            if (defeatedMobs && tookLetter && !treasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += Treasure;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenBanditCamp.GetTownInstance().GetCommandEnclouserDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && tookLetter)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MathewAndWilliam(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.MATHEW_AND_WILLIAM, true);

                //Reload 
                LocationHandler.ResetLocation(COMMAND_TENT_KEY);
            }
        }

        public void TakeLetter(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.TAKE_LETTER, true);

                //Reload
                LocationHandler.ResetLocation(COMMAND_TENT_KEY);
            }
        }

        public void Treasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenBanditCamp.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(COMMAND_TENT_KEY);
            }
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