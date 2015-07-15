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
    class BeachTowerCatacomb : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerCatacomb.Entrace";
        public const string SMALL_HALLWAY_KEY = "BeachTower.BeachTowerCatacomb.Entrace";
        public const string LEFT_TOMBS_KEY = "BeachTower.BeachTowerCatacomb.LeftTombs";
        public const string RIGHT_TOMBS_KEY = "BeachTower.BeachTowerCatacomb.RightTombs";
        public const string SECRET_PASSAGE_WAY_KEY = "BeachTower.BeachTowerCatacomb.SecretPassageWay";
        public const string SECRET_TOMB_KEY = "BeachTower.BeachTowerCatacomb.SecretTomb";

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
            returnData.Name = "Opened Catacomb";
            returnData.Description = "An opened catacomb. The feeling of evil is seeping within this catacomb";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCemetery.GetTownInstance().GetCatacombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
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
                returnData.Name = "Opened Catacomb";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Hallway

        public Location LoadSmallHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Hallway";
            returnData.Description = "A small hallway in the bottom of the catacomb. There are rooms to the right and left filled with tombs.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetLeftTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetRightTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSmallHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Hallway";
                returnData.DoLoadLocation = LoadSmallHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Left Tombs

        public Location LoadLeftTombs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Left Tombs";
            returnData.Description = "There are tombs stacked one ontop of another against all sides of the wall. There are risen skeletons mingling about.";

            //Add skeletons

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetLeftTombsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEFT_TOMBS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Old Graves";
                returnData.DoLoadLocation = LoadLeftTombs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Right Tombs

        public Location LoadRightTombs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Right Tombs";
            returnData.Description = "There are lots of tombs stacked ontop of eachother on the walls. There are several skeletons meandering around.";

            //Add skeletons

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretPassageWayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetRightTombsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RIGHT_TOMBS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Right Tombs";
                returnData.DoLoadLocation = LoadRightTombs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Secret Passageway

        public Location LoadSecretPassageway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Secret Passageway";
            returnData.Description = "A small secret passageway behind one of the tombs that was cracked open. It doesn't lead far and it looks like there is a large tomb on the other side of it.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetRightTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretTombDefintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSecretPassageWayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SECRET_PASSAGE_WAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Secret Passageway";
                returnData.DoLoadLocation = LoadSecretPassageway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Secret Tomb

        public Location LoadSecretTomb()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Secret Tomb";
            returnData.Description = "A large room with a tomb against the back wall. There is a large mural painting behind the tomb depicting what appears to be a person of royalty. This tomb must belong to a very important person. The masked bandit is kneeling before the tomb, his back turned to you";

            //Add action to confront masked bandit
            //After confronting the masked bandit a necromancer steps out from the shadows and kills the masked bandit
            //Fight the necromancer
            //Killing the necromancer releases the shield on the mayor's house stopping you from getting back.

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretPassageWayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            

            //Figure out where you want the player to go after this
            //Maybe both
            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSecretTombDefintion()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SECRET_TOMB_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Secret Tomb";
                returnData.DoLoadLocation = LoadSecretTomb;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerCatacomb _BeachTowerCatacomb;

        public static BeachTowerCatacomb GetTownInstance()
        {
            if (_BeachTowerCatacomb == null)
            {
                _BeachTowerCatacomb = new BeachTowerCatacomb();
            }

            return _BeachTowerCatacomb;
        }

        #endregion
    }
}
