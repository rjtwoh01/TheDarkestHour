using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Common
{
    class PickUpGoldEventArgs : EventArgs
    {
        public PickUpGoldResults GoldResults { get; set; }
    }
}
