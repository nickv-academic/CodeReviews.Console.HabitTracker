using Microsoft.Data.Sqlite;

namespace HabitTracker.Dknx8888.Data;

public class Database
{
    private const string ConnectionString = "Data Source=habit-tracker.db;Foreign Keys=True;";

    public static SqliteConnection CreateConnection()
    {
        return new SqliteConnection(ConnectionString);
    }
    
    public static void Initialize()
    {
        using var connection = CreateConnection();
        connection.Open();

        using var tableCmd = connection.CreateCommand();

        tableCmd.CommandText = 
            """
                CREATE TABLE IF NOT EXISTS Habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Unit TEXT NOT NULL 
                );

                CREATE TABLE IF NOT EXISTS Occurrences (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    HabitId INTEGER REFERENCES Habits(Id),
                    Date TEXT,
                    Quantity REAL CHECK (Quantity >= 0),
                    Note TEXT
                );
            """;

        tableCmd.ExecuteNonQuery();
    }
}