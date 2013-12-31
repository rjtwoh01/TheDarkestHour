﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class DisplayInventoryAction : LocationAction
    {
        public DisplayInventoryAction()
        {
            this.Name = "Display Inventory";
            this.Description = "Display Inventory";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            Console.WriteLine("Arena not implemented yet.");

            this.ClearScreen();

            return returnData;
        }

    }
}