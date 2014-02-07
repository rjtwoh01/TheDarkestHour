using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class DisplayEquippedAction : LocationAction
    {
        public DisplayEquippedAction()
        {
            this.Name = "Display Equipped Items";
            this.Description = "Display Equipped Items";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            GameState.Hero.DisplayEquipped();

            this.ClearScreen();

            return returnData;
        }
    }
}
