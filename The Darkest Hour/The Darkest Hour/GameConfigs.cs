using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace The_Darkest_Hour
{
    // I like to use a separate class to get my configuration information instead
    // of just reading the app.config file directory.  This allows you to change
    // where you get your config information easily without having to modify a lot
    // of your code in the game itself.  For example, if I want to make one of the 
    // config settings a menu option in the game, all I would need to do is modify
    // this class to pull from the menu option instead and I can just leave the rest
    // of my code alone (as it pulls from this class).
    // I also like to use this class to provide hard-coded defaults just in-case somebody
    // mucks up the app.config file.
    class GameConfigs
    {

#region Game Defaults

        private const string PLAYER_GAME_FILES_LOCATION_DEFAULT = @"c:\TheDarkestHour\CharacterSavesAlpha";

#endregion

#region Private Statics

        private static string _PlayerGameFilesLocation;

#endregion

#region Public Static Properites

        public static string PlayerGameFilesLocation
        {
            get
            {
                if ( (_PlayerGameFilesLocation==null) || (_PlayerGameFilesLocation.Length==0))
                {
                    _PlayerGameFilesLocation = ConfigurationManager.AppSettings["PlayerGameFilesLocation"];
                } 

                if ((_PlayerGameFilesLocation == null) || (_PlayerGameFilesLocation.Length == 0))
                {
                    _PlayerGameFilesLocation = PLAYER_GAME_FILES_LOCATION_DEFAULT;
                }

                return _PlayerGameFilesLocation;
            }
        }

#endregion
    
    }
}
