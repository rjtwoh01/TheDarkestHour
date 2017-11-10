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
    class BankenForestWilderness : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenForestWilderness.Entrance";
        public const string TREACHEROUS_PATH = "Banken.BankenForestWilderness.TreacherousPath";
        public const string BURNT_CLEARING = "Banken.BankenForestWilderness.BurntClearing";
        public const string SPIDERS_HOLLOW = "Banken.BankenForestWilderness.SpidersHollow";
        public const string TREACHEROUS_PATH_TWO = "Banken.BankenForestWilderness.TreacherousPathTwo";
        public const string DENSE_WOODS = "Banken.BankenForestWilderness.DenseWoods";
        public const string WIDE_CREEK = "Banken.BankenForestWilderness.WideCreek";
        public const string CREEK_LANDING = "Banken.BankenForestWilderness.CreekLanding";
        public const string ABANDONED_FORTRESS_GATES = "Banken.BankenForestWilderness.AbandonedFortress";
        public const string TREACHEROUS_PATH_MOBS = "Banken.BankenForestWilderness.TreacherousPathMobs";
        public const string BURNT_CLEARING_MOBS = "Banken.BankenForestWilderness.BurntClearingMobs";
        public const string SPIDERS_HOLLOW_MOBS = "Banken.BankenForestWilderness.SpidersHallowMobs";
        public const string TREACHEROUS_PATH_TWO_MOBS = "Banken.BankenForestWilderness.TreacherousPathTwoMobs";
        public const string DENSE_WOODS_MOBS = "Banken.BankenForestWilderness.DenseWoodsMobs";
        public const string WIDE_CREEK_MOBS = "Banken.BankenForestWilderness.WideCreekMobs";
        public const string BUILD_RAFT = "Banken.BankenForestWilderness.BuildRaft";
        public const string CREEK_LANDING_MOBS = "Banken.BankenForestWilderness.CreekLandingMobs";
        public const string ABANDONED_FORTRESS_MOBS = "Banken.BankenForestWilderness.AbandonedFortressMobs";
        public const string SHADE_LORD = "Banken.BankenForestWilderness.ShadeLord";
        public const string TREASURE = "Banken.BankenForestWilderness.Treasure";
        public const string INSPECT_GATE = "Banken.BankenForestWilderness.InspectGate";
        public const string COLLECT_WOOD_KEY = "Banken.BankenForestWilderness.CollectWood";
        private bool _collectedWood = false;
        private bool _builtRaft = false;

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
            returnData.Name = "Ashen Forest Wilderness - Strange Opening";
            returnData.Description = "You catch sight of a strange opening in the trees. There's a path beyond it that leads into the unkown wilderness of the forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
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
                returnData.Name = "Ashen Forest Wilderness - Strange Opening";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Treacherous Path

        public Location LoadTreacherousPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Treacherous Path";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREACHEROUS_PATH_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The path leading into the wilderness is long, twisty, and very unforgiving to those that travel it. There are several spiders that block the path further";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += TreacherousPathSpiders;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The path leading into the wilderness is long, twisty, and very unforgiving to those that travel it. Giant spider corpses lay decaying on the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetBurntClearingDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TreacherousPathSpiders(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREACHEROUS_PATH_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(TREACHEROUS_PATH);
            }
        }

        public LocationDefinition GetTrecherousPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TREACHEROUS_PATH;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Treacherous Path";
                returnData.DoLoadLocation = LoadTreacherousPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Burnt Clearing

        public Location LoadBurntClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Burnt Clearing";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.BURNT_CLEARING_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A clearing off the side of the path has been burnt to the ground long ago by some ancient evil. The air still reeks from its presence and several shades feed off the dark energy nearby.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += BurntClearingShades;
                locationActions.Add(combatAction); 
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A clearing off the side of the path has been burnt to the ground long ago by some ancient evil. The air still reeks from its presence and there are echoes in the air of banished shades.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetSpidersHollowDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BurntClearingShades(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.BURNT_CLEARING_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(BURNT_CLEARING);
            }
        }

        public LocationDefinition GetBurntClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BURNT_CLEARING;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Burnt Clearing";
                returnData.DoLoadLocation = LoadBurntClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Spiders Hollow

        public Location LoadSpidersHollow()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Spider's Hollow";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.SPIDERS_HOLLOW_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A large hollow just a small distance from the clearing. The hollow is the home to many of the forest spiders. Thankfully most of them are off elsewhere. ";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += SpidersHollowMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large hollow just a small distance from the clearing. The hollow is the home to many of the forest spiders. Thankfully most of them are off elsewhere, though they will be angered when they're greeted by the sight of their dead.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetBurntClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SpidersHollowMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.SPIDERS_HOLLOW_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(SPIDERS_HOLLOW);
            }
        }

        public LocationDefinition GetSpidersHollowDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SPIDERS_HOLLOW;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Spider's Hollow";
                returnData.DoLoadLocation = LoadSpidersHollow;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Treacherous Path Two

        public Location LoadTreacherousPathTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Treacherous Path 2";           
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREACHEROUS_PATH_TWO_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The path continues ever deeper into the forest. A dark presence blocks your progress to the end of the dangerous path.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += TreacherousPathTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The path continues ever deeper into the forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetDenseWoodsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenForestWilderness.GetTownInstance().GetWideCreekDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TreacherousPathTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREACHEROUS_PATH_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(TREACHEROUS_PATH_TWO);
            }
        }

        public LocationDefinition GetTrecherousPathTwoDefinintion()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TREACHEROUS_PATH_TWO;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Treacherous Path 2";
                returnData.DoLoadLocation = LoadTreacherousPathTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dense Woods

        public Location LoadDenseWoods()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dense Woods";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.DENSE_WOODS_MOBS));
            _collectedWood = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, BankenForestWilderness.COLLECT_WOOD_KEY));
            string action = "Collect";
            string itemName = "Wood";
            string actionText = "You chop down several trees to collect wood.";

            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedMobs)
            {
                returnData.Description = "The trees just off the path are very dense and could be used to collect wood...\nThere are several spiders roaming about the trees.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += DenseWoodMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The trees just off the path are very dense and could be used to collect wood...";

            // Location Actions

            if (!_collectedWood && defeatedMobs)
            {
                TakeItemAction itemAction = new TakeItemAction(action, itemName, actionText);
                locationActions.Add(itemAction);
                itemAction.PostItem += WoodResults;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DenseWoodMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.DENSE_WOODS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DENSE_WOODS);
            }
        }

        public void WoodResults(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, BankenForestWilderness.COLLECT_WOOD_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DENSE_WOODS);
            }
        }

        public LocationDefinition GetDenseWoodsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DENSE_WOODS;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dense Woods";
                returnData.DoLoadLocation = LoadDenseWoods;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region WideCreek

        public Location LoadWideCreek()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Wide Creek";            
            //Once the player builds the raft 6 skeletons will come out from the water to attack him/her.
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.WIDE_CREEK_MOBS));
            _builtRaft = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, BankenForestWilderness.BUILD_RAFT));
            _collectedWood = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, BankenForestWilderness.COLLECT_WOOD_KEY));
            string action = "Build";
            string itemName = "Raft";
            string actionText = "You build a raft to cross the creek with the wood you collected. As you complete the small boat several skeletons rise from the water, ready to stop you from proceeding.";

            List<LocationAction> locationActions = new List<LocationAction>();

            // Location Actions

            if (_collectedWood && !_builtRaft)
            {
                returnData.Description = "The creek is very wide and you'll need a small raft to cross it safely.";
                TakeItemAction itemAction = new TakeItemAction(action, itemName, actionText);
                locationActions.Add(itemAction);
                itemAction.PostItem += RaftResults;
                returnData.Actions = locationActions;
            }

            else if (!defeatedMobs & _builtRaft)
            {
                returnData.Description = "The creek is very wide. Skeletons rise from the water, ready to stop whoever dares cross it.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += WideCreekMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The creek is very wide. The shattered bones of skeletons float in the now peaceful water.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (_builtRaft && defeatedMobs)
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetCreekLandingDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WideCreekMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.WIDE_CREEK_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(WIDE_CREEK);
            }
        }

        public void RaftResults(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, BankenForestWilderness.BUILD_RAFT, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(WIDE_CREEK);
            }
        }

        public LocationDefinition GetWideCreekDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WIDE_CREEK;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Wide Creek";
                returnData.DoLoadLocation = LoadWideCreek;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Creek Landing

        public Location LoadCreekLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Creek Landing";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.CREEK_LANDING_MOBS));

            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedMobs)
            {
                returnData.Description = "The creek landing is small but the air feels much heavier on this side of the water. Shades lurk at the edge of the woods.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += CreekLandingMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The creek landing is small but the air feels much heavier on this side of the water.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetWideCreekDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenForestWilderness.GetTownInstance().GetAbandonedFortressGatesDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CreekLandingMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.CREEK_LANDING_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CREEK_LANDING);
            }
        }

        public LocationDefinition GetCreekLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CREEK_LANDING;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Creek Landing";
                returnData.DoLoadLocation = LoadCreekLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Abandoned Fortress Gates

        public Location LoadAbandonedFortressGates()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Abandoned Fortress Gates";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.ABANDONED_FORTRESS_MOBS));
            bool defeatedShadeLord = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.SHADE_LORD));
            bool inspectGate = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.INSPECT_GATE));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREASURE));
            Accomplishment abandonedFortressAccomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Abandoned Fortress"));
            bool abandonedFortress = GameState.Hero.Accomplishments.Contains(abandonedFortressAccomplishment);
            string before = GameState.Hero.Identifier + ", you dare enter my domain? This fortress stands as a testement to my masters. The void shall claim you!";
            string after = "The shade lord cries out a piercing scream as it fades back into the void that spawned it.";
            string action = "Inspect";
            string itemName = "Gate";
            string actionText = "You inspect the gate. It seems to be sealed by very powerful dark magic. You'll have to go back to Banken and see if the rangers know of any mages that could help you unseal the gates. \nBefore you can turn back around to head back to town a Shade Lord materializes at the entrance of the gates and terror fills your heart.";
            
            //Once the player defeats the shades, have him/her try to open the gate
            //That will fail and a Shade Lord will appear.
            //The player will have to report back to Gilan after defeating the Shade Lord
            //Gilan will then tell the player that (s)he will have to find
            //some very power mages to help him/her blast open the gate            

            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedMobs)
            {
                returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic. A large group of shades hover before the gate to vanquish any that dare approach it.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += AbandonedFortressMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!inspectGate)
            {
                returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic.";
                TakeItemAction itemAction = new TakeItemAction(action, itemName, actionText);
                locationActions.Add(itemAction);
                itemAction.PostItem += GateResults;
                returnData.Actions = locationActions;
            }
            else if (!defeatedShadeLord)
            {
                returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic. A Shade Lord hovers before the gates, dark energy radiating from its body in waves.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ShadeLord());
                CombatAction combatAction = new CombatAction("Shade Lord", mobs, before, after);
                combatAction.PostCombat += ShadeLord;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookTreasure)
            {
                returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic. There is a treasure chest in front of the gates.";
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else if (!abandonedFortress)
                returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic.";
            else
                returnData.Description = "Just beyond the creek landing lay the crumpled gates of the Abandoned Fortress. THe gates have crumpled to dust. Whatever magic was sustaining them has imploded on itself.";

            //Once the player gets the mages there will be an action to begin unsealing the gate and then the player can proceed into the "abandoned" fortress

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetCreekLandingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && inspectGate && defeatedShadeLord)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            if (abandonedFortress)
            {
                locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void AbandonedFortressMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.ABANDONED_FORTRESS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(ABANDONED_FORTRESS_GATES);
            }
        }

        public void GateResults(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.INSPECT_GATE, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(ABANDONED_FORTRESS_GATES);
            }
        }

        public void ShadeLord(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.SHADE_LORD, true);

                //Reload 
                LocationHandler.ResetLocation(ABANDONED_FORTRESS_GATES);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(ABANDONED_FORTRESS_GATES);
            }
        }

        public LocationDefinition GetAbandonedFortressGatesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ABANDONED_FORTRESS_GATES;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Abandoned Fortress Gates";
                returnData.DoLoadLocation = LoadAbandonedFortressGates;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenForestWilderness _BankenForestWilderness;

        public static BankenForestWilderness GetTownInstance()
        {
            if (_BankenForestWilderness == null)
            {
                _BankenForestWilderness = new BankenForestWilderness();
            }

            return _BankenForestWilderness;
        }

        #endregion
    }
}