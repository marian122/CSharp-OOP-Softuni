using System;

namespace Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                var studentInput = Console.ReadLine().Split();
                var firstName = studentInput[0];
                var lastName = studentInput[1];
                var facultyNumber = studentInput[2];

                Student student = new Student(firstName, lastName, facultyNumber);

                var workerInput = Console.ReadLine().Split();
                firstName = workerInput[0];
                lastName = workerInput[1];
                decimal weekSalary = decimal.Parse(workerInput[2]);
                decimal workHoursInDay = decimal.Parse(workerInput[3]);

                Worker worker = new Worker(firstName, lastName, weekSalary, workHoursInDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

    }
}
