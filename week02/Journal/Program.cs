// CREATIVITY: Added a 'Mood' field to each entry and updated the save/load/display logic to include how the user felt during that specific journal entry.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                Console.Write("¿Cómo te sientes hoy? (Mood) ");
                string mood = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}