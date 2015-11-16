using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Towns;

namespace The_Darkest_Hour
{
    /// <summary>
    /// The game's current state.
    /// </summary>
    /// <remarks>
    /// What I should do is make a single static method called
    /// Current that return an instance of GameState and make 
    /// all of the properties instance.   In it's current
    /// form this only allows one player to be active at a time.
    /// A better design (even if it's single player) is to make an 
    /// instance per player incase it's ever expanded to multiplayer.
    /// </remarks>
    class GameState
    {

        private static Town _StartingTown;
        private static Random _NumberGenerator;

        private static Dictionary<string, LocationDefinition> _GameLocations;
        private static LocationStates _GameLocationStates;
        public static Player Hero { get; set; }
        public static LocationDefinition CurrentLocation { get; set; }
        public static LocationDefinition UpcomingLocation { get; set; }

        public static Town StartingTown
        {
            get
            {
                if (_StartingTown == null)
                {
                    if (Hero.startingLocation == "Watertown")
                    {
                        _StartingTown = The_Darkest_Hour.Towns.Watertown.Watertown.GetTownInstance();
                    }
                    if (Hero.startingLocation == "Ankou")
                    {
                        _StartingTown = The_Darkest_Hour.Towns.Watertown.Ankou.GetTownInstance();
                    }
                    if (Hero.startingLocation == "Beach Tower")
                    {
                        _StartingTown = The_Darkest_Hour.Towns.Watertown.BeachTower.GetTownInstance();
                    }
                    if (Hero.startingLocation == "Banken")
                    {
                        _StartingTown = The_Darkest_Hour.Towns.Watertown.Banken.GetTownInstance();
                    }
                }

                return _StartingTown;
            }

        }

        public static LocationDefinition StartingLocation
        {
            get
            {
                return StartingTown.GetStartingLocationDefinition();
            }
        }

        /// <summary>
        /// A random number generator.  This should be used
        /// for any random numbers in the game.  If new Random
        /// is created too close to each other they will produce
        /// the same results (provided it's the same range).
        /// </summary>
        public static Random NumberGenerator
        {
            get
            {
                if (_NumberGenerator == null)
                {
                    _NumberGenerator = new Random();
                }

                return _NumberGenerator;
            }

        }

        /// <summary>
        /// Holds the game loaded game locations
        /// </summary>
        /// <remarks>
        /// This is the single source of loaded game locations.
        /// In the future, we can expand this concept to include
        /// information such as last time accessed and then implement
        /// an algorithm to periodically remove loaded locations
        /// that haven't been accessed in a while.
        /// 
        /// In addition, this currenty design will allow me to easily
        /// remove a location if it needs to be reloaded.  This is 
        /// useful in the scenarios where a Location has a hidden menu 
        /// option that is only opened after a certain event.
        /// 
        /// Finally, this design will solve the problem where the current 
        /// implementation has the issue of loading not only the current
        /// location but any adjacent locations (and then those locations
        /// would also load their adjacent locations and so and so).  Essentially
        /// all adjacent locations would be loaded.  Note, that the current
        /// design also can have an action that moves a character to another
        /// location not using the adjacent location pattern and thus those
        /// particular locations would be loaded).  
        /// 
        /// With this new design only the Name (or location key specifically)
        /// is stored for the adjacent locations.  Therefore, only the current
        /// location and previously visited locations are actually loaded 
        /// into memory.
        /// </remarks>
        public static Dictionary<string, LocationDefinition> GameLocations
        {
            get
            {
                if (_GameLocations == null)
                {
                    _GameLocations = new Dictionary<string, LocationDefinition>();
                }

                return _GameLocations;
            }

        }

        public static LocationStates GameLocationStates
        {
            get
            {
                if (_GameLocationStates == null)
                {
                    _GameLocationStates = new LocationStates();
                }

                return _GameLocationStates;
            }
        }


        /// <summary>
        /// Will reset the game to it's initial state.
        /// </summary>
        /// <remarks>Typically used when loading a new character.</remarks>
        public static void ResetGame()
        {
            _GameLocations = null;
            _GameLocationStates = null;
            _StartingTown = null;
            Hero = null;
            CurrentLocation = null;
            UpcomingLocation = null;
        }
        
        /// <summary>
        /// Will clear the game screen
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Will clear the game screen w/out user input
        /// </summary>
        public static void ClearScreen(bool clearWithoutInput)
        {
            Console.Clear();
        }
    }
}