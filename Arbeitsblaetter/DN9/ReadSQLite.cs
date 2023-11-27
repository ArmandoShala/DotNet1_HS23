using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace DN9 {
    public class SQLiteReader {
        public string DbConnectionString { get; set; }
        public string TableName { get; set; }

        private IDbConnection conn = null;

        public SQLiteReader(string connection, string table) {
            DbConnectionString = connection;
            TableName = table;
            conn = new SqliteConnection($"Data Source={DbConnectionString}");
			conn.Open();
        }


        public IDbConnection DbConnection {
            get {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                return conn;
            }
        }

        public IEnumerable<object[]> ReadDbRow(IDbConnection conn) {
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM {TableName}";
            var reader = command.ExecuteReader();
            
            while (reader.Read()) {
                var row = new object[reader.FieldCount];
                reader.GetValues(row);
                yield return row;
            }
        }
        
        public void WriteDbRow(object[] row) {
            foreach (object o in row) {
                Console.Write($"{o},");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args) {
            var connectionString = @"data source=C:\Users\armandoshala\RiderProjects\DotNet1_HS23\Arbeitsblaetter\DN9\app2020.db;";
            var reader = new SQLiteReader(connectionString, "Appointments");
            var conn = reader.DbConnection;
            
            foreach (object[] o in reader.ReadDbRow(conn)) {
                reader.WriteDbRow(o);
            }
            
            conn.Close();
            Console.ReadKey();
        }
    }
}
