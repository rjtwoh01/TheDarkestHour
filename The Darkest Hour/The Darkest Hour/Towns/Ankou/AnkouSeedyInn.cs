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
        public const string LOUNGING_ROOM_KEY = "Ankou.AnkouSeedyInn.LoungingRoom";
        public const string KITCHEN_KEY = "Ankou.AnkouSeedyInn.Kitchen";
        public const string STAIRS_KEY = "Ankou.AnkouSeedyInn.Stairs";
        public const string BASEMENT_LANDING_KEY = "Ankou.AnkouSeedyInn.BasementLanding";
        public const string STORAGE_KEY = "Ankou.AnkouSeedyInn.Storage";
        public const string TORTURE_CHAMBER_KEY = "Ankou.AnkouSeedyInn.TortureChamber";

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

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetLoungingRoomDefinition();
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
                returnData.Name = "Ankou Seedy Inn";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Lounging Room

        public Location LoadLoungingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Lounging Room";
            returnData.Description = "A small lounging room with a torn couch and a broken fire place. There are two drunk peasants sitting on the couch arguing with each other.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLoungingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LOUNGING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Lounging Room";
                returnData.DoLoadLocation = LoadLoungingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";
            returnData.Description = "A small kitchen with old rusty equipment. There are four peasants trying to cook old moldy food.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetLoungingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetKitchenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = KITCHEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadKitchen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Stairs

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";
            returnData.Description = "A small narrow stair case. There are individual stairs that are either missing or that have holes in them.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetBasementLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Stairs";
                returnData.DoLoadLocation = LoadStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region BasementLanding

        public Location LoadBasementLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Basement Landing";
            returnData.Description = "A small landing at the stairs. There are several bandits waiting to greet you.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetStorageDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetBasementLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BASEMENT_LANDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Basement Landing";
                returnData.DoLoadLocation = LoadBasementLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage

        public Location LoadStorage()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage";
            returnData.Description = "A small room with shabby boxes. There are two bandits sorting through them.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetBasementLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetTortureChamberDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStorageDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage";
                returnData.DoLoadLocation = LoadStorage;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Torture Chamber

        public Location LoadTortureChamber()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Torture Chamber";
            returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is what can only be the Bandit Torturer.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetStorageDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetTortureChamberDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TORTURE_CHAMBER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Torture Chamber";
                returnData.DoLoadLocation = LoadTortureChamber;

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
