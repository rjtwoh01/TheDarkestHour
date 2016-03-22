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
    class BankenAshenForestRangerPaths : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAshenForestRangerPaths.Entrace";
        public const string SMALL_PATH_KEY = "Banken.BankenAshenForestRangerPaths.SmallPath";
        public const string RANGER_CAMP_KEY = "Banken.BankenAshenForestRangerPaths.RangerCamp";
        public const string BURNT_OPENING_KEY = "Banken.BankenAshenForestRangerPaths.BurntOpening";
        public const string TWISTING_PATH_KEY = "Banken.BankenAshenForestRangerPaths.TwistingPath";
        public const string NARROW_CREEK_KEY = "Banken.BankenAshenForestRangerPaths.NarrowCreek";
        public const string TINY_ISLAND_KEY = "Banken.BankenAshenForestRangerPaths.TinyIsland";
        public const string SMALL_PATH_SPIDERS = "Banken.BankenAshenForestRangerPaths.SmallPathSpiders";
        public const string RANGER_CAMP_SPIRITS = "Banken.BankenAshenForestRangerPaths.RangerCampSpirits";
        public const string HIDING_RANGER = "Banken.BankenAshenForestRangerPaths.HidingRanger";
        public const string LOOK_FOR_PATH = "Banken.BankenAshenForestRangerPath.LookForPath";
        public const string BURNT_OPENING_SHADOW_DEMONS = "Banken.BankenAshenForestRangerPaths.BurntOpeningShadowDemons";
        public const string TWISTING_PATH_SKELETONS = "Banken.BankenAshenForestRangerPaths.TwistingPathSkeletons";
        public const string NARROW_CREEK_WATER_SPIRITS = "Banken.BankenAshenForestRangerPaths.NarrowCreekWaterSpirits";
        public const string GIANT_SHADOW_DEMON = "Banken.BankenAshenForestRangerPaths.GiantShadowDemon";
        public const string TREASURE_CHEST = "Banken.BankenAshenForestRangerPaths.TreasureChest";

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
            returnData.Name = "Ashen Forest - Ranger Paths";
            returnData.Description = "The path splits off into a more natural trail. This path is well traveled by the Banken Rangers as they patrol the forest to keep evil at bay.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetSmallPathDefinition();
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
                returnData.Name = "Ashen Forest - Ranger Paths";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Path

        public Location LoadSmallPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Path";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.SMALL_PATH_SPIDERS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small path branches off from the main patrol road leading to the Ranger's camping grounds. The area is littered with giant spiders.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += SmallPathSpiders;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small path branches off from the main patrol road leading to the Ranger's camping grounds.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetRangerCampDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SmallPathSpiders(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.SMALL_PATH_SPIDERS, true);

                //Reload 
                LocationHandler.ResetLocation(SMALL_PATH_KEY);
            }
        }

        public LocationDefinition GetSmallPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Path";
                returnData.DoLoadLocation = LoadSmallPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ranger Camp

        public Location LoadRangerCamp()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ranger Camp";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.RANGER_CAMP_SPIRITS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small camp with a couple of sleeping bags surrounding a dimly lit fire. The camp seems to have been abandoned not that long ago. There are evil spirits lurking nearby in the shadows cast by the dim flame.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                CombatAction combatAction = new CombatAction("Spirits", mobs);
                combatAction.PostCombat += RangerCampSpirits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small camp with a couple of sleeping bags surrounding a dimly lit fire. The camp seems to have been abandoned not that long ago. The cries of the spirits remains echoing faintly in the air.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetSmallPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetBurntOpeningDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void RangerCampSpirits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.RANGER_CAMP_SPIRITS, true);

                //Reload 
                LocationHandler.ResetLocation(RANGER_CAMP_KEY);
            }
        }

        public LocationDefinition GetRangerCampDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RANGER_CAMP_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ranger Camp";
                returnData.DoLoadLocation = LoadRangerCamp;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Burnt Opening

        public Location LoadBurntOpening()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Burnt Opening";
            bool hiddenRanger = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.HIDING_RANGER));
            bool lookForPath = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.LOOK_FOR_PATH));
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.BURNT_OPENING_SHADOW_DEMONS));

            returnData.Description = "There is a burnt opening in a thick cluster of trees. Within the opening there is a secret ranger path that leads deeper within the forest. Hidden amongst the trees is one of Banken's rangers.";

            List<LocationAction> locationActions = new List<LocationAction>();
            TakeItemAction itemAction = new TakeItemAction("Talk to", "the hidden ranger", "You walk up to the ranger and signal that you're a friend and ask, 'What's going on here? Where's the rest of your company, ranger?' The ranger speaks from his hidden position, 'I don't know where everyone else went. Those spirits came with the darkness. I was knocked out. Next thing I knew everyone was gone and the spirits were still here. I need to stay and see if anyone returns. There is a path nearby. Find it and you should find the answers we both seek.'");
            locationActions.Add(itemAction);
            itemAction.PostItem += HiddenRanger;
            returnData.Actions = locationActions;

            if (hiddenRanger && !lookForPath)
            {
                locationActions = new List<LocationAction>();
                TakeItemAction lookActiopn = new TakeItemAction("Look for ", "the path", "You search around the burnt opening for the path that the ranger spoke of. You find it and make to walk toward it but instead you're assaulted by shadow demons from all sides.");
                locationActions.Add(lookActiopn);
                lookActiopn.PostItem += LookForPath;
                returnData.Actions = locationActions;
            }

            else if (lookForPath && !defeatedMobs)
            {
                locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ShadowDemon());
                mobs.Add(new ShadowDemon());
                mobs.Add(new ShadowDemon());
                mobs.Add(new ShadowDemon());
                mobs.Add(new ShadowDemon());
                CombatAction combatAction = new CombatAction("Shadow Demons", mobs);
                combatAction.PostCombat += BurntOpeningShadowDemons;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestRangerPaths.GetTownInstance().GetRangerCampDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (hiddenRanger && lookForPath && defeatedMobs)
            {
                //Insert code to continue on here
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BurntOpeningShadowDemons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.BURNT_OPENING_SHADOW_DEMONS, true);

                //Reload 
                LocationHandler.ResetLocation(BURNT_OPENING_KEY);
            }
        }

        public void HiddenRanger(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.HIDING_RANGER, true);

                //Reload
                LocationHandler.ResetLocation(BURNT_OPENING_KEY);
            }
        }

        public void LookForPath(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.LOOK_FOR_PATH, true);

                //Reload
                LocationHandler.ResetLocation(BURNT_OPENING_KEY);
            }
        }

        public LocationDefinition GetBurntOpeningDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BURNT_OPENING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Burnt Opening";
                returnData.DoLoadLocation = LoadBurntOpening;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAshenForestRangerPaths _BankenAshenForestRangerPaths;

        public static BankenAshenForestRangerPaths GetTownInstance()
        {
            if (_BankenAshenForestRangerPaths == null)
            {
                _BankenAshenForestRangerPaths = new BankenAshenForestRangerPaths();
            }

            return _BankenAshenForestRangerPaths;
        }

        #endregion
    }
}
