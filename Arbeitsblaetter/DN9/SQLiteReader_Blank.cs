using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace DN9 {
    public class SQLiteReader_Blank {
        public string DbConnectionString { set; get; }
        public string TableName { set; get; }

        private IDbConnection conn = null;

        public SQLiteReader_Blank(string connection, string table) {
            // TODO Implement
        }

        // use Connection String to open DB connection
        // return open connection
        public IDbConnection DbConnection {
             // TODO Implement
        }

        public IEnumerable<object[]> ReadDbRow(IDbConnection conn) {
            // TODO Implement
        }
        public void WriteDbRow(object[] row) {
            foreach (object o in row) {
                Console.Write(o + ",");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args) {
            string connectionString = @"data source=c:\tmp\app2020.db;";
            SQLiteReader reader = new SQLiteReader(connectionString, "Appointments");
            IDbConnection conn = reader.DbConnection;
            foreach (object[] o in reader.ReadDbRow(conn)) {
                reader.WriteDbRow(o);
            }
            conn.Close();
            Console.ReadKey();
        }
    }
}