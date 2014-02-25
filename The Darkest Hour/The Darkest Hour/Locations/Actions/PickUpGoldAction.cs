using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Locations.Actions
{
    class PickUpGoldAction : LocationAction
    {
        public delegate void PostItemHandler(object sender, PickUpGoldEventArgs e);

        private PickUpGoldResults _GoldResults = PickUpGoldResults.NotTook;

        public event PostItemHandler PostItem;

        private int _gold;
        public PickUpGoldResults ItemResults { get { return _GoldResults; } }

        public virtual void OnPostTake(PickUpGoldEventArgs goldEvenArgs)
        {
            if (PostItem != null)
            {
                PostItem(this, goldEvenArgs);
            }
        }

        public PickUpGoldAction(int gold)
        {
            this._gold = gold;
            this.Name = "Take bag of " + gold + " gold";
            this.Description = "Take " + gold + " gold";
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            if (GameState.Hero.gold < GameState.Hero.maxGold)
            {
                GameState.Hero.gold += this._gold;
                if (GameState.Hero.gold > GameState.Hero.maxGold)
                    GameState.Hero.gold = GameState.Hero.maxGold;
            }

            Console.WriteLine("You take {0} gold and now have {1} gold.", this._gold, GameState.Hero.gold);

            _GoldResults = PickUpGoldResults.Taken;

            PickUpGoldEventArgs goldEventArgs = new PickUpGoldEventArgs();
            goldEventArgs.GoldResults = _GoldResults;

            OnPostTake(goldEventArgs);

            this.ClearScreen();

            return returnData;
        }
    }
}
