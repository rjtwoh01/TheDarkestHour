using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Areas;

namespace The_Darkest_Hour.Locations.Actions
{
    class StoreAction : LocationAction
    {
        public StoreAction()
        {
            this.Name = "Store";
            this.Description = "Store";
        }


        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            GeneralStore.DoGeneralStore();

            this.ClearScreen();

            return returnData;
        }

    }
}
