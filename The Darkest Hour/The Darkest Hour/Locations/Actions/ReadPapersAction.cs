using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Common;
using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Locations.Actions
{
    class ReadPapersAction : LocationAction
    {
        public delegate void PostPaperReadHandler(object sender, PaperReadEventArgs e);

        private PaperReadResults _PaperResults = PaperReadResults.NotRead;

        public event PostPaperReadHandler PostPaper;

        private string _text;
        public PaperReadResults PaperResults { get { return _PaperResults; } }

        public virtual void OnPostRead(PaperReadEventArgs paperEventArgs)
        {
            if (PostPaper != null)
            {
                PostPaper(this, paperEventArgs);
            }
        } 

        public ReadPapersAction(string text)
        {
            this.Name = "Read Papers";
            this.Description = "Read Papers";

            this._text = text;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            DarkestHourWindow.WriteLine(_text);

            _PaperResults = PaperReadResults.Read;

            PaperReadEventArgs paperEventArgs = new PaperReadEventArgs();
            paperEventArgs.PaperResults = _PaperResults;

            OnPostRead(paperEventArgs);

            this.ClearScreen();

            return returnData;
        }
    }
}
