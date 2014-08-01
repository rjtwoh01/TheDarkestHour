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
    class AnkouBanditAndNecroCave : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouBanditAndNecroCave.Entrance";

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
            returnData.Name = "Bandit and Necromancer Cave";
            returnData.Description = "A small cave entrance that is hidden from view but noticable if you know to look for it. On the inside is an empty space that makes it look like the cave is really small. However, you know that there is more to the cave and can notice the door that leads to the next room.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetRightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

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
                returnData.Name = "Bandit and Necromancer Cave";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouBanditAndNecroCave _AnkouBanditAndNecroCave;

        public static AnkouBanditAndNecroCave GetTownInstance()
        {
            if (_AnkouBanditAndNecroCave == null)
            {
                _AnkouBanditAndNecroCave = new AnkouBanditAndNecroCave();
            }

            return _AnkouBanditAndNecroCave;
        }

        #endregion
    }
}
