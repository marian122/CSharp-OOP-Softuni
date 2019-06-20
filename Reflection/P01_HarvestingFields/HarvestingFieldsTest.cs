namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "HARVEST")
            {
                if (input == "private")
                {
                    var type = typeof(HarvestingFields);

                    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                    foreach (var field in privateFields.Where(s => s.IsPrivate))
                    {
                        sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");

                    }
                }

                else if (input == "protected")
                {
                    var type = typeof(HarvestingFields);

                    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                    foreach (var field in privateFields.Where(s => s.IsFamily))
                    {
                        if (field.Attributes.ToString().ToLower() == "family")
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");

                        }
                        else
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");

                        } 
                    }
                }

                else if (input == "public")
                {
                    var type = typeof(HarvestingFields);

                    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

                    foreach (var field in privateFields.Where(s => s.IsPublic))
                    {
                        sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");

                    }
                }

                else if (input == "all")
                {
                    var type = typeof(HarvestingFields);

                    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                    foreach (var field in privateFields)
                    {
                        if (field.Attributes.ToString().ToLower() == "family")
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");

                        }
                        else
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");

                        }

                    }
                }
                input = Console.ReadLine();


            }
            Console.WriteLine(sb.ToString());
        }
    }
}
