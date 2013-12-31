using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class MoveLocationAction : LocationAction
    {
        public MoveLocationAction()
        {
            this.Name = "Move Location";
            this.Description = "Move Location";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.UpcomingLocation;

            Console.WriteLine(String.Format("\nYou are moving to {0}.",GameState.UpcomingLocation.Name));

            this.ClearScreen();

            GameState.UpcomingLocation = null;

            return returnData;
        }


    }
}

