using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{
    class LocationHandler
    {

        #region Location State Static Methods

        public static bool LocationStateExists(string locationStateKey)
        {
            return GameState.GameLocations.ContainsKey(locationStateKey);
        }

        public static void AddLocationState(string locationStateKey, LocationState locationState)
        {
            if (LocationHandler.LocationExists(locationStateKey))
            {
                LocationHandler.RemoveLocation(locationStateKey);
            }

            GameState.GameLocationStates.Add(locationStateKey, locationState);
        }

        public static LocationState GetLocationState(string locationStateKey)
        {
            LocationState returnData;

            if (LocationStateExists(locationStateKey))
            {
                returnData = GameState.GameLocationStates[locationStateKey];
            }
            else
            {
                // TODO: When saving Game Location States is implemented
                // then this method should check if the game location state
                // saved file exists.  If so, it should load the file
                // otherwise it should create a new LocationStates file.
                returnData = new LocationState();
                GameState.GameLocationStates.Add(locationStateKey, returnData);
            }

            return returnData;
        }

        #endregion

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
