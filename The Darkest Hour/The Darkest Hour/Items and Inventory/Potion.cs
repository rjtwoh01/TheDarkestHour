using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Items_and_Inventory
{
    class Potion : Item
    {
        public Potion()
        {
        }

        public Potion(string name, int healthHeal, int energyHeal, int requiredLevel, string type, int worth)
        {
            this.itemArchType = "Potion";
            this.name = name;
            this.energyHeal = energyHeal;
            this.healthHeal = healthHeal;
            this.requiredLevel = requiredLevel;
            this.isPotion = true;
            this.itemType = type;
            this.worth = worth;
        }

        public override string ToString()
        {
            var sw = new System.IO.StringWriter();
            sw.WriteLine("Item Name - \"{0}\"", name);
            sw.WriteLine("Item Type - \"{0}\"", itemType);
            if (energyHeal != 0) { sw.WriteLine("Energy Added - {0}", energyHeal); }
            if (healthHeal != 0) { sw.WriteLine("Health Added - {0}", healthHeal); }
            sw.WriteLine("Required Level: {0} ", requiredLevel);
            sw.WriteLine("Worth: {0} gold", worth);
            if (isEquipped) { sw.WriteLine("Equipped"); }
            return sw.ToString();
        }
    }
}
