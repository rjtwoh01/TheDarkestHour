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
    class AnkouSeedyInn : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouSeedyInn.Entrance";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Seedy Inn";
            returnData.Description = "A run down dirty inn used by the scum of society for black market trade and backdoor dealings. The place gives off a very bad vibe and is avoided by decent people. The entrance is falling apart and smells of old dried blood.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //locationDefinition = AnkouSeedyInn.GetTownInstance().GetLoungingRoomDefinition();
            //adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

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
                returnData.Name = "Ankou Seedy Inn";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouSeedyInn _AnkouSeedyInn;

        public static AnkouSeedyInn GetTownInstance()
        {
            if (_AnkouSeedyInn == null)
            {
                _AnkouSeedyInn = new AnkouSeedyInn();
            }

            return _AnkouSeedyInn;
        }

        #endregion
    }
}
