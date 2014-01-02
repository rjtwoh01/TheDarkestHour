using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Combat
{
    public class CombatEventArgs : EventArgs
    {
        public CombatResult CombatResults { get; set; }
    }
}
