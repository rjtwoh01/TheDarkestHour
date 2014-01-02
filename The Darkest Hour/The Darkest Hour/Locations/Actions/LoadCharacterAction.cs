using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class LoadCharacterAction : LocationAction
    {

        public string CharacterDirectoryName { get; set; }

        public LoadCharacterAction(string directoryName)
        {
            //string displayName = String.Format("{0}", fileName.Replace(".xml",""));
            string displayName = directoryName.Substring(10);
            this.CharacterDirectoryName = directoryName;
            this.Name = displayName;
            this.Description = displayName;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            GameState.ResetGame();
            GameState.Hero = LoadSave.LoadCharacter(this.CharacterDirectoryName);

            if (GameState.Hero!=null)
            {
                returnData = GameState.StartingLocation;
            }

            this.ClearScreen();

            return returnData;
        }

    }
}