namespace HabitTracker.Dknx8888.Models;

public class Occurrence
{
    public int Id { get; init; }
    public int HabitId { get; set; }
    public DateOnly Date { get; set; }
    public double Quantity { get; set; }
    public string? Note { get; set; }
}