using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;                                        

public class testeDB : MonoBehaviour
{
    private string dbName = "URI=file:Game.db";
    // Start is called before the first frame update

    void Start()
    {
        CreateDB();
        CreateTimeTable();
        CreateUserTable();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS game (name VARCHAR(20), id INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }                    
    }

    void CreateTimeTable()
    {
        using (var connection = new SqliteConnection(dbName))
        {
             connection.Open();

             using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS ScreenTime (screenName TEXT, timeSpent INTEGER)";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void UpdateScreenTime(string screenName, int timeSpent)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Comando SQL para inserir ou atualizar o tempo da tela especificada
                command.CommandText = "INSERT OR REPLACE INTO ScreenTime (ScreenName, TimeSpent) VALUES (@screenName, @timeSpent)";
                command.Parameters.AddWithValue("@screenName", screenName);
                command.Parameters.AddWithValue("@timeSpent", timeSpent);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    void CreateUserTable()
    {
         using (var connection = new SqliteConnection(dbName))
        {
             connection.Open();

             using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (" +
                                        "UserId INTEGER PRIMARY KEY AUTOINCREMENT," +
                                        "UserName TEXT NOT NULL," +
                                        "CharaterIndex INTEGER NOT NULL,"+
                                        "CreatedOn DATETIME DEFAULT CURRENT_TIMESTAMP)";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

   public void InsertUser(string userName, int characterIndex)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO User (UserName, CharaterIndex) VALUES (@userName, @characterIndex)";
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@characterIndex", characterIndex);

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
