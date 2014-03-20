using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;


namespace The_Darkest_Hour.Towns
{
    /// <summary>
    /// Hold a rumors.
    /// </summary>
    /// <remarks>TODO: Add a percentage chance of hearing a particular rumor.
    /// The percentage should be calculated based upon the value assigned to 
    /// each rumor.
    /// Should implement a Rumors collection with a GetRandomRumor function.
    /// This would then calculate the percentage of each rumor using
    /// (Value1) / (Value1 + Value2 + ... + ValueN) 
    /// </remarks>
    public class Rumor : GameObject
    {
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public delegate void RumorCallback();

        public RumorCallback OnHeardRumor;

        /// <summary>
        /// A function to be called after the rumor has been heard.
        /// </summary>
        /// <remarks>
        /// Only rumors that want to do a particular action after a 
        /// rumor has been heard.
        /// </remarks>
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
