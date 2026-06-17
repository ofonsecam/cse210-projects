using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run1 = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle1 = new Cycling("05 Nov 2022", 30, 27.5);
        Swimming swim1 = new Swimming("08 Nov 2022", 30, 50);

        activities.Add(run1);
        activities.Add(cycle1);
        activities.Add(swim1);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
