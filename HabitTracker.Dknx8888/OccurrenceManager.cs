namespace HabitTracker.Dknx8888;

public class OccurrenceManager
{
    public void CreateOccurrence()
    {
        var presentTime = DateTime.Now;
        
        Console.Clear();
        Console.WriteLine($"Today's date: {presentTime}\n");
        
        Console.WriteLine("Which habit did you do? (Press Ctrl - ... to view the list of habits)");
        var habitInput = Console.ReadLine()?.Trim();

        // TODO: Get selected unit from the habit
        var selectedUnit = "";
        
        Console.WriteLine("When did you do this?\n");
        Console.WriteLine("Input the exact timestamp (M/d/yyyy h:mm:ss tt), or, " +
                          "\nh:mm and the current day along with zero second will be recorded.");
        var dateInput = Console.ReadLine()?.Trim();
        
        Console.WriteLine($"Please indicate the quantity: {selectedUnit}");
        var quantityInput = Console.ReadLine()?.Trim();
        
        Console.WriteLine("Any notes for this occurrence? Press Enter without input to skip");
        var noteInput = Console.ReadLine()?.Trim();
    }

    public void ViewOccurrences()
    {
        
    }
}