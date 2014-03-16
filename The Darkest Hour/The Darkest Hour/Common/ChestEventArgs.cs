using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Common
{
    class ChestEventArgs : EventArgs
    {
        public ChestResults ChestResults { get; set; }
    }
}
