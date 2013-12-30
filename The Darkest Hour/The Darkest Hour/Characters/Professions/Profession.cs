using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Darkest_Hour.Characters.Professions
{
    public abstract class Profession : GameObject
    {
        public abstract string GetAttack(Player myHero);
        public abstract int CalculateDamage(Player myHero, string attack);

        public void ClearScreen()
        {
            Console.WriteLine("\n\nPress enter to continue on...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
