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
    class BankenBanditCamp : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenBanditCamp.Entrance";

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
            returnData.Name = "Bandit Camp";
            returnData.Description = "The BanditCamp is much larger than you were led to believe. This camp is located at a major pass through the mountains, were all travelers from the East have to travel through. The bandits have blocked all passage through the camp";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetEasternForestEdgeDefinition();
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
                returnData.Name = "Bandit Camp";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenBanditCamp _BanditCamp;

        public static BankenBanditCamp GetTownInstance()
        {
            if (_BanditCamp == null)
            {
                _BanditCamp = new BankenBanditCamp();
            }

            return _BanditCamp;
        }

        #endregion
    }
}