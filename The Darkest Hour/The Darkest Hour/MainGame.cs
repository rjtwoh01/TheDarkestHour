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
                // Call any pre action events
                locationAction.DoPreAction();

                // Do Action
                LocationDefinition newLocation = locationAction.DoAction(); ;
                
                // Move Location State (only if different
                if (!GameState.PreviousLocation.LocationKey.Equals(GameState.CurrentLocation.LocationKey))
                {
                    GameState.PreviousLocation = GameState.CurrentLocation;
                }
                GameState.CurrentLocation = newLocation;

                // Call any post action events
                locationAction.DoPostAction();

                GameState.CurrentLocation.LocationInstance.Display();
                locationAction = GameState.CurrentLocation.LocationInstance.GetAction();
            }
        }
    }
}