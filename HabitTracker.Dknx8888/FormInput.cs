namespace HabitTracker.Dknx8888;

public static class FormInput
{
    public static string StringInput(string prompt)
    {
        var isEmpty = false;
        while (true)
        {
            if (isEmpty)
            {
                Console.WriteLine("This can't be empty. Please try again.");
            }
            
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            isEmpty = true;
        }
    }
}