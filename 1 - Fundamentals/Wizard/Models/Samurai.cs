using System;

namespace Wizard.Models
{
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if(target.Health < 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} has decimated {target.Name} into oblivion!!!");
                Console.ResetColor();
                return target.Damage(target.Health);
            }
            return target.Health;
        }
        public int Meditate()
        {
            health = 200;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} has found healing from within.");
            Console.ResetColor();
            return Health;
        }
    }
}