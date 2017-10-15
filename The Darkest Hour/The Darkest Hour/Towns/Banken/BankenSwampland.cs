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
    class BankenSwampland : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenSwampland.Entrance";
        public const string SWAMPY_AREA_ONE_KEY = "Banken.BankenSwampland.SwampyAreaOne";
        public const string CRUMBLED_BUILDING_KEY = "Banken.BankenSwampland.CrumbledBuilding";
        public const string SMALL_GRAVEYARD_KEY = "Banken.BankenSwampland.SmallGraveyard";
        public const string FISHERMANS_DOCK_KEY = "Banken.BankenSwampland.FishermansDock";
        public const string SWAMPY_AREA_TWO_KEY = "Banken.BankenSwampland.SwampyAreaTwo";
        public const string SWAMPY_AREA_THREE_KEY = "Banken.BankenSwampland.SwampyAreaThree";
        public const string RUINED_CASTLE_KEY = "Banken.BankenSwampland.RuinedCastle";
        public const string SWAMPY_AREA_ONE_MOBS = "Banken.BankenSwampland.Entrance";
        public const string CRUMBLED_BUILDING_MOBS = "Banken.BankenSwampland.Entrance";
        public const string SMALL_GRAVEYARD_MOBS = "Banken.BankenSwampland.Entrance";
        public const string FISHERMANS_DOCK_MOBS = "Banken.BankenSwampland.Entrance";
        public const string SWAMPY_AREA_TWO_MOBS = "Banken.BankenSwampland.Entrance";
        public const string SWAMPY_AREA_ACTIVATE_RUINS = "Banken.BankenSwampland.Entrance";
        public const string SWAMPY_AREA_THREE_MOBS = "Banken.BankenSwampland.Entrance";
        public const string RUINED_CASTLE_SHADES = "Banken.BankenSwampland.Entrance";
        public const string MARZEN = "Banken.BankenSwampland.Entrance";
        public const string TREASURE = "Banken.BankenSwampland.Entrance";

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
            returnData.Name = "Swampland";

            returnData.Description = "The swampland is hot and mucky out. It's not a pleasant place to be.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernForestEdgeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaOneDefinition();
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
                returnData.Name = "Swampland";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadSwampyAreaOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area One";

            returnData.Description = "The swamp begins with deep murky water. Water Elementals float about above the ponds";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetCrumbledBuildingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSwampyAreaOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area One";
                returnData.DoLoadLocation = LoadSwampyAreaOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadCrumbledBuilding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Crumbled Building";

            returnData.Description = "A medium sized building lies in ruins in the middle of the swamp. Moss covers the stones of the former building. Shades roam the area.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaOneDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetSmallGraveyardDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCrumbledBuildingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CRUMBLED_BUILDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Crumbled Building";
                returnData.DoLoadLocation = LoadCrumbledBuilding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadSmallGraveyard()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Graveyard";

            returnData.Description = "A small graveyard in the middle of the swamplands for the small population of people that live here. There are a couple tombstones scattered about. Skeletons have risen from the grave and they are accompanied by shades.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetCrumbledBuildingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetFishermansDockDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSmallGraveyardDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_GRAVEYARD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Graveyard";
                returnData.DoLoadLocation = LoadSmallGraveyard;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }


        public Location LoadFishermansDock()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Fisherman's Dock";

            returnData.Description = "A small dock into a large pond. There is a boat loosely tied to a post. Water elementals defend the pond.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSmallGraveyardDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetFishermansDockDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FISHERMANS_DOCK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Fisherman's Dock";
                returnData.DoLoadLocation = LoadFishermansDock;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadSwampyAreaTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area Two";

            returnData.Description = "The pure swampland continues on. The air is thicker and it is harder to breathe. Water elementals roam the area.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetFishermansDockDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSwampyAreaTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area Two";
                returnData.DoLoadLocation = LoadSwampyAreaTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadSwampyAreaThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area Three";

            returnData.Description = "The edge of the swampland. There are giant stones sitting in the middle of a small creek.";
            //returnData.Description = "The edge of the swampland. Shades float menacingly above the ruins";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetRuinedCastleDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSwampyAreaThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area Three";
                returnData.DoLoadLocation = LoadSwampyAreaThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadRuinedCastle()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ruined Castle";

            returnData.Description = "The ruins of a once great castle. Shades stand protecting the ruins. You can hear chanting just behind the stones.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetRuinedCastleDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RUINED_CASTLE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Rruined Castle";
                returnData.DoLoadLocation = LoadRuinedCastle;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion


        #endregion

        #region Get Town Instance

        private static BankenSwampland _InconspicousCave;

        public static BankenSwampland GetTownInstance()
        {
            if (_InconspicousCave == null)
            {
                _InconspicousCave = new BankenSwampland();
            }

            return _InconspicousCave;
        }

        #endregion
    }
}