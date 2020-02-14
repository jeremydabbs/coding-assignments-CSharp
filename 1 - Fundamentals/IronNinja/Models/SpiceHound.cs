using IronNinja.Interface;

namespace IronNinja.Models
{
    public class SpiceHound : Ninja
    {
        public SpiceHound(string name): base(name)
        {
        }
        // provide override for IsFull (Full at 1200 Calories)
        public override bool IsFull {
            get {
                    if (calorieIntake >= 1200) { return true; }
                    else { return false; }
                }
            }
        public override void Consume(IConsumable item)
        {
            // provide override for Consume
            if (IsFull){
                System.Console.WriteLine($"{Name} is full and can eat no more!");
            }
            if (!IsFull){
                calorieIntake += item.Calories;
                if (item.IsSpicy)
                {
                    calorieIntake -= 5;
                    System.Console.WriteLine($"{Name} says: Wow, my tongue is on fire!");
                }
                ConsumptionHistory.Add(item);
                System.Console.WriteLine(item.GetInfo());
                //System.Console.WriteLine(item.Name + " is spicy:" + item.IsSpicy + ", is sweet:" + item.IsSweet);
            }
        }
    }
}