﻿using System.Text.Json;
using SqlMonitor.Domain.DB_Name;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

public class Program
{
    private static string connString = "";

    public static void Main()
    {
        using (var std = new SqlTableDependency<Group>(connString, "TableNameHere"))
        {
            std.OnChanged += Changed;
            std.OnError += Error;
            std.OnStatusChanged += StatusChanged;

            std.Start();

            Console.WriteLine("Any key to exit");
            Console.ReadKey();

            std.Stop();
        }
    }

    private static void StatusChanged(object sender, StatusChangedEventArgs e)
    {
        Console.WriteLine($"STATUS: {JsonSerializer.Serialize(e)}");
    }

    private static void Error(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
    {
        Console.WriteLine($"ERROR: {JsonSerializer.Serialize(e)}");
    }

    private static void Changed(object sender, RecordChangedEventArgs<Group> e)
    {
        Console.WriteLine($"CHANGE: {e.ChangeType} {JsonSerializer.Serialize(e.Entity)}");
    }
}
