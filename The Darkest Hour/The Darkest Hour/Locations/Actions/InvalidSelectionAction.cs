using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class InvalidSelectionAction : LocationAction
    {
        public InvalidSelectionAction()
        {
            this.Name = "Invalid Selection";
            this.Description = "Invalid Selection";
        }

        public override Location DoAction(Location originalLocation)
        {
            Location returnData = originalLocation;

            Console.WriteLine("\nYou have made an invalid selection.  Please select one of the options above.\n");
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
            
            return returnData;
        }


    }
}
