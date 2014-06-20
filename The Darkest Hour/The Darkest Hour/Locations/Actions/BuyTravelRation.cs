using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class BuyTravelRation : LocationAction
    {
        public BuyTravelRation()
        {
            this.Name = "Travel Rations";
            this.Description = "Buy travel rations";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            int cost = 10 * GameState.Hero.level;
            string answer;
            int count;

            try
            {
                Console.WriteLine("\nYou have {0} gold", GameState.Hero.gold);
                Console.WriteLine("It is {0} gold per ration. How many do you want to buy?", cost);
                answer = Console.ReadLine();
                cost = (Int32.Parse(answer)) * cost;
                count = Int32.Parse(answer);
                if (GameState.Hero.gold >= cost)
                {
                    GameState.Hero.travelRations += count;
                    GameState.Hero.gold -= cost;
                    Console.WriteLine("You buy {0} rations for {1} gold, you now have {2} gold and {3} travel rations", count, cost, GameState.Hero.gold, GameState.Hero.travelRations);
                }
                else
                    Console.WriteLine("You don't have enough money");
            }
            catch(Exception e)
            {
                Console.WriteLine("Uh oh, something went wrong");
                Console.WriteLine("\n" + e.Message + "\n");
            }

            ClearScreen();

            return returnData;
        }
    }
}
