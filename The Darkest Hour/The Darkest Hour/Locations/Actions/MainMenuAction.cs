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

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = new InitialGameMenu().GetStartingLocationDefinition();

            this.ClearScreen(false);

            return returnData;
        }


    }
}

