using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items_and_Inventory;

namespace The_Darkest_Hour.Areas
{
    class GeneralStore
    {
        public GeneralStore(Player myHero) 
        { 
            Console.WriteLine("Welcome to the store, you can sell any of your goods here!\n\n");

            bool goAgain = false;

            do
            {
                myHero.SellItems(myHero);
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

        public void ClearScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}