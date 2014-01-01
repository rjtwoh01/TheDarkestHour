using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations.Actions
{
    class LoadCharacterAction : LocationAction
    {

        public string CharacterFileName { get; set; }

        public LoadCharacterAction(string fileName)
        {
            string displayName = String.Format("{0}", fileName.Replace(".xml",""));
            this.CharacterFileName = fileName;
            this.Name = displayName;
            this.Description = displayName;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            GameState.ResetGame();
            GameState.Hero = LoadSave.LoadCharacter(this.CharacterFileName);

            if (GameState.Hero!=null)
            {
                returnData = GameState.StartingLocation;
            }

            this.ClearScreen();

            return returnData;
        }

    }
}