using System;

namespace Problem4.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var phoneNumbers = Console.ReadLine().Split();
                ICaller calling = new SmartPhone();

                var websites = Console.ReadLine().Split();
                IBrowser browsing = new SmartPhone();

                foreach (var number in phoneNumbers)
                {
                    Console.WriteLine(calling.Call(number));
                }

                foreach (var website in websites)
                {
                    Console.WriteLine(browsing.Browse(website));
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            
        }
    }
}
