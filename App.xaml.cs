using System;
using AplicatieMobila.Data;
using System.IO;
namespace AplicatieMobila;

public partial class App : Application
{
    static CumparaturiDatabase database;
    public static CumparaturiDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
              CumparaturiDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Cumparaturi.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
