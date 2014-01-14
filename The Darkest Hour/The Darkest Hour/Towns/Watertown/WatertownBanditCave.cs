﻿using System;
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
    class WatertownBanditCave : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownBanditCave.Entrance";
        public const string HALLWAY_KEY = "WatertownBanditCave.Hallway";
        public const string DEFEATED_HALLWAY_BANDITS_KEY = "DefeatedHallwayBandits";
        

        #endregion

        #region Locations

        #region Entrance

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetCaveEntranceDefinition();
        }

        public Location LoadCaveEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Cave Entrance";
            returnData.Description = "A small room covered in dirt and mud. There is a passageway that leads further on into the cave.";


            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownForest.GetTownInstance().GetSideAreaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            locationDefinition = WatertownBanditCave.GetTownInstance().GetCaveHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }
    #endregion

        #region Hallway

        public LocationDefinition GetCaveEntranceDefinition()
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
                returnData.Name = "Bandit Cave Entrance";
                returnData.DoLoadLocation = LoadCaveEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location CaveHallway()
        {
            Location returnData;
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCave.DEFEATED_HALLWAY_BANDITS_KEY));
            returnData = new Location();
            returnData.Name = "Bandit Hallway";

            if (defeatedBandits)
            {
                returnData.Description = "A long hallway. Your path is blocked by bandits.";

                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());

                CombatAction combatAction = new CombatAction("Bandits", bandits);
                //combatAction.PostCombat += StraightBanditResults;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A long hallway. Your path is blocked by bandits.";
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCave.GetTownInstance().GetCaveEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;


            return returnData;
        }

        public void HallwayResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCave.DEFEATED_HALLWAY_BANDITS_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DEFEATED_HALLWAY_BANDITS_KEY);

            }
        }

        public LocationDefinition GetCaveHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bandit Cave Hallway";
                returnData.DoLoadLocation = CaveHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Entrance

        private static WatertownBanditCave _WatertownBanditCave;

        public static WatertownBanditCave GetTownInstance()
        {
            if (_WatertownBanditCave == null)
            {
                _WatertownBanditCave = new WatertownBanditCave();
            }

            return _WatertownBanditCave;
        }

        #endregion


    }
}
