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

        public List<Location> AdjacentLocations { get; set; }

        public void Display()
        {
            Console.WriteLine(String.Format("{0}\n\n", this.Name));

            Console.WriteLine(this.Description);


            char c = 'A';

            if ((this.AdjacentLocations!=null) && (this.AdjacentLocations.Count > 0))
            {
                Console.WriteLine("\nAdjacent Locations:\n");

                foreach (Location adjacentLocation in this.AdjacentLocations)
                {

                    Console.WriteLine(String.Format("\t{0}) {1}", c, adjacentLocation.Name));
                    c++;
                }

            }

            if ((this.Actions != null) && (this.Actions.Count > 0))
            {

                Console.WriteLine("\nActions:\n");

                int i = 0;

                foreach (LocationAction locationAction in this.Actions)
                {
                    i++;
                    Console.WriteLine(String.Format("\t{0}) {1}", i, locationAction.Name));
                }
            }
        }

        public LocationAction GetAction()
        {
            LocationAction returnData;

            string answer = Console.ReadLine();
            int actionIndex;
            char locationIndexChar;
            int locationIndexInt;

            if ((answer != null) && (answer.Length > 0))
            {
                answer = answer.ToUpper();
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
                    // TODO: This is poor way to check for the results (by catching an exception)
                    locationIndexChar = Char.Parse(answer);
                    int aValue = (int)'A';
                    int maxAnswerInt = aValue + this.AdjacentLocations.Count-1;
                    char maxAnswer = (char) maxAnswerInt;
                    if ((locationIndexChar < 'A') || (locationIndexChar > maxAnswer))
                    {
                        returnData = new InvalidSelectionAction();
                    }
                    else
                    {
                        locationIndexInt = Convert.ToInt32(locationIndexChar) - aValue;
                        GameState.UpcomingLocation = this.AdjacentLocations[locationIndexInt];
                        returnData = new MoveLocationAction();
                    }
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
