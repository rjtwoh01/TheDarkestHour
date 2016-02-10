using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class DisplayPotionBagAction : LocationAction
    {
        public DisplayPotionBagAction()
        {
            this.Name = "Display Potion Bag";
            this.Description = "Display Potion Bag";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            GameState.Hero.DisplayPotionBag();

            this.ClearScreen();

            return returnData;
        }
    }
}