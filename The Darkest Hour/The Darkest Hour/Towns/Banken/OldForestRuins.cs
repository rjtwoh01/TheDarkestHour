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

namespace The_Darkest_Hour.Towns.Banken
{
    class OldForestRuins : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.OldForestRuins.Entrance";

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
            returnData.Name = "Old Forest Ruins";
            returnData.Description = "Ruins of an old town, overcome by the forest. Vines are growing on buildings that have long since crumpled to the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //I haven't decided where to connect this to yet.
            //LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetReligiousShrineClearingDefinition();
            //adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

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
                returnData.Name = "Mage's Retreat Shack";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static OldForestRuins _OldForestRuins;

        public static OldForestRuins GetTownInstance()
        {
            if (_OldForestRuins == null)
            {
                _OldForestRuins = new OldForestRuins();
            }

            return _OldForestRuins;
        }

        #endregion
    }
}