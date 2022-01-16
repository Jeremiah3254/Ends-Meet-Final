using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class dbManagement : MonoBehaviour
{

    //public int Levels;

    /*void Update() {
        //getLevel();
    }*/
    //public static int level {get;}

    void readDatabase() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT id, username, rank, level, XP, maxXP, dna " + "FROM player";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string rank = reader.GetString(2);
            int level = reader.GetInt32(3);
            int XP = reader.GetInt32(4);
            int maxXP = reader.GetInt32(5);
            int dna = reader.GetInt32(6);
            //basic assigning values from table then printing them to console till i get more of the implimentation stuff done.
            
            Debug.Log( "id:"+id+" username:"+username+" rank:"+rank+" Level:"+level+" xp:"+XP+" maxXP:"+maxXP+" dna:"+dna);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void createNewSave() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET username = 'Player 1',rank='beginner',level='0',XP='0',maxXP='50',dna='0',completedTutorial='0',zombieKills='0' WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void increaseDNA() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET username = 'Player 1',rank='beginner',level='0',XP='0',maxXP='50',dna='0',completedTutorial='0',zombieKills='0' WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void increaseXP() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET XP = (XP+2) WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void increaseLevel() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET XP = '0',maxXP = (maxXP+50),level = (level+1) WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void increaseZombieKills() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET zombiekills = (zombiekills+1) WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void completedtutorial() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE player SET completedTutorial = (completedTutorial+1) WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    
    public static int getLevel() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT level FROM player WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return 0;
    }
    
    public static int getXP() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT XP FROM player WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return 0;
    }

    public static int getmaxXP() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT maxXP FROM player WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return 0;
    }

    public static int getDNA() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT dna FROM player WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return 0;
    }

    public static int getZombieKills() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT zombieKills FROM player WHERE id = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return 0;
    }

    /*void addPlayer() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO player (username,rank,level,XP,maxXP,dna) VALUES ('newUsername', 'beginner', '1', '0', '25', '0')"; // basic testing to make sure i can change individual values from the table without having to deal with id's
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string rank = reader.GetString(2);
            int level = reader.GetInt32(3);
            int XP = reader.GetInt32(4);
            int maxXP = reader.GetInt32(5);
            int dna = reader.GetInt32(6);
            //basic assigning values from table then printing them to console till i get more of the implimentation stuff done.
            
            Debug.Log( "id:"+id+" username:"+username+" rank:"+rank+" Level:"+level+" xp:"+XP+" maxXP:"+maxXP+" dna:"+dna);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }*/
}
