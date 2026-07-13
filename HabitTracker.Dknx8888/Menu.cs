namespace HabitTracker.Dknx8888;

public class Menu
{
    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Habit Tracker!");
        Console.WriteLine("Please choose one of the options below (1-4):");
        Console.WriteLine("1. New Occurrence");
        Console.WriteLine("2. Occurrence Manager");
        Console.WriteLine("3. Habit Manager");
        Console.WriteLine("4. Exit");
        
        var input = Console.ReadLine()?.Trim();

        switch (input)
        {
            case "1":
                // NewOccurence();
                break;
        }
    }
}