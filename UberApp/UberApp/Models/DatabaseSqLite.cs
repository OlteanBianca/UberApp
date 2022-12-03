using SQLite;
using System;
using System.IO;

namespace UberApp.Models
{
    public class DatabaseSqLite
    {
        #region Private Fields

        private readonly SQLiteConnection _database;

        // create the database if it doesn't exist
        // enable multi-threaded database access
        private const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create |
                                              SQLiteOpenFlags.SharedCache;

        #endregion

        #region Public Properties

        public SQLiteConnection Database { get { return _database; } }

        #endregion

        #region Private Methods

        private void CreateTables()
        {
            _database.CreateTable<Client>();
            _database.CreateTable<Driver>();
            _database.CreateTable<Request>();
        }

        private void AddClients()
        {
            if (_database.Table<Client>().Count() == 0)
            {
                Client newClient = new("client1", "mail1@gmail.com");
                _database.Insert(newClient);

                newClient = new("client2", "mail2@gmail.com");
                _database.Insert(newClient);

                newClient = new("client3", "mail3@gmail.com");
                _database.Insert(newClient);
            }
        }

        private void AddDrivers()
        {
            if (_database.Table<Driver>().Count() == 0)
            {
                Driver newDriver = new("driver1", "pass1", "driverMail1@gmail.com", "B74ACN", "Toyota");
                _database.Insert(newDriver);

                newDriver = new("driver2", "pass2", "driverMail2@gmail.com", "AB07LBC", "Sedan");
                _database.Insert(newDriver);

                newDriver = new("driver3", "pass3", "driverMail3@gmail.com", "BV89NMB", "Audi");
                _database.Insert(newDriver);
            }
        }


        #endregion

        #region Constructors

        public DatabaseSqLite()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SQLiteDB.db");
            _database = new SQLiteConnection(path, Flags);

            CreateTables();
            AddClients();
            AddDrivers();
        }

        #endregion
    }
}
