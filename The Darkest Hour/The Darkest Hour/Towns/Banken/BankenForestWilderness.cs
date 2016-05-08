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
    class BankenForestWilderness : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenForestWilderness.Entrance";
        public const string TREACHEROUS_PATH = "Banken.BankenForestWilderness.TreacherousPath";
        public const string BURNT_CLEARING = "Banken.BankenForestWilderness.BurntClearing";
        public const string SPIDERS_HOLLOW = "Banken.BankenForestWilderness.SpidersHollow";
        public const string TREACHEROUS_PATH_TWO = "Banken.BankenForestWilderness.TreacherousPathTwo";
        public const string DENSE_WOODS = "Banken.BankenForestWilderness.DenseWoods";
        public const string WIDE_CREEK = "Banken.BankenForestWilderness.WideCreek";
        public const string CREEK_LANDING = "Banken.BankenForestWilderness.CreekLanding";
        public const string ABANDONED_FORTRESS_GATES = "Banken.BankenForestWilderness.AbandonedFortress";

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
            returnData.Name = "Ashen Forest Wilderness - Strange Opening";
            returnData.Description = "You catch sight of a strange opening in the trees. There's a path beyond it that leads into the unkown wilderness of the forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
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
                returnData.Name = "Ashen Forest Wilderness - Strange Opening";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Treacherous Path

        public Location LoadTreacherousPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Treacherous Path";
            returnData.Description = "The path leading into the wilderness is long, twisty, and very unforgiving to those that travel it. There are several spiders that block the path further";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetBurntClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTrecherousPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TREACHEROUS_PATH;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Treacherous Path";
                returnData.DoLoadLocation = LoadTreacherousPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Burnt Clearing

        public Location LoadBurntClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Burnt Clearing";
            returnData.Description = "A clearing off the side of the path has been burnt to the ground long ago by some ancient evil. The air still reeks from its presence and several shades feed off the dark energy nearby.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetSpidersHollowDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetBurntClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BURNT_CLEARING;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Burnt Clearing";
                returnData.DoLoadLocation = LoadBurntClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Spiders Hollow

        public Location LoadSpidersHollow()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Spider's Hollow";
            returnData.Description = "A large hollow just a small distance from the clearing. The hollow is the home to many of the forest spiders. Thankfully most of them are off elsewhere. ";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetBurntClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSpidersHollowDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SPIDERS_HOLLOW;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Spider's Hollow";
                returnData.DoLoadLocation = LoadSpidersHollow;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Treacherous Path Two

        public Location LoadTreacherousPathTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Treacherous Path 2";
            returnData.Description = "The path continues ever deeper into the forest. A dark presence blocks your progress to the end of the dangerous path.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetDenseWoodsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetWideCreekDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetTrecherousPathTwoDefinintion()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TREACHEROUS_PATH_TWO;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Treacherous Path 2";
                returnData.DoLoadLocation = LoadTreacherousPathTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dense Woods

        public Location LoadDenseWoods()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dense Woods";
            returnData.Description = "The trees just off the path are very dense and could be used to collect wood...\nThere are several spiders roaming about the trees.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDenseWoodsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DENSE_WOODS;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dense Woods";
                returnData.DoLoadLocation = LoadDenseWoods;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region WideCreek

        public Location LoadWideCreek()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Wide Creek";
            returnData.Description = "The creek is very wide and you'll need a small raft to cross it safely.";
            //Once the player builds the raft 6 skeletons will come out from the water to attack him/her.

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetTrecherousPathTwoDefinintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetCreekLandingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetWideCreekDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WIDE_CREEK;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Wide Creek";
                returnData.DoLoadLocation = LoadWideCreek;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Creek Landing

        public Location LoadCreekLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Creek Landing";
            returnData.Description = "The creek landing is small but the air feels much heavier on this side of the water. Shades lurk at the edge of the woods.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetWideCreekDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenForestWilderness.GetTownInstance().GetAbandonedFortressGatesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCreekLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CREEK_LANDING;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Creek Landing";
                returnData.DoLoadLocation = LoadCreekLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Abandoned Fortress Gates

        public Location LoadAbandonedFortressGates()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Abandoned Fortress Gates";
            returnData.Description = "Just beyond the creek landing are the gates to an abandoned fortress. The gates appear sealed shut by some dark magic. A large group of shades hover before the gate to vanquish any that dare approach it.";
            
            //Once the player defeats the shades, have him/her try to open the gate
            //That will fail and a Shade Lord will appear.
            //The player will have to report back to Gilan after defeating the Shade Lord
            //Gilan will then tell the player that (s)he will have to find
            //some very power mages to help him/her blast open the gate

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenForestWilderness.GetTownInstance().GetCreekLandingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetAbandonedFortressGatesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ABANDONED_FORTRESS_GATES;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Abandoned Fortress Gates";
                returnData.DoLoadLocation = LoadAbandonedFortressGates;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenForestWilderness _BankenForestWilderness;

        public static BankenForestWilderness GetTownInstance()
        {
            if (_BankenForestWilderness == null)
            {
                _BankenForestWilderness = new BankenForestWilderness();
            }

            return _BankenForestWilderness;
        }

        #endregion
    }
}