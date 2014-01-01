using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{
    public delegate void PreActionHandler();
    public delegate void PostActionHandler();

    abstract class LocationAction
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract LocationDefinition DoAction();

        public PreActionHandler OnPreAction = null;
        public PostActionHandler OnPostAction = null;

        public void PreAction()
        {
            OnPreAction();
        }

        public void PostAction()
        {
            OnPostAction();
        }

        public void ClearScreen()
        {
            ClearScreen(true);
        }

        public void ClearScreen(bool promptToMoveOn)
        {
            if (promptToMoveOn)
            {
                Console.WriteLine("\n\nPress enter to continue on...");
                Console.ReadLine();
            }
            Console.Clear();
        }


    }
}
