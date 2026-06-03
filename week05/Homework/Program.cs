using System;
namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment baseAssignment = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(baseAssignment.GetSummary());
            Console.WriteLine(); // Espacio en consola

            MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "3-10, 20-21");
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());
            Console.WriteLine();

            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }
}