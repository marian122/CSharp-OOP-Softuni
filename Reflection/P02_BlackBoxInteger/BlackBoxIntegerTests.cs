namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split('_');
            var classType = typeof(BlackBoxInteger);

            var instance = Activator.CreateInstance(classType, true);
            var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            while (input[0] != "END")
            {
                var methodName = input[0];
                var value = int.Parse(input[1]);

                var method = methods.FirstOrDefault(x => x.Name == methodName);

                method.Invoke(instance, new object[] { value });

                var field = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);


                Console.WriteLine(field.GetValue(instance));

                input = Console.ReadLine().Split('_');
            }

            

            
        }
    }
}
