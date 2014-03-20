using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Locations
{
    class Location : GameObject
    {

        #region Location Instance Methods

        public string Name { get; set; }
        public string Description { get; set; }

        public List<LocationAction> Actions { get; set; }

        public Dictionary<string, LocationDefinition> AdjacentLocationDefinitions { get; set; }

        public void Display()
        {
            Console.WriteLine(String.Format("{0}\n\n", this.Name));

            Console.WriteLine(this.Description);

            if ((this.AdjacentLocationDefinitions != null) && (this.AdjacentLocationDefinitions.Count > 0))
            {
                Console.WriteLine("\nAdjacent Locations:\n");

                char c = 'A';

                foreach (LocationDefinition locationDefinition in this.AdjacentLocationDefinitions.Values)
                {

                    Console.WriteLine(String.Format("\t{0}) {1}", c, locationDefinition.Name));
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
                    try
                    {
                        locationIndexChar = Char.Parse(answer);
                        int aValue = (int)'A';
                        int maxAnswerInt = aValue + this.AdjacentLocationDefinitions.Count - 1;
                        char maxAnswer = (char)maxAnswerInt;
                        if ((locationIndexChar < 'A') || (locationIndexChar > maxAnswer))
                        {
                            returnData = new InvalidSelectionAction();
                        }
                        else
                        {
                            locationIndexInt = Convert.ToInt32(locationIndexChar) - aValue;
                            //GameState.UpcomingLocation = this.AdjacentLocations[locationIndexInt];

                            GameState.UpcomingLocation = this.AdjacentLocationDefinitions.Values.ElementAt(locationIndexInt);


                            returnData = new MoveLocationAction();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("You entered something invalid.\n");
                        Console.WriteLine(e.Message + "\n");
                        returnData = new InvalidSelectionAction();
                    }
                }                
            }
            else
            {
                returnData = new InvalidSelectionAction();
            }

            return returnData;
        }

        #endregion

    }
}
