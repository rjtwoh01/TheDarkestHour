using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns.StartingArea;

namespace The_Darkest_Hour.Locations.Actions
{
    class MainMenuAction : LocationAction
    {
        public MainMenuAction()
        {
            this.Name = "Main Menu";
            this.Description = "Main Menu";
        }

        public override Location DoAction()
        {
            Location returnData = new InitialGameMenu().GetStartingLocation();

            this.ClearScreen();

            return returnData;
        }


    }
}

