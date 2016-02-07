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
