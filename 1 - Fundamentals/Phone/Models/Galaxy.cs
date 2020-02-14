using System;
using Phone.Interface;

namespace Phone.Models
{
    public class Galaxy : Phone, IRingable 
    {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
            : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring() 
        {
            // your code here
            return RingTone;
        }
                    
        public string Unlock() 
        {
            // your code here
            return "Unlocked";
        }
        public override void DisplayInfo() 
        {
            // your code here
            Console.WriteLine("############");
            Console.WriteLine($"Galaxy {VersionNumber}");
            Console.WriteLine($"Battery Percentage: {BatteryPercentage}");
            Console.WriteLine($"Carrier: {Carrier}");
            Console.WriteLine($"Ring Tone: {RingTone}");
            Console.WriteLine("############");
        }

    }
    
}