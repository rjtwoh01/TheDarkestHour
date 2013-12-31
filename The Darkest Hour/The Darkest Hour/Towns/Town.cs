using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;

namespace The_Darkest_Hour.Towns
{
    abstract class Town : GameObject
    {
        public abstract Location GetStartingLocation();
    }
}
