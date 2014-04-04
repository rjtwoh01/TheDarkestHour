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
    class WatertownForestClearingBeforeTower : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForestClearingBeforeTower.Entrance";
        public const string CLEARING_KEY = "WatertownForestClearingBeforeTower.LargeClearing";
        public const string DEFEATED_CLEARING_SKELETONS_GROUP_ONE = "WatertownForestClearingBeforeTower.DefeatedGroupOneSkeletonsClearing";
        public const string DEFEATED_CLEARING_SKELETONS_GROUP_TWO = "WatertownForestClearingBeforeTower.DefeatedGroupTwoSkeletonsClearing";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Cabin Entrance

        public Location LoadNarrowPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Narrow Path";
            returnData.Description = "The path is small and narrow and goes on for a good distance.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetClearingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForestClearingBeforeTower.GetTownInstance().GetClearingDefinition();
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
                returnData.Name = "Narrow Path";
                returnData.DoLoadLocation = LoadNarrowPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Clearing

        public Location LoadClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Circular Clearing";
            bool defeatedBanditsOne = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestClearingBeforeTower.DEFEATED_CLEARING_SKELETONS_GROUP_ONE));
            bool defeatedBanditsTwo = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestClearingBeforeTower.DEFEATED_CLEARING_SKELETONS_GROUP_ONE));

            //Actions

            if (!defeatedBanditsOne)
            {
                returnData.Description = "The clearing is rather large with two groups of bandits roaming about. There is a tower in the middle of the clearing.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += ClearingBanditsOne;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (!defeatedBanditsTwo && defeatedBanditsOne)
            {
                returnData.Description = "The clearing is rather large with one group of bandits roaming about. There is a tower in the middle of the clearing.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += ClearingBanditsTwo;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedBanditsTwo && defeatedBanditsOne)
                returnData.Description = "The clearing is rather large with several dead bodies of bandits strewn across the ground. There is a tower in the middle of the clearing.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownForestClearingBeforeTower.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Add the tower here
            if (defeatedBanditsTwo && defeatedBanditsOne)
            {
                locationDefinition = WatertownForestTower.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ClearingBanditsOne(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestClearingBeforeTower.DEFEATED_CLEARING_SKELETONS_GROUP_ONE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(CLEARING_KEY);

            }
        }

        public void ClearingBanditsTwo(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestClearingBeforeTower.DEFEATED_CLEARING_SKELETONS_GROUP_TWO, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(CLEARING_KEY);

            }
        }

        public LocationDefinition GetClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Circular Clearing";
                returnData.DoLoadLocation = LoadClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownForestClearingBeforeTower _WaterForestCabin;

        public static WatertownForestClearingBeforeTower GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new WatertownForestClearingBeforeTower();
            }

            return _WaterForestCabin;
        }

        #endregion
    }
}