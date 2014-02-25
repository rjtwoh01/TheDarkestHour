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
    class WatertownSewerLeft : Town
    {

        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownSewerLeft.Entrance";
        public const string ROOM_TWO_KEY = "WatertownSewerLeft.RoomTwo";
        public const string DEFEATED_FIRST_ROOM_RATS = "DefeatedFirstRoomRats";
        public const string TOOK_GOLD_KEY = "TookRoomTwoGold";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetSewerLeftEntranceDefinition();
        }

        #region Sewer Left Entrance

        public Location LoadSewerLeftEntrance()
        {
            Location returnData;
            bool defeatedSewerRats = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_FIRST_ROOM_RATS));

            returnData = new Location();
            returnData.Name = "Watertown Sewer Left";
            returnData.Description = "Mud and slime and poopoo.  What a nasty place.";

            //Actions

            if (defeatedSewerRats == false)
            {

                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> sewerRats = new List<Mob>();
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                sewerRats.Add(new SewerRat());
                CombatAction combatAction = new CombatAction("Sewer Rats", sewerRats);
                combatAction.PostCombat += FirstRoomRats;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceFinalDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedSewerRats)
            {
                locationDefinition = WatertownSewerLeft.GetTownInstance().GetRoomTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void FirstRoomRats(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_FIRST_ROOM_RATS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_KEY);

            }
        }

        public LocationDefinition GetSewerLeftEntranceDefinition()
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
                returnData.Name = "Watertown Sewer Left";
                returnData.DoLoadLocation = LoadSewerLeftEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room 2

        public Location LoadRoomTwo()
        {
            Location returnData;
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.TOOK_GOLD_KEY));

            returnData = new Location();
            returnData.Name = "Yucky Room";
            returnData.Description = "Mud and slime and poopoo.  What a nasty place.";

            //Actions

            if (tookGold == false)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(50);
                locationActions.Add(itemAction);
                itemAction.PostItem += RoomTwoGold;
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceFinalDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.TOOK_GOLD_KEY, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_TWO_KEY);

            }
        }

        public LocationDefinition GetRoomTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Yucky Room";
                returnData.DoLoadLocation = LoadRoomTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownSewerLeft _WatertownSewer;

        public static WatertownSewerLeft GetTownInstance()
        {
            if (_WatertownSewer == null)
            {
                _WatertownSewer = new WatertownSewerLeft();
            }

            return _WatertownSewer;
        }

        #endregion
    }
}
