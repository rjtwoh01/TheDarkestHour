using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownForest : Town
    {
        public bool ClearedPath = false;

        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForest.Entrance";
        public const string SIDE_AREA_KEY = "WatertownForest.Side";
        public const string STRAIGHT_AHEAD_KEY = "WatertownForest.Straight";
        public const string CLEARING_KEY = "WatertownForest.Clearing";
        public const string DEFEATED_STRAIGHT_BANDITS_KEY = "DefeatedStraightBandits";
        public const string DEFEATED_BANDIT_CAPTAIN_KEY = "DefeatedBanditCaptain";

        #endregion

        #region Locations


        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetForestEntranceDefinition();
        }

        #region Location Side Area

        public Location LoadSideArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Watertown Forest Side Area";
            returnData.Description = "You move off to a little side area you saw. There is nothing here but more trees.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetStartingLocationDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetSideAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SIDE_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Side Area";
                returnData.DoLoadLocation = LoadSideArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Location Straight

        public Location LoadStraight()
        {
            Location returnData = new Location();
            returnData.Name = "Watertown Forest Straight Path";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForest.DEFEATED_STRAIGHT_BANDITS_KEY));

            if (!defeatedBandits)
                returnData.Description = "You walk forward on the path and encounter bandits. You must conquer them to move on";
            else
                returnData.Description = "The dead bodies of bandits lay strewn across the ground.";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedBandits)
            {
                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());

                CombatAction combatAction = new CombatAction("Bandits",bandits);
                combatAction.PostCombat += StraightBanditResults;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetForestEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = WatertownForest.GetTownInstance().GetClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_AHEAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Straight Path";
                returnData.DoLoadLocation = LoadStraight;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public void StraightBanditResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForest.DEFEATED_STRAIGHT_BANDITS_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DEFEATED_STRAIGHT_BANDITS_KEY);

            }
        }
        #endregion

        #region Location Clearing

        public Location LoadClearing()
        {
            Location returnData = new Location();
            returnData.Name = "Forest Clearing";
            bool defeatedBanditCaptain = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForest.DEFEATED_BANDIT_CAPTAIN_KEY));
            if (!defeatedBanditCaptain)
            {
                returnData.Description = "The Bandit Captain stands in the clearing and stares at you, daring you to challenge him. \nYou can't fight him yet. He is not implemented into the game";
            }
            else
                returnData.Description = "The Bandit Captain lays dead in the clearing";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedBanditCaptain)
            {
                List<Mob> banditCaptain = new List<Mob>();
                banditCaptain.Add(new BanditCaptain());
                CombatAction combatAction = new CombatAction("Bandit Captain", banditCaptain);
                combatAction.PostCombat += BanditCaptainResults;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetStraightDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBanditCaptain)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
                returnData.Name = "Forest Clearing";
                returnData.DoLoadLocation = LoadClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public void BanditCaptainResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForest.DEFEATED_BANDIT_CAPTAIN_KEY, true);

                // Reload the forest clearing
                LocationHandler.ResetLocation(DEFEATED_BANDIT_CAPTAIN_KEY);

            }
        }

        #endregion

        #region Location Entrance

        public Location LoadForestEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Watertown Forest Entrance";
            returnData.Description = "A dense yet surprisingly bright forest. You can hear the laughter of the bandits off in the distance";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForest.GetTownInstance().GetSideAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = WatertownForest.GetTownInstance().GetStraightDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public LocationDefinition GetForestEntranceDefinition()
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
                returnData.Name = "Watertown Forest Entrance";
                returnData.DoLoadLocation = LoadForestEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Entrance

        private static WatertownForest _WatertownForest;

        public static WatertownForest GetTownInstance()
        {
            if (_WatertownForest == null)
            {
                _WatertownForest = new WatertownForest();
            }

            return _WatertownForest;
        }

        #endregion

    }
}
