using UnityEngine;
using Mono.Data.Sqlite;

namespace MazeGame.Core
{
    public class BaseDatabase
    {
        private string m_dbName = "";
        private string m_dbFile = "";
        private SqliteConnection m_connection = null;

        public BaseDatabase(string dbName, string dbFile)
        {
            m_dbName = dbName;
            m_dbFile = dbFile;
            m_connection = new SqliteConnection(dbFile);
        }

        public void ExecuteSQL(string sql)
        {
            m_connection.Open();
            using (SqliteCommand cmd = m_connection.CreateCommand())
            {
                cmd.CommandText = sql;
                using (SqliteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Debug.Log(dr["fin"]);
                    }
                }
            }
            m_connection.Close();
        }
    }

    public class DialogueDatabase : BaseDatabase
    {
        public DialogueDatabase(
            string dbName = "dialogue",
            string dbFile = "URI=file:Assets/Resources/dialogue.db") : base(dbName, dbFile)
        {
        }
    }
}