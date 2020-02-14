using IronNinja.Interface;

namespace IronNinja.Models
{
    public class SweetTooth : Ninja
    {
        public SweetTooth(string name): base(name)
        {
        }

        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull {
            get {
                    if (calorieIntake >= 1500) { return true; }
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
                if (item.IsSweet)
                {
                    calorieIntake += 10;
                    System.Console.WriteLine($"{Name} says: Ooh, that's sweet!");
                }
                ConsumptionHistory.Add(item);
                System.Console.WriteLine(item.GetInfo());
                //System.Console.WriteLine(item.Name + " is spicy:" + item.IsSpicy + ", is sweet:" + item.IsSweet);
            }
        }
    }
}