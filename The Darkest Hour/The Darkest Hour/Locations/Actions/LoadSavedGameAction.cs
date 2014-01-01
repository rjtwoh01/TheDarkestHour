using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns;
using The_Darkest_Hour.Towns.StartingArea;

namespace The_Darkest_Hour.Locations.Actions
{
    class LoadSavedGameAction : LocationAction
    {
        public LoadSavedGameAction()
        {
            this.Name = "Load Saved Game";
            this.Description = "Load Saved Game";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = new InitialGameMenu().GetLoadCharactersMenuDefinition();

            this.ClearScreen(false);

            return returnData;
        }

    }
}