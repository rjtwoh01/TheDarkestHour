using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Common;
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Locations.Actions
{
    class TreasureChestAction : LocationAction
    {
        public delegate void PostItemHandler(object sender, ChestEventArgs e);

        private ChestResults _ChestResults = ChestResults.NotTaken;

        public event PostItemHandler PostItem;

        private int numOfItems;
        public ChestResults ChestResults { get { return _ChestResults; } }

        public virtual void OnPostTake(ChestEventArgs chestEventArgs)
        {
            if (PostItem != null)
            {
                PostItem(this, chestEventArgs);
            }
        }

        public TreasureChestAction(int numOfItems)
        {
            this.numOfItems = numOfItems;
            this.Name = "Treasure Chest";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);
            Loot chestLoot = new Loot();

            for (int i = 0; i < numOfItems; i++)
            {
                chestLoot.SelectLoot();
            }

            _ChestResults = ChestResults.Taken;

            ChestEventArgs chestEventArgs = new ChestEventArgs();
            chestEventArgs.ChestResults = _ChestResults;

            OnPostTake(chestEventArgs);

            this.ClearScreen();

            return returnData;
        }
    }
}
