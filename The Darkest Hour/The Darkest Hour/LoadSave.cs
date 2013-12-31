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

namespace The_Darkest_Hour
{
    class LoadSave
    {

        public static bool CheckForLoadSavedGame()
        {
            bool returnData = false;

            if (LoadSave.SavedGameExists())
            {
                // TODO: Later, save characters to individual files
                // and present a list of characters to load and pick from those.
                Console.WriteLine("Do you want to load a previously saved character?");
                Console.WriteLine("(Y)es \n(N)o\n");
                string loadAnswer = Console.ReadLine();
                // Pretty much any answer that begins with Y will be accepted as yes.
                // everything else is treated as a No.
                // This design allows for mistakes but in this case it's no big deal if you load
                // from a saved file.
                // In other situations you may want to be more strigent to checking 100% accuracy of the input.
                if ((loadAnswer != null) && (loadAnswer.Length > 0))
                {
                    if (loadAnswer.ToUpper()[0] == 'Y')
                    {
                        GameState.Hero = LoadSave.LoadCharacter();
                        returnData = true;
                    }
                }
            }

            return returnData;
        }

        public static List<LocationAction> GetSavedCharacters()
        {
            List<LocationAction> returnData = new List<LocationAction>();
            LocationAction locationAction;

            DirectoryInfo d = new DirectoryInfo(GameConfigs.PlayerGameFilesLocation);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.xml"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                locationAction = new LoadCharacterAction(file.Name);
                returnData.Add(locationAction);
            }

            /*
            // Put all txt files in root directory into array.
            string[] characterFileNames = Directory.GetFiles(GameConfigs.PlayerGameFilesLocation, "*.xml");

            foreach (string fileName in characterFileNames)
            {
                
                locationAction = new LoadCharacterAction(fileName);
                returnData.Add(locationAction);
            }
             * */

            return returnData;
        }

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
            // Could later check for valid saved game files
            //return System.IO.File.Exists(Path.Combine(GameConfigs.PlayerGameFilesLocation, "FirstCharacter.xml"));        
        }

        public static Player LoadCharacter()
        {
            return LoadFromXmlFile();
        }

        public static Player LoadCharacter(string fileName)
        {
            return LoadFromXmlFile(fileName);
        }

        private static Player LoadFromXmlFile()
        {
            return LoadFromXmlFile("FirstCharacter.xml");
        }

        private static Player LoadFromXmlFile(string fileName)
        {
            Player myHero;

            //var knownTypes = new Type[] { typeof(Character), typeof(Player), typeof(Item), typeof(Weapon), typeof(Armor), typeof(Potion), typeof(Helmet), typeof(Amulet) };
            //System.Xml.Serialization.XmlSerializer playerXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Player), knownTypes);
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
            SaveToXmlFile(myHero, "FirstCharacter.xml");
            SaveToXmlFile(myHero, GetCharacterFileName(myHero));
        }

        private static void SaveToXmlFile(Player myHero, string fileName)
        {
            if (Directory.Exists(GameConfigs.PlayerGameFilesLocation) == false)
            {
                Directory.CreateDirectory(GameConfigs.PlayerGameFilesLocation);
            }

            //var knownTypes = new Type[] { typeof(Character), typeof(Player), typeof(Item), typeof(Weapon), typeof(Armor), typeof(Potion), typeof(Helmet), typeof(Amulet) };

            //System.Xml.Serialization.XmlSerializer playerXmlSerialization = new System.Xml.Serialization.XmlSerializer(typeof(Player), knownTypes);
            System.Xml.Serialization.XmlSerializer playerXmlSerialization = new System.Xml.Serialization.XmlSerializer(typeof(GameObject));

            using (System.IO.StreamWriter characterStreamWriter = new System.IO.StreamWriter(Path.Combine(GameConfigs.PlayerGameFilesLocation, fileName)))
            {
                playerXmlSerialization.Serialize(characterStreamWriter, myHero);
                characterStreamWriter.Close();

                Console.WriteLine("Game saved to xml file successfully\n");
            }

        }

        public static string GetCharacterFileName(Player myHero)
        {
            StringBuilder returnData = new StringBuilder();

            char[] arr = myHero.Identifier.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));

            returnData.Append(arr);
            returnData.Append(".xml");

            return returnData.ToString();
        }
    }
}
    
