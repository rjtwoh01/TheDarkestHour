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
    class BeachTowerCapturedVillage : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerCapturedVillage.Entrace";
        public const string TOWN_CENTER_KEY = "BeachTower.BeachTowerCapturedVillage.TownCenter";
        public const string MARKET_STREET_KEY = "BeachTower.BeachTowerCapturedVillage.MarketStreet";
        public const string PRISON_KEY = "BeachTower.BeachTowerCapturedVillage.Prison";
        public const string TOWN_HALL_KEY = "BeachTower.BeachTowerCapturedVillage.TownHall";
        public const string HOUSE_DISTRICT_KEY = "BeachTower.BeachTowerCapturedVillage.HouseDistrict";
        public const string MAYORS_HOUSE_KEY = "BeachTower.BeachTowerCapturedVillage.MayorsHouse";

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
            returnData.Name = "Beach Side Village";
            returnData.Description = "A small village located a few miles to the south of the Beach Tower. The village is overrun with bandits who have set several of the buildings ablaze. The smoke rises into the air and can be seen for miles off.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
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
                returnData.Name = "Beach Side Village";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Center

        public Location LoadTownCenter()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Center";
            returnData.Description = "The center of the small village. What used to be a tall monument that represented the pride of the locals now lays shattered on the ground, stained with the blood of unknown victims.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetMarketStreetDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetPrisonDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownHallDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetHouseDistrictDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTownCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_CENTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Market Street

        public Location LoadMarketStreet()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Market Street";
            returnData.Description = "The market street is barely recognizable to those who would have frequented it before. Several of the carts lay broken on the ground and even more are just piles of ash. Several bandits are inspecting the goods that survived the flames.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMarketStreetDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MARKET_STREET_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Market Street";
                returnData.DoLoadLocation = LoadMarketStreet;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Prison

        public Location LoadPrison()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Prison";
            returnData.Description = "A small prison with all of the jail cells broken open. A group of bandits are taunting the guards of the prison who are tied up in the corner and beaten severely.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetPrisonDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = PRISON_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Prison";
                returnData.DoLoadLocation = LoadPrison;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Hall

        public Location LoadTownHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Hall";
            returnData.Description = "A collection of buildings that were the former government buildings of the village are set ablaze, no longer the pillars of society. A group of bandits are feeding the flames, laughing manically.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTownHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Town Hall";
                returnData.DoLoadLocation = LoadTownHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region House District

        public Location LoadHouseDistrict()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "House District";
            returnData.Description = "The house district showcases the true nature of the locals. The houses are all large but simple, reflecting their life style philosophy. Bandits are rounding up some of the villagers and tying them to a wooden post to burn alive.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            //Player must defeat bandits and free villagers to advance
            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetMayorsHouseDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetHouseDistrictDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HOUSE_DISTRICT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "House District";
                returnData.DoLoadLocation = LoadHouseDistrict;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mayor's House

        public Location LoadMayorsHouse()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "The Mayor's House";
            returnData.Description = "At the center of the House District is the Mayor's House. A large house, at least twice as large as the houses that surround it. It looks to be untouched by the bandits, but you can hear screaming from within - as if people are being tortured inside. There is a masked bandit standing calmly at the front of the house preventing access inside.";

            //Add a confront masked bandit action
            //There will be a conversation with the bandit, followed by a brief fight
            //After the fight the bandit will throw out an insult and flee
            //The player will then have to try to get into the house but realize its impossible.
            //There is some type of spell on the house preventing access.
            //The player will have to chase down the masked bandit to figure out how to get in.

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetHouseDistrictDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            //This is just a temporary port back to Beach Tower TownHall for in development testing (since next quest isn't in yet)
            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetMayorsHouseDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MAYORS_HOUSE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Mayor's House";
                returnData.DoLoadLocation = LoadMayorsHouse;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerCapturedVillage _BeachTowerCapturedVillage;

        public static BeachTowerCapturedVillage GetTownInstance()
        {
            if (_BeachTowerCapturedVillage == null)
            {
                _BeachTowerCapturedVillage = new BeachTowerCapturedVillage();
            }

            return _BeachTowerCapturedVillage;
        }

        #endregion
    }
}