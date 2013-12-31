using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Towns
{
    // TODO: Add a percentage chance of hearing a particular rumor;
    public class Rumor : GameObject
    {
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public Accomplishment Accomplishment { get; set; }
        //public Action<string> PostRumorAction { get; set; }
        public delegate void RumorCallback();

        public RumorCallback OnHeardRumor;

        public void PostRumor()
        {
            OnHeardRumor();
        }

        public Rumor()
        {
        }

        public Rumor(string name)
        {
            this.Name = name;
        }

        public Rumor(string name, string displayText)
        {
            this.Name = name;
            this.DisplayText = displayText;
        }
    }
}
