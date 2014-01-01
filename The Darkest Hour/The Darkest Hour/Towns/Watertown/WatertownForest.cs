using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownForest : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForest.Entrance";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetForestEntranceDefinition();
        }

        public Location LoadForestEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Watertown Forest Entrance";
            returnData.Description = "A dense yet surprisingly bright forest. You can hear the laughter of the bandits off in the distance (no actions yet).";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationKeys = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();

            adjacentLocationKeys.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationKeys = adjacentLocationKeys;

            return returnData;

        }


        public LocationDefinition GetForestEntranceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Watertown Forest Entrance";
                returnData.DoLoadLocation = LoadForestEntrance;

                Location.AddLocation(returnData);
            }

            return returnData;
        }

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
