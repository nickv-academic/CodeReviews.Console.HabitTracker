using HabitTracker.Dknx8888.Models;
using Microsoft.Data.Sqlite;

namespace HabitTracker.Dknx8888.Data;

public class HabitRepository
{
    public List<Habit> GetAll()
    {
        var habitList = new List<Habit>();
        
        try
        {
            using var connection = Database.CreateConnection();
            connection.Open();

            const string sql = "SELECT Id, Name, Unit FROM Habits";

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var habit = new Habit
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Unit = reader.GetString(2)
                };

                habitList.Add(habit);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return habitList;
    }

    public void AddHabit(Habit newHabit)
    {
        try
        {
            using var connection = Database.CreateConnection();
            connection.Open();

            const string sql =
                """
                    INSERT INTO Habits (Name, Unit)
                    VALUES (@name, @unit)
                """;

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("@name", newHabit.Name);
            command.Parameters.AddWithValue("@unit", newHabit.Unit);

            command.ExecuteNonQuery();
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}