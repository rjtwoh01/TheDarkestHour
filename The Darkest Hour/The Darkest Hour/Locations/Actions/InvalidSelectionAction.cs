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

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            Console.WriteLine("\nYou have made an invalid selection.  Please select one of the options above.\n");

            this.ClearScreen();
            
            return returnData;
        }


    }
}
