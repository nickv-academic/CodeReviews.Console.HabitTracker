using HabitTracker.Dknx8888.Data;
using HabitTracker.Dknx8888.Models;

namespace HabitTracker.Dknx8888;

public class HabitManager(HabitRepository habitRepository)
{
    public async Task ShowHabitMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Habit Viewer\n");
            Console.WriteLine("Input the corresponding ID to select the habit\n" +
                              "N to create a new habit\n" +
                              "Q to go back\n");
        
            Console.WriteLine($"{"ID",-4} | {"Habit", -30} | {"Unit", -30}");
            Console.WriteLine(new string('-', 68));

            var habits = habitRepository.GetAll();

            if (habits.Count == 0)
            {
                Console.WriteLine("<No habits found>");
            }
            
            foreach (var habit in habits)
            {
                Console.WriteLine($"{habit.Id,-4} | {habit.Name,-30} | {habit.Unit,-30}");
            }
        
            var input = Console.ReadLine()?.Trim().ToLower();
        
            switch (input)
            {
                case "n":
                    await CreateHabit();
                    break;
            
                case "q":
                    return;
            
                default:
                    // TODO: Select
                    break;
            }
        }
    }
    
    private async Task CreateHabit()
    {
        Console.Clear();
        var newHabitInput = FormInput.StringInput("What is the name of the new habit?\n");
        var unitInput = FormInput.StringInput("What is the unit of measurement for this habit?\n");
        
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

        var newHabit = new Habit
        {
            Name = newHabitInput,
            Unit = unitInput
        };
        
        habitRepository.AddHabit(newHabit);
        
        Console.WriteLine("Habit created!");
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}