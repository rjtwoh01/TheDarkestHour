using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;

namespace The_Darkest_Hour.Locations.Actions
{
    class ExitGame : LocationAction
    {
        public ExitGame()
        {
            this.Name = "Exit Game";
            this.Description = "Exit Game";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            Console.WriteLine("Goodbye!");

            return returnData;
        }


    }
}
