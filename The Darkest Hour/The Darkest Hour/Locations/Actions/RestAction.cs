using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Locations.Actions
{
    class RestAction : LocationAction
    {
        public int Cost { get; set; }

        public RestAction(int cost)
        {
            this.Cost = cost;
            if (cost > 0)
            {
                this.Name = String.Format("Rest ({0} gold)", Cost);
            }
            else
            {
                this.Name = "Rest";
            }
            this.Description = "Rest";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            if (GameState.Hero.gold >= this.Cost)
            {
                DarkestHourWindow.WriteLine("You rest and feel refreshed");
                GameState.Hero.ResetHealth();
                GameState.Hero.gold -= this.Cost;
            }
            else
            {
                DarkestHourWindow.WriteLine("Come back when you have more money");
            }

            ClearScreen();

            return returnData;
        }
    }
}
