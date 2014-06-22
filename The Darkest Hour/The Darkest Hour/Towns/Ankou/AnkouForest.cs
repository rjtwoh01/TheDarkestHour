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
    class AnkouForest : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Ankou.AnkouForest.Entrance";
        public const string STRAIGHT_ONE_KEY = "Ankou.AnkouForest.StraightOne";
        public const string STRAIGHT_TWO_KEY = "Ankou.AnkouForest.StraightTwo";
        public const string STRAIGHT_THREE_KEY = "Ankou.AnkouForest.StraightThree";
        public const string STRAIGHT_FOUR_KEY = "Ankou.AnkouForest.StraightFour";
        public const string STRAIGHT_FIVE_KEY = "Ankou.AnkouForest.StraightFive";
        public const string LEFT_ONE_KEY = "Ankou.AnkouForest.LeftOne";
        public const string LEFT_TWO_KEY = "Ankou.AnkouForest.LeftTwo";
        public const string LEFT_THREE_KEY = "Ankou.AnkouForest.LeftThree";
        public const string RIGHT_ONE_KEY = "Ankou.AnkouForest.RightOne";
        public const string RIGHT_TWO_KEY = "Ankou.AnkouForest.RightTwo";
        public const string RIGHT_THREE_KEY = "Ankou.AnkouForest.RightThree";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadAnkouForestEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Entrance";
            returnData.Description = "The long path of the forest begins here. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetStraightOneDefinition();
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
                returnData.Name = "Ankou Forest Entrance";
                returnData.DoLoadLocation = LoadAnkouForestEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Straight One

        public Location LoadStraightOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Straight Path One";
            returnData.Description = "The long path of the forest continues. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetStraightTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Straight Path One";
                returnData.DoLoadLocation = LoadStraightOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Straight Two

        public Location LoadStraightTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Straight Path Two";
            returnData.Description = "The long path of the forest continues. There is now a three way fork in the road. The road splits to the left, right, and continues on straight. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetStraightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetLeftOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetRightOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Straight Path Two";
                returnData.DoLoadLocation = LoadStraightTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Straight Three

        public Location LoadStraightThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Straight Path Three";
            returnData.Description = "The long path of the forest continues. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetStraightFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Straight Path Three";
                returnData.DoLoadLocation = LoadStraightThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Straight Four

        public Location LoadStraightFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Straight Path Four";
            returnData.Description = "The long path of the forest continues. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetStraightFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Straight Path Four";
                returnData.DoLoadLocation = LoadStraightFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Straight Five

        public Location LoadStraightFive()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Straight Path Five";
            returnData.Description = "The long path of the forest continues for as far as eyes can see. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStraightFiveDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STRAIGHT_FIVE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Straight Path Five";
                returnData.DoLoadLocation = LoadStraightFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Left One

        public Location LoadLeftOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Left Path One";
            returnData.Description = "The long path of the forest continues. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetLeftTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLeftOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEFT_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Left Path One";
                returnData.DoLoadLocation = LoadLeftOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Left Two

        public Location LoadLeftTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Left Path Two";
            returnData.Description = "The long path of the forest continues. There is now a three way fork in the road. The road splits to the left, right, and continues on Left. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetLeftOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetLeftThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLeftTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEFT_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Left Path Two";
                returnData.DoLoadLocation = LoadLeftTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Left Three

        public Location LoadLeftThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Left Path Three";
            returnData.Description = "The long path of the forest ends here. There are fallen trees blocking the path. To the side, there are bushes that seems to be blocking a dirt road. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetLeftTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouNecromancerCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLeftThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEFT_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Left Path Three";
                returnData.DoLoadLocation = LoadLeftThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Right One

        public Location LoadRightOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Right Path One";
            returnData.Description = "The long path of the forest continues. Light does not penetrate the trees here, the darkness is all encompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetRightTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRightOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RIGHT_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Right Path One";
                returnData.DoLoadLocation = LoadRightOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Right Two

        public Location LoadRightTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Right Path Two";
            returnData.Description = "The long path of the forest continues. There is now a three way fork in the road. The road splits to the Right, right, and continues on Right. Light does not penetrate the trees here, the darkness is all ecompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetRightOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForest.GetTownInstance().GetRightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRightTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RIGHT_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Right Path Two";
                returnData.DoLoadLocation = LoadRightTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Right Three

        public Location LoadRightThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Forest Right Path Three";
            returnData.Description = "The long path of the forest ends here. There are rocks placed on the path to prevent further travel in this direction. Light does not penetrate the trees here, the darkness is all ecompassing, and the air is crushing.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetRightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetRightThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RIGHT_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Forest Right Path Three";
                returnData.DoLoadLocation = LoadRightThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion


        #endregion

        #region Get Town Instance

        private static AnkouForest _AnkouForest;

        public static AnkouForest GetTownInstance()
        {
            if (_AnkouForest == null)
            {
                _AnkouForest = new AnkouForest();
            }

            return _AnkouForest;
        }

        #endregion
    }
}
