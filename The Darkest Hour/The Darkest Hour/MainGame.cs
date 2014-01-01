using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Areas;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Towns.StartingArea;

namespace The_Darkest_Hour
{
    class MainGame
    {
        public MainGame()
        {
            DisplayLocations();
        }

        public void DisplayLocations()
        {
            InitialGameMenu initialGameMenu = InitialGameMenu.GetTownInstance();
            GameState.CurrentLocation = initialGameMenu.GetStartingLocationDefinition();


            GameState.CurrentLocation.LocationInstance.Display();
            LocationAction locationAction = GameState.CurrentLocation.LocationInstance.GetAction();

            while(!(locationAction is ExitGame))
            {
                // TODO: might add a check to see if the newLocation
                // is the same the current if so, don't set the previous.
                // There might be some situation where we lose the previous location. 
                // when doing actions that say in the same location (in fact, I'm almost
                // positive this will be an issue).

                // Call any pre action events
                if (locationAction.OnPreAction != null)
                {
                    locationAction.OnPreAction();
                }
                LocationDefinition newLocation = locationAction.DoAction(); ;

                
                GameState.PreviousLocation = GameState.CurrentLocation;
                GameState.CurrentLocation = newLocation;


                // Call any post action events
                if (locationAction.OnPostAction != null)
                {
                    locationAction.OnPostAction();
                }


                GameState.CurrentLocation.LocationInstance.Display();
                locationAction = GameState.CurrentLocation.LocationInstance.GetAction();
            }
        }
    }
}