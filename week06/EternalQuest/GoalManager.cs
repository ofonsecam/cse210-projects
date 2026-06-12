using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = Math.Max(1, (_score / 1000) + 1);

        string title = "Novice Questor";
        if (level == 2)
        {
            title = "Apprentice Tracker";
        }
        else if (level == 3)
        {
            title = "Eternal Adventurer";
        }
        else if (level >= 4)
        {
            title = "Master Elite Titan";
        }

        Console.WriteLine($"[RANK: {title} | LVL: {level}]");
        Console.WriteLine($"You have {_score} points.");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bad Habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");

        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            points = 0;
        }

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    target = 1;
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    bonus = 0;
                }

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record events.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }

        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal selectedGoal = _goals[index - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already completed!");
            return;
        }

        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;

        if (pointsEarned < 0)
        {
            Console.WriteLine($"Ouch! You triggered a bad habit and lost {Math.Abs(pointsEarned)} points.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }

        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            return;
        }

        _goals.Clear();

        if (int.TryParse(lines[0], out int savedScore))
        {
            _score = savedScore;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromString(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        string[] parts = line.Split(':');
        string type = parts[0];
        string[] details = parts[1].Split(',');

        if (type == "SimpleGoal")
        {
            return new SimpleGoal(
                details[0],
                details[1],
                int.Parse(details[2]),
                bool.Parse(details[3]));
        }

        if (type == "EternalGoal")
        {
            return new EternalGoal(details[0], details[1], int.Parse(details[2]));
        }

        if (type == "ChecklistGoal")
        {
            return new ChecklistGoal(
                details[0],
                details[1],
                int.Parse(details[2]),
                int.Parse(details[3]),
                int.Parse(details[4]),
                int.Parse(details[5]));
        }

        if (type == "NegativeGoal")
        {
            return new NegativeGoal(details[0], details[1], int.Parse(details[2]));
        }

        return null;
    }
}
