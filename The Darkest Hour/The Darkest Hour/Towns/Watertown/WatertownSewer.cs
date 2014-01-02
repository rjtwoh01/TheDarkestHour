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

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownSewer : Town
    {

        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownSewer.Entrance";
        public const string ENTRANCE_CORRIDOR_KEY = "WatertownSewer.EntranceCorridor";
        public const string ENTRANCE_FINAL_KEY = "WatertownSewer.EntranceFinal";

        public const string VISITED_SEWER_STATE = "VisitedSewer";
        public const string DEFEATED_ENTRANCE_CORRIDOR_SEWER_RATS = "DefeatedCorridorSewerRats";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetSewerEntranceDefinition();
        }

        #region Sewer Entrance

        public Location LoadSewerEntrance()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Watertown Sewer Entrance";
            returnData.Description = "Mud and slime and poopoo.  What a nasty place.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            // Entrance Corridor
            locationDefinition = GetSewerEntranceCorridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, VISITED_SEWER_STATE, true);
            LocationHandler.ResetLocation(Watertown.INN_KEY); // Need to reload Inn so that new conversation can be set.

            return returnData;
        }


        public LocationDefinition GetSewerEntranceDefinition()
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
                returnData.Name = "Watertown Sewer Entrance";
                returnData.DoLoadLocation = LoadSewerEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Sewer Entrance Corridor

        public Location LoadSewerEntranceCorridor()
        {
            Location returnData;
            bool defeatedSewerRats = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewer.DEFEATED_ENTRANCE_CORRIDOR_SEWER_RATS));

            returnData = new Location();
            returnData.Name = "Sewer Entrance Corridor";
            if (defeatedSewerRats)
            {
                returnData.Description = "Mud and slime and poopoo continues (yuck!).  You see two dead sewer rats laying on the sides.";
            }
            else
            {
                returnData.Description = "Mud and slime and poopoo continues (yuck!).  Your path is blocked by sewer rats.";
            }

            if (defeatedSewerRats==false)
            {

                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> sewerRats = new List<Mob>();
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                CombatAction combatAction = new CombatAction("Sewer Rats", sewerRats);
                combatAction.PostCombat += CorridorSewerRatsCombatResults;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }


            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetSewerEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            if (defeatedSewerRats)
            {
                locationDefinition = GetSewerEntranceFinalDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }


        public LocationDefinition GetSewerEntranceCorridorDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_CORRIDOR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Sewer Entrance Corridor";
                returnData.DoLoadLocation = LoadSewerEntranceCorridor;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public void CorridorSewerRatsCombatResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewer.DEFEATED_ENTRANCE_CORRIDOR_SEWER_RATS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_CORRIDOR_KEY);

            }
        }

        #endregion

        #region Sewer Entrance Final

        public Location LoadSewerEntranceFinal()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Sewer Entrance Corridor Final";
            returnData.Description = "The corridor ends here but the mud and slime and poopoo continues (yuck!).  There is a door on the left and right.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetSewerEntranceCorridorDefinition();

            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }


        public LocationDefinition GetSewerEntranceFinalDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_FINAL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Sewer Entrance Corridor Final";
                returnData.DoLoadLocation = LoadSewerEntranceFinal;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }



        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownSewer _WatertownSewer;

        public static WatertownSewer GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownSewer();
            }

            return _WatertownSewer;
        }

        #endregion

    }
}
