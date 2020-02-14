using System;
using Wizard.Models;

namespace Wizard
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wizard Ninja Samurai");
            Console.WriteLine();

            Ninja nibbles = new Ninja("Mr. Nibbles");
            Ninja benny = new Ninja("Benny Bob");
            nibbles.Attack(benny);
            benny.ShowStats();
            Wiz anne = new Wiz("Anne");
            anne.Heal(benny);
            benny.ShowStats();
            Samurai adrien = new Samurai("Adrien");
            while(nibbles.Health > 0)
            {
                anne.Attack(nibbles);
                adrien.Attack(nibbles);
                benny.Attack(nibbles);
            }
            nibbles.ShowStats();
        }
    }
}
