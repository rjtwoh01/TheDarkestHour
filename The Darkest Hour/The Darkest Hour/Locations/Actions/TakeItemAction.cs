using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Common;


namespace The_Darkest_Hour.Locations.Actions
{
    class TakeItemAction : LocationAction
    {
        public delegate void PostItemHandler(object sender, TakeItemEventArgs e);

        private TakeItemResults _ItemResults = TakeItemResults.NotTook;

        public event PostItemHandler PostItem;

        private string _text;
        public TakeItemResults ItemResults { get { return _ItemResults; } }

        public virtual void OnPostTake(TakeItemEventArgs itemEventArgs)
        {
            if (PostItem != null)
            {
                PostItem(this, itemEventArgs);
            }
        }

        public TakeItemAction(string text)
        {
            this._text = text;
            this.Name = "Take " + this._text;
            this.Description = "Take " + this._text;
        }

        public TakeItemAction(string action, string item, string text)
        {
            this._text = text;
            this.Name = action + " " + item;
            this.Description = this._text;
        }

        public TakeItemAction(string action, string item)
        {
            this.Name = action + " " + item;
            this.Description = action + " " + item;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            Console.WriteLine(_text);

            _ItemResults = TakeItemResults.Taken;

            TakeItemEventArgs itemEventArgs = new TakeItemEventArgs();
            itemEventArgs.ItemResults = _ItemResults;

            OnPostTake(itemEventArgs);

            this.ClearScreen();

            return returnData;
        }
    }
}
