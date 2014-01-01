using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WaterTownForest : Town
    {
        private Location _ForestEntrance;

        public override Location GetStartingLocation()
        {
            return GetForestEntrance();
        }

        public Location GetForestEntrance()
        {
            Location returnData;

            if (_ForestEntrance == null)
            {
                returnData = new Location();
                returnData.Name = "Watertown Forest Entrance";
                returnData.Description = "A dense yet surprisingly bright forest. You can hear the laughter of the bandits off in the distance (no actions yet).";

                _ForestEntrance = returnData;

                List<Location> adjacentLocations = new List<Location>();
                Watertown watertown = Watertown.GetTownInstance();
                adjacentLocations.Add(watertown.GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;
            }
            else
            {
                returnData = _ForestEntrance;
            }

            return returnData;
        }

        private static WaterTownForest _WaterTownForest;

        public static WaterTownForest GetTownInstance()
        {
            if (_WaterTownForest == null)
            {
                _WaterTownForest = new WaterTownForest();
            }

            return _WaterTownForest;
        }
    }
}
