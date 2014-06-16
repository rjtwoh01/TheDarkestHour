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
    class AnkouMurderShack : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouMurderShack.Entrance";
        public const string ROOM_TWO_KEY = "Ankou.AnkouMurderShack.RoomTwo";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadForestCabinEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Murderer's Shack";
            returnData.Description = "The room appears as if it is falling aprt. The walls are coming undone and there are giant holes in the ceiling.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //locationDefinition = AnkouMurderShack.GetTownInstance().GetRoomTwoDefinition();
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
                returnData.Name = "Bandit House Entrance";
                returnData.DoLoadLocation = LoadForestCabinEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouMurderShack _AnkouMurderShack;

        public static AnkouMurderShack GetTownInstance()
        {
            if (_AnkouMurderShack == null)
            {
                _AnkouMurderShack = new AnkouMurderShack();
            }

            return _AnkouMurderShack;
        }

        #endregion
    }
}
