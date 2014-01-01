using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;

namespace The_Darkest_Hour.Towns
{
    /// <summary>
    /// Town is probably a poor name.  But just any
    /// Area within the game.  A region or some sort.
    /// </summary>
    abstract class Town : GameObject
    {
        public abstract LocationDefinition GetStartingLocationDefinition();
    }
}
