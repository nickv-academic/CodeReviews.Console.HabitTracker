namespace HabitTracker.Dknx8888;

public class HabitManager
{
    public async Task ViewHabits()
    {
        Console.Clear();
        Console.WriteLine("Habit Viewer\n");
        Console.WriteLine("Input the habit ID to select it\n" +
                          "N to create a new habit\n" +
                          "Q to go back\n");
        
        Console.WriteLine($"{"ID",-4} | {"Habit", -30} | {"Unit", -30}");
        Console.WriteLine(new string('-', 68));
        
        // TODO: View habits
        
        var input = Console.ReadLine()?.Trim();
    
        // TODO: Input check
        await CreateHabit();
    }
    
    private async Task CreateHabit()
    {
        Console.Clear();
        Console.WriteLine("What is the name of the new habit?");
        var newHabitInput = Console.ReadLine()?.Trim();
        
        Console.WriteLine("What is the unit of measurement for this habit?");
        var unitInput = Console.ReadLine()?.Trim();
        
        Console.WriteLine("Is this correct? Press Y to confirm, N to cancel");
        Console.WriteLine($"New habit: {newHabitInput}");
        Console.WriteLine($"Unit: {unitInput}");

        ConsoleKey key;

        do
        {
            key = Console.ReadKey(intercept: true).Key;
        } while (key is not ConsoleKey.Y and not ConsoleKey.N);

        if (key == ConsoleKey.N)
        {
            return;
        }
        
        Console.WriteLine("Habit created!");
        // TODO: Save new habit to database
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}