using System.Data;
namespace SQLiteReader;
    class ReadSQLite
    {

        public ReadSQLite()
        {
            IDbConnection conn = null;
            var connectionString = @"data source=C:\Users\armandoshala\RiderProjects\DotNet1_HS23\Arbeitsblaetter\DN9\app2020.db;";
            conn = new SqliteConnection($"Data Source={connectionString}");
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Appointments";
            var reader = command.ExecuteReader();
            var row = new object[reader.FieldCount];
            while (reader.Read())
            {
                var count = reader.GetValues(row);
                for (var i = 0; i < count; i++)
                {
                    Console.Write("| {0} ", row[i]);
                    Console.WriteLine();
                }
            }

            conn.Close();
        }

    }
