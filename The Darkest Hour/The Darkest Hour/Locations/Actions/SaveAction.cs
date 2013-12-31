using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class SaveAction : LocationAction
    {
        public SaveAction()
        {
            this.Name = "Save";
            this.Description = "Save";
        }

        public override Location DoAction(Location originalLocation)
        {
            Location returnData = originalLocation;

            Console.WriteLine("Sell Items not implemented yet.");

            return returnData;
        }


    }
}
