namespace HabitTracker.Dknx8888;

public static class FormInput
{
    public static string StringInput(string prompt)
    {
        Console.WriteLine(prompt);

        var errorRow = Console.CursorTop; // row 1 
        Console.WriteLine();

        var inputRow = Console.CursorTop; // row 2
        var errorShown = false;
        
        while (true)
        {
            ClearLine(inputRow);
            Console.SetCursorPosition(0, inputRow);
            
            var input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input))
            {
                ClearLine(errorRow);
                Console.SetCursorPosition(0, inputRow + 1);
                
                return input;
            }

            if (!errorShown)
            {
                Console.SetCursorPosition(0, errorRow);
                Console.Write("This can't be empty. Please try again.");
                errorShown = true;
            }
        }
    }
    
    private static void ClearLine(int row)
    {
        Console.SetCursorPosition(0, row);
        
        // Overwrite the invalid input with spaces
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition(0, row);
    }
}