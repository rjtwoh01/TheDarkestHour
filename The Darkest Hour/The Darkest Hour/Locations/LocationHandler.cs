using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{
    class LocationHandler
    {

        #region Location Static Methods
        public static void ResetLocation(LocationDefinition locationDefinition)
        {
            ResetLocation(locationDefinition.LocationKey);
        }

        public static void ResetLocation(string locationKey)
        {
            if (LocationExists(locationKey))
            {
                GetLocation(locationKey).ResetLocationInstance();
            }
        }

        public static bool LocationExists(LocationDefinition locationDefinition)
        {
            return LocationExists(locationDefinition.LocationKey);
        }

        public static bool LocationExists(string locationKey)
        {
            return GameState.GameLocations.ContainsKey(locationKey);
        }

        public static LocationDefinition GetLocation(LocationDefinition locationDefinition)
        {
            return GetLocation(locationDefinition.LocationKey);
        }

        public static LocationDefinition GetLocation(string locationKey)
        {
            return GameState.GameLocations[locationKey];
        }

        public static bool RemoveLocation(LocationDefinition locationDefinition)
        {
            return RemoveLocation(locationDefinition.LocationKey);
        }

        public static bool RemoveLocation(string locationKey)
        {
            return GameState.GameLocations.Remove(locationKey);
        }

        public static void AddLocation(LocationDefinition locationDefinition)
        {
            AddLocation(locationDefinition.LocationKey, locationDefinition);
        }
        public static void AddLocation(string locationKey, LocationDefinition locationDefinition)
        {
            if (LocationHandler.LocationExists(locationKey))
            {
                LocationHandler.RemoveLocation(locationKey);
            }

            GameState.GameLocations.Add(locationKey, locationDefinition);
        }


        #endregion

    }
}
