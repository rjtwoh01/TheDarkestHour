using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Towns;

namespace The_Darkest_Hour
{
    class GameState
    {
        private static Town _StartingTown;

        public static Player Hero { get; set; }
        public static Location CurrentLocation { get; set; }
        public static Location UpcomingLocation { get; set; }
        public static Town StartingTown
        {
            get
            {
                if (_StartingTown == null)
                {
                    _StartingTown = new The_Darkest_Hour.Towns.Watertown.Watertown();
                }

                return _StartingTown;
            }

        }

        public static Location StartingLocation
        {
            get
            {
                return StartingTown.GetStartingLocation();
            }
        }
    }
}
