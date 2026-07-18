using Microsoft.Data.Sqlite;

namespace HabitTracker.Dknx8888.Data;

public class Database
{
    private const string ConnectionString = "Data Source=habit-tracker.db;Foreign Keys=True;";

    public static void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var tableCmd = connection.CreateCommand();

        tableCmd.CommandText = 
            """
                CREATE TABLE IF NOT EXISTS Habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Unit TEXT
                );

                CREATE TABLE IF NOT EXISTS Occurrences (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    HabitID INTEGER REFERENCES Habits(Id),
                    Date TEXT,
                    Quantity REAL CHECK (Quantity >= 0),
                    Note TEXT
                );
            """;

        tableCmd.ExecuteNonQuery();
    }
}