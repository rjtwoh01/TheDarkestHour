using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Locations
{
    class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<LocationAction> Actions { get; set; }

        public void Display()
        {
            Console.WriteLine(this.Description);

            int i = 0;

            foreach (LocationAction locationAction in this.Actions)
            {
                i++;
                Console.WriteLine(String.Format("{0}) {1}", i, locationAction.Name));
            }
        }

        public LocationAction GetAction()
        {
            LocationAction returnData;

            string answer = Console.ReadLine();
            int actionIndex;

            if ((answer != null) && (answer.Length > 0))
            {
                try
                {
                    actionIndex = Int32.Parse(answer);
                    if((actionIndex<1) || (actionIndex > this.Actions.Count))
                    {
                        returnData = new InvalidSelectionAction();
                    }
                    else
                    {
                        returnData = this.Actions[--actionIndex];
                    }

                }
                catch
                {
                    returnData = new InvalidSelectionAction();
                }                
            }
            else
            {
                returnData = new InvalidSelectionAction();
            }

            return returnData;
        }

    }
}
