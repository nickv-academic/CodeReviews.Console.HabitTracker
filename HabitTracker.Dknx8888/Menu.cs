namespace HabitTracker.Dknx8888;

public class Menu
{
    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Habit Tracker!");
            Console.WriteLine("Please choose one of the options below (1-4):");
            Console.WriteLine("1. New Occurrence");
            Console.WriteLine("2. Occurrence Manager");
            Console.WriteLine("3. Habit Manager");
            Console.WriteLine("4. Exit\n");
        
            var input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1":
                    var createOccurrence = new OccurrenceManager();
                    createOccurrence.CreateOccurrence();
                    break;
                case "2":
                    var viewOccurrence = new OccurrenceManager();
                    viewOccurrence.ViewOccurrences();
                    break;
                case "3":
                    var habitManager = new HabitManager();
                    await habitManager.ViewHabits();
                    break;
                case "4":
                    Console.WriteLine("\nGoodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    break;
            }
        }
    }
}