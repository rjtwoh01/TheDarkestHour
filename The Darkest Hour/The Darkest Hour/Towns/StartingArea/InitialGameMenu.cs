﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;

namespace The_Darkest_Hour.Towns.StartingArea
{
    class InitialGameMenu : Town
    {

        #region Location Keys
        // Not really happy with this design but it works.
        public const string GAME_MENU_KEY = "InitialGameMenu.GameMenu";
        public const string LOAD_CHARACTER_MENU_KEY = "InitialGameMenu.LoadCharacterMenu";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetGameMenuDefinition();
        }

        public Location LoadLoadCharacterMenu()
        {
            Location returnData;
            LocationAction locationAction;

            returnData = new Location();
            returnData.Name = "Load Character";
            returnData.Description = "Please choose a character to load.";

            List<LocationAction> locationActions = LoadSave.GetSavedCharacters();

            locationAction = new MainMenuAction();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            return returnData;
        }

        public LocationDefinition GetLoadCharactersMenuDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LOAD_CHARACTER_MENU_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {

                returnData.LocationKey = locationKey;
                returnData.Name = "Load Character";
                returnData.DoLoadLocation = LoadLoadCharacterMenu;

                Location.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadGameMenu()
        {
            Location returnData;
            LocationAction locationAction;

            returnData = new Location();
            returnData.Name = "Game Menu";
            returnData.Description = "Please choose an initial starting action.";

            List<LocationAction> locationActions = new List<LocationAction>();

            locationAction = new CreateNewCharacterAction();
            locationActions.Add(locationAction);

            // TODO: There should be a defect where if a new game is started
            // and there is no saved games and then you save a game, this menu
            // option will be hidden until the game is reloaded.
            // To fix, just remove this location from the Game Locations
            // when someone saves.
            if (LoadSave.SavedGameExists())
            {
                locationAction = new LoadSavedGameAction();
                locationActions.Add(locationAction);
            }

            locationAction = new ExitGame();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            return returnData;
        }


        public LocationDefinition GetGameMenuDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();

            string locationKey = GAME_MENU_KEY;

            if (Location.LocationExists(locationKey))
            {
                returnData = Location.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Game Menu";
                returnData.DoLoadLocation = LoadGameMenu;

                Location.AddLocation(returnData);
            }

            return returnData;
        }


        #endregion

        #region Get Town Instance

        private static InitialGameMenu _InitialGameMenu;

        public static InitialGameMenu GetTownInstance()
        {
            if(_InitialGameMenu==null)
            {
                _InitialGameMenu = new InitialGameMenu();

            }

            return _InitialGameMenu;
        }

        #endregion

    }
}
