using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Threading.Channels;

namespace DN9;

public class SQLiteReader
{
    public string TableName { set; get; }
    private IDbConnection conn = null;    public string DbConnectionString { set; get; }


    public SQLiteReader(string connection, string table)
    {
        DbConnectionString = connection;
        TableName = table;
    }

    public IDbConnection DbConnection => new SQLiteConnection(this.DbConnectionString);

    public IEnumerable<object[]> ReadDbRow(IDbConnection connection)
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = String.Format(@"SELECT Start, End, Subject FROM {0}", TableName);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new object[3] {reader.GetString(0), reader.GetString(1), reader.GetString(2)};
        }

        reader.Close();

        try
        {
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void WriteDbRow(object[] row)
    {
        foreach (var o in row)
        {
            Console.Write(o + ",");
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        var connectionString = @"data source=C:\Users\armandoshala\RiderProjects\DotNet1_HS23\Arbeitsblaetter\DN9\app2020.db;";
        var reader = new SQLiteReader(connectionString, "Appointments");
        var conn = reader.DbConnection;
        foreach (var o in reader.ReadDbRow(conn))
        {
            reader.WriteDbRow(o);
        }

        conn.Close();
        Console.ReadKey();
    }
}