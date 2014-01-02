using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns.StartingArea;

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

            // Reload the Game Menu location
            LocationHandler.ResetLocation(InitialGameMenu.GAME_MENU_KEY);

            this.ClearScreen();

            return returnData;
        }


    }
}
