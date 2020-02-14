using System;
using System.Collections.Generic;
using IronNinja.Models;
using IronNinja.Interface;

namespace HungryNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
         
        //constructor
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Pizza", 800, false, false),
                new Food("Chicken Curry", 550, true, false),
                new Food("Pork Chop", 180, false, false),
                new Food("Gumbo", 390, true, false),
                new Food("Broccoli", 70, false, false),
                new Food("Apple", 100, false, false),
                new Food("Protein Bar", 260, false, true),
                new Food("Cherry Jello", 130, false, true),
                new Drink("Chocolate Shake", 680, false),
                new Drink("Crystal Pepsi", 220, false),
                new Drink("Red Gatorade", 160, false),
                new Drink("Diet 7-Up", 0, false)
            };
        }
         
        public IConsumable Serve()
        {
            Random rand = new Random();
            // int i = rand.Next(Menu.Count);
            // Console.WriteLine(Menu[i].Name);
            // return Menu[i];
            IConsumable item = Menu[rand.Next(Menu.Count)];
            return item;
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Ninja Buffet!");
            Buffet Yum = new Buffet();
            Ninja Joe = new SpiceHound("Joe");
            Ninja Moe = new SweetTooth("Moe");
            while(!Joe.IsFull || !Moe.IsFull)
            {
                Joe.Consume(Yum.Serve());
                Moe.Consume(Yum.Serve());
            }
            Console.WriteLine($"Joe ate {Joe.ConsumptionHistory.Count} items.\nMoe ate {Moe.ConsumptionHistory.Count} items.");
            if(Joe.ConsumptionHistory.Count > Moe.ConsumptionHistory.Count)
            {Console.WriteLine("Joe wins!");}
            else if(Moe.ConsumptionHistory.Count > Joe.ConsumptionHistory.Count)
            {Console.WriteLine("Moe wins!");}
            else {Console.WriteLine("It's a tie!");}

        }
    }
}
