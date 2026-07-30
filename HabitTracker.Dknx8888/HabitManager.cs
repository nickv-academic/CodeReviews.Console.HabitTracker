using HabitTracker.Dknx8888.Data;
using HabitTracker.Dknx8888.Models;

namespace HabitTracker.Dknx8888;

public class HabitManager(HabitRepository habitRepository)
{
    public async Task ShowHabitMenu()
    {
        string? errorMessage = null;

        while (true)
        {
            var habits = habitRepository.GetAll();

            Console.Clear();
            Console.WriteLine("Habit Viewer\n");
            Console.WriteLine("Input the corresponding ID to select the habit\n" +
                              "N to create a new habit\n" +
                              "Q to go back\n");

            Console.WriteLine($"{"ID",-4} | {"Habit",-30} | {"Unit",-30}");
            Console.WriteLine(new string('-', 68));

            if (habits.Count == 0)
            {
                Console.WriteLine("<No habits found>");
            }

            foreach (var habit in habits)
            {
                Console.WriteLine($"{habit.Id,-4} | {habit.Name,-30} | {habit.Unit,-30}");
            }

            if (errorMessage is not null)
            {
                Console.WriteLine($"\n{errorMessage}");
            }

            var input = Console.ReadLine()?.Trim().ToLowerInvariant();

            // Remove the previous error unless this input creates another one.
            errorMessage = null;

            switch (input)
            {
                case "n":
                    await CreateHabit();
                    break;

                case "q":
                    return;

                default:
                    if (!int.TryParse(input, out var id))
                    {
                        errorMessage = "Invalid option. Please try again.";
                        break;
                    }

                    var selectedHabit = habits.FirstOrDefault(habit => habit.Id == id);

                    if (selectedHabit is null)
                    {
                        errorMessage = "No habit with that ID was found.";
                        break;
                    }

                    SelectHabit(selectedHabit);
                    break;
            }
        }
    }
    
    private async Task CreateHabit()
    {
        Console.Clear();
        var newHabitInput = FormInput.StringInput("What is the name of the new habit?");
        var unitInput = FormInput.StringInput("What is the unit of measurement for this habit?");
        
        Console.WriteLine("\nIs this correct? Press Y to confirm, N to cancel");
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

    private void SelectHabit(Habit selectedHabit)
    {
        var id = selectedHabit.Id;
        var name = selectedHabit.Name;
        var unit = selectedHabit.Unit;

        Console.WriteLine($"Habit {selectedHabit.Id} selected.\n");
        Console.WriteLine($"Name: {selectedHabit.Name}");
        Console.WriteLine($"Unit of measurement: {selectedHabit.Unit}\n");

        Console.WriteLine("Choose one of the following options:");
        Console.WriteLine("1. Edit name");
        Console.WriteLine("2. Edit unit");
        Console.WriteLine("3. Delete habit");
        Console.WriteLine("Q. Go back");
        
        var input = Console.ReadLine()?.Trim().ToLowerInvariant();

        switch (input)
        {
            case "q":
                return;
            
            case "1":
                FormInput.StringInput("What is the new name of the habit?");
                break;
            
            case "2":
                FormInput.StringInput("What is the new unit of measurement for this habit?");
                break;
            
            case "3":
                Console.WriteLine("Are you sure you want to delete this habit? (y/N");
                // TODO: Delete habit
                break;
                
            default:
                break;
        }

    }
}