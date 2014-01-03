using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownBanditCave : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownBanditCave.Entrance";
        

        #endregion

        #region Locations

        #region Entrance

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetCaveEntranceDefinition();
        }

        public Location LoadCaveEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Entrance";
            returnData.Description = "A small room covered in dirt and mud. There is a passageway that leads further on into the cave (no actions yet).";

            // Adjacent Locations
            // TODO


            return returnData;

        }

        public LocationDefinition GetCaveEntranceDefinition()
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
                returnData.Name = "Bandit Cave Entrance";
                returnData.DoLoadLocation = LoadCaveEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Entrance

        private static WatertownBanditCave _WatertownBanditCave;

        public static WatertownBanditCave GetTownInstance()
        {
            if (_WatertownBanditCave == null)
            {
                _WatertownBanditCave = new WatertownBanditCave();
            }

            return _WatertownBanditCave;
        }

        #endregion


    }
}
