using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace CLOB
{

    public class CLOB
    {
        string connectionString, table, text, title;
        public CLOB(string _connectionString, string _table, string _text, string _title)
        {
            connectionString = _connectionString;
            table = _table;
            text = _text;
            title = _title;
        }




        public string[] find(string textToFind)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "SELECT "+title+" FROM "+table+" WHERE CONTAINS( "+text+" , @textToFind )";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@textToFind", textToFind);
                SqlDataReader reader = command.ExecuteReader();
                var toReturn=new List<string>();
                int i=0;
                while (reader.Read()){
                    toReturn.Add((string)reader.GetValue(0));
                    i++;}
                reader.Close();
                return toReturn.ToArray();
            }
        }
        public bool addDocument(string path, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String text2 = File.ReadAllText(path);
                string queryString = "INSERT INTO "+table+"("+title+","+text+") VALUES (@title2,@text2)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@title2", name);
                command.Parameters.AddWithValue("@text2", text2);
                command.ExecuteNonQuery();
            }
            return true;

        }

        public bool deleteDocumentWith(string textToFind)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "SELECT " + title + " FROM " + table + " WHERE CONTAINS( " + text + " , @textToFind )";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@textToFind", textToFind);

                SqlDataReader toDelete = command.ExecuteReader();
                var toDeleteList = new List<string>();
                int i = 0;
                while (toDelete.Read())
                {
                    toDeleteList.Add((string)toDelete.GetValue(0));
                    i++;
                }
                toDelete.Close();

                queryString = "DELETE FROM "+table+" WHERE "+title+" = @title2";
                command = new SqlCommand(queryString, connection);
                foreach (var singleToDelte in toDeleteList)
                {
                    command.Parameters.AddWithValue("@title2", singleToDelte);
                    command.ExecuteNonQuery();
                    command.Parameters.RemoveAt("@title2");
                }
            }
            return true;
        }

        public bool deleteDocument(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryString = "DELETE FROM " + table + " WHERE " + title + " = @title2";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@title2", name);
                command.ExecuteNonQuery();
            }
            return true;
        }
        static void Main()
        { }
    }
}
