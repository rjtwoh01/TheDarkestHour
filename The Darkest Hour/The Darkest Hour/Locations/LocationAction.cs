using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{
    abstract class LocationAction
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract Location DoAction(Location originalLocation);

    }
}
