using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class PickUpPaperAction : LocationAction
    {
        public PickUpPaperAction()
        {
            this.Name = "Pick Up Papers";
            this.Description = "Pick Up Papers";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            Console.WriteLine("\nYou pick up the papers.\n");

            this.ClearScreen();

            return returnData;
        }
    }
}
