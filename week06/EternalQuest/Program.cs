/*
===========================================================================================
CREATIVITY & EXCEEDING REQUIREMENTS DOCUMENTATION:

1. Dynamic Leveling & Title System (GoalManager.DisplayPlayerInfo):
   The player earns a visible rank and level based on total score. Every 1,000 points
   advances one level and unlocks a new title:
     - Level 1: Novice Questor
     - Level 2: Apprentice Tracker
     - Level 3: Eternal Adventurer
     - Level 4+: Master Elite Titan
   This gives immediate feedback on long-term progress beyond the raw point total.

2. NegativeGoal — Bad Habits System:
   A fourth goal type tracks behaviors the user wants to avoid. Unlike positive goals,
   recording a bad habit subtracts points from the score (RecordEvent returns -Points).
   Negative goals never complete, so they can always be logged when a slip occurs.
   The list view shows a clear penalty label: "Bad Habit (Penalizes: -X pts)".
===========================================================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
