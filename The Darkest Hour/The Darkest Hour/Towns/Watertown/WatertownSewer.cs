using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownSewer : Town
    {

        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownSewer.Entrance";

        public const string VISITED_SEWER_STATE = "VisitedSewer";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetSewerEntranceDefinition();
        }

        public Location LoadSewerEntrance()
        {
            Location returnData;

            returnData = new Location();
            returnData.Name = "Watertown Sewer Entrance";
            returnData.Description = "Mud and slime and poopoo.  What a nasty place. (no actions yet)";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();

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
