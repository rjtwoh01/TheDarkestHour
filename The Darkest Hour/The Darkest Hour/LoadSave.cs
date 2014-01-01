﻿using System;
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
            FileInfo[] Files = d.GetFiles("*.xml");
            foreach (FileInfo file in Files)
            {
                locationAction = new LoadCharacterAction(file.Name);
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

            // Put all txt files in root directory into array.
            string[] characterFileNames = Directory.GetFiles(GameConfigs.PlayerGameFilesLocation, "*.xml");

            if((characterFileNames!=null) && (characterFileNames.Length>0))
            {
                returnData = true;
            }

            return returnData;
        }

        public static Player LoadCharacter(string fileName)
        {
            return LoadFromXmlFile(fileName);
        }

        private static Player LoadFromXmlFile(string fileName)
        {
            Player myHero;

            System.Xml.Serialization.XmlSerializer playerXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(GameObject));
            using (System.IO.StreamReader playerStreamReader = new System.IO.StreamReader(Path.Combine(GameConfigs.PlayerGameFilesLocation, fileName)))
            {
                myHero = new Player();
                myHero = (Player) playerXmlSerializer.Deserialize(playerStreamReader);

                Console.WriteLine("Game Loaded from xml file successfully\n");
            }

            return myHero;
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
            SaveToXmlFile(myHero, GetCharacterFileName(myHero));
        }

        private static void SaveToXmlFile(Player myHero, string fileName)
        {
            if (Directory.Exists(GameConfigs.PlayerGameFilesLocation) == false)
            {
                Directory.CreateDirectory(GameConfigs.PlayerGameFilesLocation);
            }

            System.Xml.Serialization.XmlSerializer playerXmlSerialization = new System.Xml.Serialization.XmlSerializer(typeof(GameObject));

            using (System.IO.StreamWriter characterStreamWriter = new System.IO.StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, fileName)))
            {
                playerXmlSerialization.Serialize(characterStreamWriter, myHero);
                characterStreamWriter.Close();

                Console.WriteLine("Game saved successfully\n");
            }

        }

        /// <summary>
        /// Returns a valid file name for a character
        /// </summary>
        /// <param name="myHero"></param>
        /// <returns></returns>
        public static string GetCharacterFileName(Player myHero)
        {
            StringBuilder returnData = new StringBuilder();

            char[] arr = myHero.Identifier.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))));

            returnData.Append(arr);
            returnData.Append(".xml");

            return returnData.ToString();
        }
    }
}
    
