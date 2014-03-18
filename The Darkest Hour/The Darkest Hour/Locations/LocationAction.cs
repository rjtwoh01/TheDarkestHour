using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Locations
{
    abstract class LocationAction
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract LocationDefinition DoAction();

        public void ClearScreen()
        {
            ClearScreen(true);
        }

        public void ClearScreen(bool promptToMoveOn)
        {
            if (promptToMoveOn)
            {
                DarkestHourWindow.WriteLine("\n\nPress enter to continue on...");
                DarkestHourWindow.ReadLine();
            }

            DarkestHourWindow.Clear();
        }


    }
}
