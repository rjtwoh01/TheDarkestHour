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

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            LoadSave.SaveCharacter(GameState.Hero);

            this.ClearScreen();

            return returnData;
        }


    }
}
