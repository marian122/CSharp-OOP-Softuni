using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttribute<AuthorAttribute>();

                if (attributes != null)
                {
                    Console.WriteLine($"{method.Name} is written by {attributes.Name}");
                }
            }   
        }
    }
}
