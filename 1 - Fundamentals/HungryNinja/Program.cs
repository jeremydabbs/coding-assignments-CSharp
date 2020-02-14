using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
         
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Pizza", 800, false, false),
                new Food("Chicken Curry", 550, true, false),
                new Food("Pork Chop", 180, false, false),
                new Food("Gumbo", 390, true, false),
                new Food("Broccoli", 70, false, false),
                new Food("Apple", 100, false, false),
                new Food("Protein Bar", 260, false, true),
                new Food("Cherry Jello", 130, false, true),
            };
        }
         
        public Food Serve()
        {
            Random rand = new Random();
            int i = rand.Next(Menu.Count);
            Console.WriteLine(Menu[i].Name);
            return Menu[i];
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory = new List<Food>();
         
        // add a constructor
        public Ninja()
        {

        }
        // add a public "getter" property called "IsFull"
        public bool IsFull{
            get {
                if (calorieIntake >= 1200) { return true;}
                else { return false; }
            }
        }
        // build out the Eat method
        public void Eat(Food item)
        {
            if (IsFull == true){
                Console.WriteLine("The Ninja is full and can eat no more!");
            }
            if (IsFull == false){
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine(item.Name + " is spicy:" + item.IsSpicy + ", is sweet:" + item.IsSweet);
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Buffet Yum = new Buffet();
            Ninja Joe = new Ninja();
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
            Joe.Eat(Yum.Serve());
        }
    }
}
