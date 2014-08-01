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
        public const string DIRTY_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.DirtyRoom";
        public const string SMALL_HOVEL_KEY = "Ankou.AnkouBanditAndNecroCave.SmallHovel";
        public const string LARGE_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.LargeRoom";
        public const string DARK_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.DarkRoom";

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

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDirtyRoomDefinition();
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

        #region Dirty Room

        public Location LoadDirtyRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dirty Room";
            returnData.Description = "A dirty room with six bandits relaxing in it.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetSmallHovelDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetDirtyRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DIRTY_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dirty Room";
                returnData.DoLoadLocation = LoadDirtyRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Hovel

        public Location LoadSmallHovel()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Hovel";
            returnData.Description = "A small hovel that has two bandits and two necromancers discussing future plans.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDirtyRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetLargeRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetSmallHovelDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_HOVEL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Hovel";
                returnData.DoLoadLocation = LoadSmallHovel;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Room

        public Location LoadLargeRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Room";
            returnData.Description = "A large room that has ten necromancers mingling about and discussing various things.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetSmallHovelDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDarkRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLargeRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Room";
                returnData.DoLoadLocation = LoadLargeRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dark Room

        public Location LoadDarkRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dark Room";
            returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle stands a small man with a black hood covering his face. He has his hands outstreched and he's chanting something and the air grows heavier the more he chants.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetLargeRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetDarkRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DARK_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dark Room";
                returnData.DoLoadLocation = LoadDarkRoom;

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
