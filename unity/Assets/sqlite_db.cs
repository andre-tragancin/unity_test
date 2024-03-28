using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;        

public class sqlite_db : MonoBehaviour
{
    private string dbName = "URI=file:sqlite.db";

    // Start is called before the first frame update
    void Start()
    {
        // CreateDatabase();
        CreateTables();
    }

    void CreateTables()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // "Players" table
                command.CommandText = "CREATE TABLE IF NOT EXISTS Players (" +
                                      "PlayerId INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "PlayerName TEXT," +
                                      "CharaterIndex INTEGER NOT NULL,"+
                                      "CreatedOn DATETIME DEFAULT CURRENT_TIMESTAMP)";
                command.ExecuteNonQuery();

                // "CompletedLevels" table
                command.CommandText = "CREATE TABLE IF NOT EXISTS PlayerLevelInfo (" +
                                      "PlayerId INTEGER," +
                                      "LevelNumber INTEGER," +
                                      "TimePlayed INTEGER," +
                                      "LivesLeft INTEGER," +
                                      "LevelCompleted INTEGER," + // 1 for true, 0 for false
                                      "FOREIGN KEY(PlayerId) REFERENCES Players(PlayerId))";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    // Insert a new player into the "Players" table
    public void InsertPlayer(string playerName, int characterIndex)
{
    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO Players (PlayerName, CharaterIndex) VALUES (@playerName, @characterIndex)";
            command.Parameters.AddWithValue("@playerName", playerName);
            command.Parameters.AddWithValue("@characterIndex", characterIndex);
            command.ExecuteNonQuery();
        }

        connection.Close();
    }
}
    // Insert information about a completed level into the "PlayerLevelInfo" table
    public void InsertPlayerLevelInfo(int playerId, int levelNumber, int timePlayed, int livesLeft, bool levelCompleted)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO PlayerLevelInfo (PlayerId, LevelNumber, TimePlayed, LivesLeft, LevelCompleted) VALUES (@playerId, @levelNumber, @timePlayed, @livesLeft, @levelCompleted)";
                command.Parameters.AddWithValue("@playerId", playerId);
                command.Parameters.AddWithValue("@levelNumber", levelNumber);
                command.Parameters.AddWithValue("@timePlayed", timePlayed);
                command.Parameters.AddWithValue("@livesLeft", livesLeft);
                command.Parameters.AddWithValue("@levelCompleted", levelCompleted ? 1 : 0); // 1 for true, 0 for false
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
