using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class AffixSwapperAction : LocationAction
    {
        public AffixSwapperAction()
        {
            this.Name = "Swap Item Affixes";
            this.Description = "Swap Item Affixes";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            GameState.Hero.AffixSwap();

            this.ClearScreen();

            return returnData;
        }
    }
}
