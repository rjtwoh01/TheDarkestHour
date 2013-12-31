using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters
{
    public class Accomplishment : GameObject, IEquatable<Accomplishment>, IComparable<Accomplishment>
    {
        /// <summary>
        /// Uniquely identifies the area of the accomplishment
        /// </summary>
        /// <remarks>
        /// The namespace concept is used to keep accomplishments
        /// from clashing with other accomplishments in the game.
        /// This will allow new areas (or expansions) to add their accomplishments
        /// with simple names without worrying about conflicting with another
        /// area's accomplishments.   As long as each area has a uniquie
        /// namespace then it's accomplishments will be different from other area's 
        /// accomplishments.
        /// </remarks>
        public string NameSpace { get; set; }

        /// <summary>
        /// The name of the accomplishment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The detail description of the accomplishment
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Use to compare if an Accomplishment is the same
        /// as another Accomplishment
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <remarks>This allows for custom List of Accomplishment to use the Contains method</remarks>
        public bool Equals(Accomplishment other)
        {
            bool returnData = false;

            if (other.NameSpace.Equals(this.NameSpace))
            {
                if (other.Name.Equals(this.Name))
                {
                    returnData = true;
                }

            }

            return returnData;
        }

        /// <summary>
        /// Compares to another Accomplishment
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <remarks>If Accomplishment is used in an ordered list, this allows the list to be sorted</remarks>
        public int CompareTo(Accomplishment other)
        {
            int returnData;
            // If other is not a valid object reference, this instance is greater. 
            if (other == null) return 1;

            returnData = this.NameSpace.CompareTo(other.NameSpace);
            if(returnData == 0)
            {
                // It's the same namespace.  So now, just use the 
                // name to sort witin the same namespace
                returnData = this.Name.CompareTo(other.Name);
            }

            return returnData;
        }

        public int CompareTo(string nameSpace, string name)
        {
            int returnData;
            // If other is not a valid object reference, this instance is greater. 
            if (nameSpace == null) return 1;

            returnData = this.NameSpace.CompareTo(nameSpace);
            if (returnData == 0)
            {
                // It's the same namespace.  So now, just use the 
                // name to sort witin the same namespace
                returnData = this.Name.CompareTo(name);
            }

            return returnData;     
        }
    }
}
