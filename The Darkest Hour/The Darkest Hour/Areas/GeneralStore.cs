using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Areas
{
    class GeneralStore
    {
        public static void DoGeneralStore() 
        {
            Console.WriteLine("Welcome to the store, you can sell any of your goods here!");
            Console.WriteLine("Or if you're interested, we have some mighty fine goods to buy here!\n\n");

            bool goAgain = false;

            do
            {
                Console.WriteLine("Do you wish to (1) Sell Items or (2) Buy Items?");
                string answer = Console.ReadLine();
                if (answer == "1")
                    SellItems();
                else if (answer == "2")
                    BuyItems();

                Console.WriteLine("Want to go again? (1) Yes (2) No");
                string answerTwo = Console.ReadLine();
                if (answerTwo == "1")
                    goAgain = true;
                else if (answerTwo == "2")
                    goAgain = false;
                else
                    goAgain = true;

            } while (goAgain);

            ClearScreen();
        }

        public static void SellItems()
        {
            bool goAgain = false;

            do
            {
                GameState.Hero.SellItems();
                ClearScreen();

                Console.WriteLine("Want to go again? (1) Yes (2) No");
                string answer = Console.ReadLine();
                if (answer == "1")
                    goAgain = true;
                else if (answer == "2")
                    goAgain = false;
                else
                    goAgain = true;

            } while (goAgain);

            ClearScreen();
        }

        public static void BuyItems()
        {
            bool goAgain = false;
            Loot loot = new Loot();

            do
            {         
                Console.WriteLine("Want to go again? (1) Yes (2) No");
                string answerTwo = Console.ReadLine();
                if (answerTwo == "1")
                    goAgain = true;
                else if (answerTwo == "2")
                    goAgain = false;
                else
                    goAgain = true;
            } while (goAgain);
            ClearScreen();
        }

        public static void ClearScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}