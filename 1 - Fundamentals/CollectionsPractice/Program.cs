using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Arrays
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] booleanArray = {true, false, true, false, true, false, true, false, true, false};

            //Lists
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Butter Pecan");
            flavors.Add("Rocky Road");
            flavors.Add("Mint Chocolate Chip");
            Console.WriteLine(flavors.Count);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            //Dictionary
            // Dictionary<string,string> eaters = new Dictionary<string,string>();
            // eaters.Add("Tim", "Vanilla");
            // eaters.Add("Martin", "Chocolate");
            // eaters.Add("Nikki", "Rocky Road");
            // eaters.Add("Sara", "Mint Chocolate Chip");
            // foreach (KeyValuePair<string,string> entry in eaters) {
            //     Console.WriteLine(entry.Key + " likes " + entry.Value);
            // }
            string[] names = new string[]{"Tim","Martin","Nikki","Sara"};
            Random rand = new Random();
            Dictionary<string,string> eaters = new Dictionary<string,string>();
            foreach (var nn in names) {
                eaters.Add(nn, flavors[rand.Next(flavors.Count)]);
            }
            foreach (KeyValuePair<string,string> entry in eaters) {
                Console.WriteLine(entry.Key + " likes " + entry.Value);
            }

            //Boxing/Unboxing
            List<object> variety = new List<object>();
            variety.Add(7);
            variety.Add(28);
            variety.Add(-1);
            variety.Add(true);
            variety.Add("chair");
            int sum = 0;
            for (int i=0; i<variety.Count; i++){
                Console.WriteLine(variety[i]);
                if (variety[i] is int){
                    sum = sum + (int)variety[i];
                }
            }
            Console.WriteLine(sum);

        }
    }
}
