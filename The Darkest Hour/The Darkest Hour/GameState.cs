using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Locations;

namespace The_Darkest_Hour
{
    class GameState
    {
        public static Player Hero { get; set; }
        public static Location CurrentLocation { get; set; }
        public static Location UpcomingLocation { get; set; }
    }
}
