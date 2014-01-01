using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Towns;

namespace The_Darkest_Hour.Locations.Actions
{
    class RumorAction : LocationAction
    {

        public string NpcName { get; set; }
        public List<Rumor> Rumors { get; set; }

        public RumorAction(string npcName, List<Rumor> rumors)
        {
            this.NpcName = npcName;
            this.Rumors = rumors;
            this.Name = String.Format("Talk with {0} to get the latest news.", npcName);
            this.Description = String.Format("Talk with {0} to get the latest news.", npcName); ;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            this.ClearScreen(false);

            if ((this.Rumors != null) && (this.Rumors.Count > 0))
            {
                int rumorIndex = GameState.NumberGenerator.Next(0, Rumors.Count);

                Console.WriteLine(String.Format("{0} says '{1}'", this.NpcName, this.Rumors[rumorIndex].DisplayText));

                if (this.Rumors[rumorIndex].OnHeardRumor != null)
                {
                    this.Rumors[rumorIndex].OnHeardRumor();
                }

                /*
                if (this.Rumors[rumorIndex].Accomplishment != null)
                {
                    // TODO: need to keep duplicate accomplishments from happening.
                    GameState.Hero.Accomplishments.Add(this.Rumors[rumorIndex].Accomplishment);
                }
                 * */

            }
            else
            {
                Console.WriteLine(String.Format("{0} has nothing to say.", this.NpcName));
            }

            this.ClearScreen();

            return returnData;
        }

    }
}
