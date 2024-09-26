using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: Backend Programmers");
            foreach (var emp in LinqTasks.Task1())
                Console.WriteLine(emp);

            Console.WriteLine("\nTask 2: Frontend Programmers with Salary > 1000, Ordered by Name Desc");
            foreach (var emp in LinqTasks.Task2())
                Console.WriteLine(emp);

            Console.WriteLine("\nTask 3: Max Salary");
            Console.WriteLine(LinqTasks.Task3());

            Console.WriteLine("\nTask 4: Employees with Max Salary");
            foreach (var emp in LinqTasks.Task4())
                Console.WriteLine(emp);

            Console.WriteLine("\nTask 5: Employee Names and Jobs");
            foreach (var item in LinqTasks.Task5())
                Console.WriteLine(item);

            Console.WriteLine("\nTask 6: Employees and their Departments");
            foreach (var item in LinqTasks.Task6())
                Console.WriteLine(item);

            Console.WriteLine("\nTask 7: Job Counts");
            foreach (var item in LinqTasks.Task7())
                Console.WriteLine(item);

            Console.WriteLine("\nTask 8: Exists Backend Programmer?");
            Console.WriteLine(LinqTasks.Task8());

            Console.WriteLine("\nTask 9: Newest Frontend Programmer");
            Console.WriteLine(LinqTasks.Task9());

            Console.WriteLine("\nTask 10: Employees or Default");
            foreach (var item in LinqTasks.Task10())
                Console.WriteLine(item);

            Console.WriteLine("\nTask 11: Departments with More Than One Employee");
            foreach (var item in LinqTasks.Task11())
                Console.WriteLine(item);

            Console.WriteLine("\nTask 12: Employees with Subordinates");
            foreach (var emp in LinqTasks.Task12())
                Console.WriteLine(emp);

            Console.WriteLine("\nTask 13: Number Occurring Odd Times");
            Console.WriteLine(LinqTasks.Task13(new int[] { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1 }));

            Console.WriteLine("\nTask 14: Departments with Exactly 5 or No Employees");
            foreach (var dept in LinqTasks.Task14())
                Console.WriteLine(dept);
        }

    }
}
