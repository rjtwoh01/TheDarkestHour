using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Areas;

namespace The_Darkest_Hour.Locations.Actions
{
    class SellItemsAction : LocationAction
    {
        public SellItemsAction()
        {
            this.Name = "Sell Items";
            this.Description = "Sell Items";
        }


        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            GeneralStore.DoGeneralStore();

            this.ClearScreen();

            return returnData;
        }

    }
}
