using System;

namespace Wizard.Models
{
    public class Wiz : Human
    {
        public Wiz(string name) : base(name)
        {
            Intelligence = 25;
            health = 50;
        }
        public override int Attack(Human target)
        {
            int dmg = 5 * Intelligence;
            health += dmg;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} has struck down {target.Name} with magic and mystery!!!");
            Console.ResetColor();
            return target.Damage(dmg);
        }
        public int Heal(Human target)
        {
            int heal = 10 * Intelligence;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} has healed {target.Name} and restored them to enlightenment.");
            Console.ResetColor();
            if(target.Health < 0)
            {
                target.Damage(target.Health + -heal);
                return target.Health;
            }
            return target.Damage(-heal);
        }
    }
}