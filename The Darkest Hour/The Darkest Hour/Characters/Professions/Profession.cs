using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Characters.Professions
{
    public abstract class Profession : GameObject
    {

        public abstract string Name { get; }
        public abstract string GetAttack(Player myHero);
        public abstract int CalculateDamage(Player myHero, string attack);
        public abstract void CreateInitialHero(Player myHero);
        public abstract int GetDamageMultipler(Player myHero);

        public void ClearScreen()
        {
            DarkestHourWindow.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            DarkestHourWindow.Clear();
        }

    }
}
