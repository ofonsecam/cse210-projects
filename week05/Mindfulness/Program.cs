// Showing Creativity and Exceeding Requirements:
//
// 1. ReflectionActivity — Control de preguntas no repetidas:
//    Se mantiene una copia de la lista de preguntas (remainingQuestions). Cada vez que se
//    muestra una pregunta, se elimina de esa lista. Así, en la misma sesión no se repite
//    ninguna pregunta hasta haber mostrado las cinco. Si queda tiempo y ya se usaron todas,
//    la actividad termina sin volver a preguntar.
//
// 2. Registro de uso por actividad (log de sesión):
//    Las variables estáticas _breathingCount, _reflectionCount y _listingCount registran
//    cuántas veces se ejecutó cada actividad en la sesión actual. El menú muestra ese
//    resumen para que el usuario vea su historial antes de elegir otra opción.

using System;

namespace Mindfulness
{
    class Program
    {
        static int _breathingCount = 0;
        static int _reflectionCount = 0;
        static int _listingCount = 0;

        static void Main(string[] args)
        {
            string choice = "0";

            while (choice != "4")
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.WriteLine();
                Console.WriteLine($"Session log — Breathing: {_breathingCount} | Reflection: {_reflectionCount} | Listing: {_listingCount}");
                Console.WriteLine();
                Console.Write("Enter a choice from the menu: ");
                choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    _breathingCount++;
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    _reflectionCount++;
                }
                else if (choice == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    _listingCount++;
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                }
            }
        }
    }
}
