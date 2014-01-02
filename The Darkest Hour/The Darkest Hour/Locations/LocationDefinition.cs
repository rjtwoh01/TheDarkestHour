using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{

    delegate Location LoadLocationHandler();

    class LocationDefinition : GameObject
    {

        public string LocationKey { get; set; }

        public string Name { get; set; }

        public LoadLocationHandler DoLoadLocation;

        private Location _LocationInstance = null;

        public Location LocationInstance
        {
            get
            {
                return DoLoadLocation();

                /*
                if (_LocationInstance == null)
                {
                    if (DoLoadLocation != null)
                    {
                        _LocationInstance = DoLoadLocation();
                    }
                    else
                    {
                        // TODO: Create a specific exception for this eventually
                        throw new Exception(String.Format("Location Load Function not assigned for {0}.",LocationKey));
                    }
                }

                return _LocationInstance;
                */
            }
        }

        public void ResetLocationInstance()
        {
            _LocationInstance = null;
        }

        public LocationDefinition()
        {
        }

        public LocationDefinition(string locationKey, string name, LoadLocationHandler loadLocationFunction)
        {
            this.LocationKey = locationKey;
            this.Name = name;
            this.DoLoadLocation += loadLocationFunction;            
        }
    }
}
