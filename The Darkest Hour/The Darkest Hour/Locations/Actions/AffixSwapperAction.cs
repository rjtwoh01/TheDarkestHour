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

            Console.WriteLine("Do you wish to fix up an item you have (1) equipped or (2) in your inventory?");
            string answer = Console.ReadLine();
            do
            {
                if (answer == "1")
                {
                    GameState.Hero.EquippedAffixSwap();
                }
                else
                {
                    GameState.Hero.InventoryAffixSwap();
                }
            } while (answer != "1" && answer != "2");

            this.ClearScreen();

            return returnData;
        }
    }
}
