using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using System.Data.OleDb;
using System.Data;
using System.IO;
using The_Darkest_Hour.Items;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour
{
    class LoadSave
    {
        /// <summary>
        /// Gets the list of saved characters
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Eventually if would be nice to 
        /// (1) Check for only valid game files
        /// (2) Get the name of the character too (maybe level as well)
        /// </remarks>
        public static List<LocationAction> GetSavedCharacters()
        {
            List<LocationAction> returnData = new List<LocationAction>();
            LocationAction locationAction;

            DirectoryInfo d = new DirectoryInfo(GameConfigs.PlayerGameFilesLocation);
            DirectoryInfo[] characterDirectories = d.GetDirectories("Character *");

            foreach (DirectoryInfo characterDirectory in characterDirectories)
            {
                locationAction = new LoadCharacterAction(characterDirectory.Name);
                returnData.Add(locationAction);
            }

            return returnData;
        }

        /// <summary>
        /// Checks if any saved game files exists.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Does not validate if they are valid game files.  Only checks if they are xml files.</remarks>
        public static bool SavedGameExists()
        {
            bool returnData=false;

            string[] characterDirectories = Directory.GetDirectories(GameConfigs.PlayerGameFilesLocation, "Character *");

            if ((characterDirectories != null) && (characterDirectories.Length > 0))
            {
                returnData = true;
            }

            return returnData;
        }

        public static bool SavedLocationStateExists(string locationStateKey)
        {
            bool returnData = false;
            string fileName = GetLocationStateFileName(locationStateKey);
            string characterDirectory = GetCharacterDirectoryName(GameState.Hero);

            returnData = File.Exists(Path.Combine(GameConfigs.PlayerGameFilesLocation,characterDirectory,fileName));

            return returnData;
        }


        public static Player LoadCharacter(string directoryName)
        {
            return LoadFromXmlFile(directoryName);
        }

        private static Player LoadFromXmlFile(string directoryName)
        {
            Player myHero;
            string fileName = GetCharacterFileName();

            System.Xml.Serialization.XmlSerializer playerXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(GameObject));
            using (System.IO.StreamReader playerStreamReader = new System.IO.StreamReader(Path.Combine(GameConfigs.PlayerGameFilesLocation, directoryName, fileName)))
            {
                myHero = new Player();
                myHero = (Player) playerXmlSerializer.Deserialize(playerStreamReader);

                Console.WriteLine("Game Loaded from xml file successfully\n");
            }

            return myHero;
        }

        public static LocationState LoadLocationState(string locationStateKey)
        {
            return LoadLocationStateFromXmlFile(locationStateKey);
        }


        private static LocationState LoadLocationStateFromXmlFile(string locationStateKey)
        {
            LocationState returnData;
            string fileName = GetLocationStateFileName(locationStateKey);
            string characterDirectory = GetCharacterDirectoryName(GameState.Hero);


            System.Xml.Serialization.XmlSerializer locationStateXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(LocationState));
            using (System.IO.StreamReader locationStateStreamReader = new System.IO.StreamReader(Path.Combine(GameConfigs.PlayerGameFilesLocation, characterDirectory, fileName)))
            {
                returnData = new LocationState();
                returnData = (LocationState)locationStateXmlSerializer.Deserialize(locationStateStreamReader);
            }

            return returnData;
        }


        public static void SaveCharacter(Player myHero)
        {
            SaveToXmlFile(myHero);
        }

        /// <summary>
        /// Saves character to an xml file
        /// </summary>
        /// <param name="myHero"></param>
        /// <notes>
        /// I would go with this version:
        /// 1) Don't need a special program to edit the game file (i.e. access or another database will need that installed)
        /// 2) Easily portable
        /// 3) Easily readable by a human
        /// 4) You don't need to write a special function or a line of code for each property.  As you expand the player class
        /// this function just keeps working.  you can read up on override the serializes capabilities if you want to do anything
        /// custom/unique.  But it's a the best/property design in this scenario.  The framework supports it out of the box.
        /// </notes>
        private static void SaveToXmlFile(Player myHero)
        {
            SaveToXmlFile(myHero, GetCharacterDirectoryName(myHero));
        }

        private static void SaveToXmlFile(Player myHero, string directoryName)
        {
            SaveToXmlFile(myHero, directoryName, GetCharacterFileName());

            foreach (string locationStateKey in GameState.GameLocationStates.Keys)
            {
                LocationState locationState = GameState.GameLocationStates[locationStateKey];
                string fileName = GetLocationStateFileName(locationStateKey);
                SaveToXmlFile(locationState, directoryName, fileName);

            }
        }

        private static void SaveToXmlFile(GameObject gameObject, string directoryName, string fileName)
        {
            if (Directory.Exists(Path.Combine(GameConfigs.PlayerGameFilesLocation,directoryName)) == false)
            {
                Directory.CreateDirectory(Path.Combine(GameConfigs.PlayerGameFilesLocation,directoryName));
            }

            System.Xml.Serialization.XmlSerializer playerXmlSerialization = new System.Xml.Serialization.XmlSerializer(typeof(GameObject));

            using (System.IO.StreamWriter characterStreamWriter = new System.IO.StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, directoryName, fileName)))
            {
                playerXmlSerialization.Serialize(characterStreamWriter, gameObject);
                characterStreamWriter.Close();

                Console.WriteLine(String.Format("{0} saved successfully",fileName));
            }
        }

        private static void SaveToXmlFile(LocationState gameObject, string directoryName, string fileName)
        {
            if (Directory.Exists(Path.Combine(GameConfigs.PlayerGameFilesLocation, directoryName)) == false)
            {
                Directory.CreateDirectory(Path.Combine(GameConfigs.PlayerGameFilesLocation, directoryName));
            }

            System.Xml.Serialization.XmlSerializer playerXmlSerialization = new System.Xml.Serialization.XmlSerializer(typeof(LocationState));

            using (System.IO.StreamWriter characterStreamWriter = new System.IO.StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, directoryName, fileName)))
            {
                playerXmlSerialization.Serialize(characterStreamWriter, gameObject);
                characterStreamWriter.Close();

                Console.WriteLine(String.Format("{0} saved successfully", fileName));
            }

        }



        /// <summary>
        /// Returns a valid file name for a character
        /// </summary>
        /// <param name="myHero"></param>
        /// <returns></returns>
        public static string GetCharacterDirectoryName(Player myHero)
        {
            StringBuilder returnData = new StringBuilder();

            char[] arr = myHero.Identifier.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))));

            returnData.Append("Character ");
            returnData.Append(arr);

            return returnData.ToString();
        }

        public static string GetCharacterFileName()
        {
            return "Character.xml";
        }

        public static string GetLocationStateFileName(string locationStateKey)
        {
            return String.Format("{0}.xml", locationStateKey);
        }
    }
}
    
