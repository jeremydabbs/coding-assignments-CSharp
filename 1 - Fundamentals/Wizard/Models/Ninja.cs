using System;

namespace Wizard.Models
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {
            int dmg = 5 * Dexterity;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} has struck down {target.Name} with might and strength!!!");
            Console.ResetColor();
            Random rand = new Random();
            if(rand.Next(1,100) <= 20)
            {
                Console.WriteLine($"{Name} has kicked {target.Name} when they were down!!!");
                dmg += 10;
            }
            return target.Damage(dmg);
        }
        public int Steal(Human target)
        {
            target.Damage(5);
            health += 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} has taken 5 health from {target.Name}.");
            Console.ResetColor();
            return target.Health;
        }
    }
}