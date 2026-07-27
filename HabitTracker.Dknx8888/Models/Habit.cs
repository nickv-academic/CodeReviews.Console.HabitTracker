namespace HabitTracker.Dknx8888.Models;

public class Habit
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Unit { get; set; }
}