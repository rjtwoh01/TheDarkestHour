﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class DisplayStatsAction : LocationAction
    {
        public DisplayStatsAction()
        {
            this.Name = "Display Stats";
            this.Description = "Display Stats";
        }

        public override Location DoAction()
        {
            Location returnData = GameState.CurrentLocation;

            GameState.Hero.DisplayStats();

            this.ClearScreen();

            return returnData;
        }


    }
}
