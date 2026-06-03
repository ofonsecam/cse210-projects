using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base(
                "Breathing Activity",
                "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
            bool breatheIn = true;

            while (DateTime.Now < endTime)
            {
                if (breatheIn)
                {
                    Console.Write("Breathe in... ");
                    ShowCountDown(4);
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Breathe out...");
                    ShowCountDown(4);
                    Console.WriteLine();
                }

                breatheIn = !breatheIn;
            }

            DisplayEndingMessage();
        }
    }
}
