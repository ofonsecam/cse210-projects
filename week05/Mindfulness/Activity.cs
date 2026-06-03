using System;
using System.Threading;

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long would you like for your session to be in seconds? ");
            string input = Console.ReadLine();
            _duration = int.Parse(input);
            Console.WriteLine();
            Console.WriteLine($"This activity will last for {_duration} seconds.");
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("Well done!!");
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            Console.WriteLine();
        }

        public void ShowSpinner(int seconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int spinnerIndex = 0;
            string[] spinnerChars = { "|", "/", "-", "\\" };

            while (DateTime.Now < endTime)
            {
                Console.Write(spinnerChars[spinnerIndex]);
                Thread.Sleep(100);
                Console.Write("\b \b");
                spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
            }
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}
