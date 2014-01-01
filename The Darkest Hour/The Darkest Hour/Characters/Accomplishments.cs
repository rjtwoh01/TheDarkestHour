using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters
{
    public class Accomplishments : List<Accomplishment>
    {

        public new void Add(Accomplishment accomplishment)
        {
            if (this.Contains(accomplishment)==false)
            {
                base.Add(accomplishment);
            }
        }
 
    }
}
