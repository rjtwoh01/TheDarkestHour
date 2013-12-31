using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class SellItemsAction : LocationAction
    {
        public SellItemsAction()
        {
            this.Name = "Sell Items";
            this.Description = "Sell Items";
        }


        public override Location DoAction(Location originalLocation)
        {
            Location returnData = originalLocation;

            Console.WriteLine("Sell Items not implemented yet.");

            return returnData;
        }

    }
}
