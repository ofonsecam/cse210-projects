using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectionActivity()
            : base(
                "Reflection Activity",
                "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult, but did it anyway.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get the strength to do what you did?",
                "What could this say about your character and values?",
                "How can you apply this experience in the future?"
            };
        }

        public void Run()
        {
            DisplayStartingMessage();

            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            List<string> remainingQuestions = new List<string>(_questions);
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < endTime && remainingQuestions.Count > 0)
            {
                int index = random.Next(remainingQuestions.Count);
                string question = remainingQuestions[index];
                remainingQuestions.RemoveAt(index);

                Console.WriteLine();
                Console.WriteLine($"> {question}");
                Console.WriteLine();
                ShowSpinner(5);
            }

            DisplayEndingMessage();
        }
    }
}
