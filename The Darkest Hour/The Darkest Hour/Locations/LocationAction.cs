using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Locations
{
    public delegate void PreActionHandler(object sender, EventArgs e);
    public delegate void PostActionHandler(object sender, EventArgs e);

    abstract class LocationAction
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract LocationDefinition DoAction();

        public event PreActionHandler PreAction;
        public event PostActionHandler PostAction ;

        public virtual void OnPreAction(EventArgs e)
        {
            if (PreAction != null)
            {
                PreAction(this, e);
            }
        }

        public virtual void OnPostAction(EventArgs e)
        {
            if (PostAction != null)
            {
                PostAction(this, e);
            }
        }

        public virtual void DoPreAction()
        {
            OnPreAction(EventArgs.Empty);
        }

        public virtual void DoPostAction()
        {
            OnPostAction(EventArgs.Empty);
        }


        public void ClearScreen()
        {
            ClearScreen(true);
        }

        public void ClearScreen(bool promptToMoveOn)
        {
            if (promptToMoveOn)
            {
                Console.WriteLine("\n\nPress enter to continue on...");
                Console.ReadLine();
            }
            Console.Clear();
        }


    }
}
