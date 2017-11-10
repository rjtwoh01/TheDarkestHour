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
    class BankenAbandonedFortress : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAbandonedFortress.Entrance";
        public const string WAR_DOG_PEN_KEY = "Banken.BankenAbandonedFortress.WarDogPen";
        public const string BARN_KEY = "Banken.BankenAbandonedFortress.Barn";
        public const string DETERIORATING_STAIRS_KEY = "Banken.BankenAbandonedFortress.DeterioratingStairs";
        public const string GARDEN_KEY = "Banken.BankenAbandonedFortress.Garden";
        public const string ENTRANCE_HALL_KEY = "Banken.BankenAbandonedFortress.EntranceHall";
        public const string SERVANTS_HALL_KEY = "Banken.BankenAbandonedFortress.ServantsHall";
        public const string KITCHEN_KEY = "Banken.BankenAbandonedFortress.Kitchen";
        public const string SERVANTS_QUARTERS_KEY = "Banken.BankenAbandonedFortress.ServantsQuarters";
        public const string OVERSEERS_ROOM_KEY = "Banken.BankenAbandonedFortress.OverseersRoom";
        public const string BASEMENT_LANDING_KEY = "Banken.BankenAbandonedFortress.BasementLanding";
        public const string BASEMENT_HALLWAY_KEY = "Banken.BankenAbandonedFortress.BasementHallway";
        public const string BASEMENT_HALLWAY_TWO_KEY = "Banken.BankenAbandonedFortress.BasementHallwayTwo";
        public const string DARKENED_ROOM_KEY = "Banken.BankenAbandonedFortress.DarkenedRoom";
        public const string PRISON_HALLWAY_KEY = "Banken.BankenAbandonedFortress.PrisonHallway";
        public const string OPPRESSIVE_CELL_KEY = "Banken.BankenAbandonedFortress.OppressiveCell";
        public const string UPSTAIRS_LANDING_KEY = "Banken.BankenAbandonedFortress.UpstairsLanding";
        public const string UPSTAIRS_HALLWAY_KEY = "Banken.BankenAbandonedFortress.UpstairsHallway";
        public const string STORAGE_ROOM_KEY = "Banken.BankenAbandonedFortress.StorageRoom";
        public const string EASTERN_HALLWAY_KEY = "Banken.BankenAbandonedFortress.EasternHallway";
        public const string UPSTAIRS_DINING_HALL_KEY = "Banken.BankenAbandonedFortress.UpstairsDiningHall";
        public const string NORTHERN_HALLWAY_KEY = "Banken.BankenAbandonedFortress.NorthernHallway";
        public const string ENTERTAINMENT_ROOM_KEY = "Banken.BankenAbandonedFortress.EntertainmentRoom";
        public const string NORTH_TOWER_LANDING_KEY = "Banken.BankenAbandonedFortress.NorthTowerLanding";
        public const string LARGE_STUDY_KEY = "Banken.BankenAbandonedFortress.LargeStudy";
        public const string GUEST_LOUNGING_ROOM_KEY = "Banken.BankenAbandonedFortress.GuestLoungingRoom";
        public const string LARGE_GUEST_SUITE_KEY = "Banken.BankenAbandonedFortress.LargeGuestSuite";
        public const string NORTH_TOWER_STAIRS_KEY = "Banken.BankenAbandonedFortress.NorthTowerStairs";
        public const string NORTH_TOWER_PINNACLE_KEY = "Banken.BankenAbandonedFortress.NorthTowerPinnacle";

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
            returnData.Name = "Courtyard";
            returnData.Description = "A large courtyard littered with skeletons. There are statues and impressive fountains placed around the courtyard, monuments to heros long forgotten";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetAbandonedFortressGatesDefinition();
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
                returnData.Name = "Courtyard";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region War Dog Pen

        public Location LoadWarDogPen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ward Dog Pen";
            returnData.Description = "A circular pen, home to war dogs that were bred for the defense of the fortress. The pen is full of the animated skeletons of the war dogs";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWardDogPenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WAR_DOG_PEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "War Dog Pen";
                returnData.DoLoadLocation = LoadWarDogPen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Barn

        public Location LoadBarn()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Barn";
            returnData.Description = "A large barn. Horse armor still hangs on its walls. Skeletons meander about.";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetBarnDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BARN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Barn";
                returnData.DoLoadLocation = LoadBarn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Deteriorating Stairs

        public Location LoadDeterioratingStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Deteriorating Stairs";
            returnData.Description = "The stairs leading up to the fortress door were once grand. They are now crumbling to dust with large holes in them. Skeletons block the path forward";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDeterioratingStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DETERIORATING_STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Deteriorating Stairs";
                returnData.DoLoadLocation = LoadDeterioratingStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Garden

        public Location LoadGarden()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Garden";
            returnData.Description = "A small garden. Its flowers and plants have long since died and returned to the ground.";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetGardenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = GARDEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Garden";
                returnData.DoLoadLocation = LoadGarden;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Entrance Hall

        public Location LoadEntranceHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Entrance Hall";
            returnData.Description = "A grand entrance hall. There are stairs leading upstairs but they are blocked by a magical barrier. Skeletons lay in wait.";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetDeterioratingStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEntranceHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Entrance Hall";
                returnData.DoLoadLocation = LoadEntranceHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Servant's Hallway

        public Location LoadServantsHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Servant's Hallway";
            returnData.Description = "A narrow and unkempt hallway. Several skeletons and stone guards block the way forward";
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAbandonedFortress.GetTownInstance().GetEntranceHallDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetServantsHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SERVANTS_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Servant's Hallway";
                returnData.DoLoadLocation = LoadServantsHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAbandonedFortress _AbandonedFortress;

        public static BankenAbandonedFortress GetTownInstance()
        {
            if (_AbandonedFortress == null)
            {
                _AbandonedFortress = new BankenAbandonedFortress();
            }

            return _AbandonedFortress;
        }

        #endregion
    }
}
