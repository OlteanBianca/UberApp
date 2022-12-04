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

        private void AddRequests()
        {
            _database.Table<Request>().Delete(val => val.ClientId == 3 || val.ClientId == 1 || val.ClientId == 2);
            if (_database.Table<Request>().Count() == 0)
            {
                Request request = new()
                {
                    RequestId = 1,
                    ClientId = 1,
                    DriverId = 1,
                    ClientLocationLatitudine = 14,
                    ClientLocationLongitudine = 31,
                    DestinationLocation = "Colegiul National Andrei Saguna"
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 2,
                    ClientId = 2,
                    DriverId = 2,
                    ClientLocationLatitudine = 1200,
                    ClientLocationLongitudine = 1040,
                    DestinationLocation = "Colegiul National Dr. Ioan Mesota"
                }; 
                Database.Insert(request);

                request = new()
                {
                    RequestId = 3,
                    ClientId = 1,
                    DriverId = 2,
                    ClientLocationLatitudine = 5100,
                    ClientLocationLongitudine = 4100,
                    DestinationLocation = "Afi"
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 4,
                    ClientId = 2,
                    DriverId = 1,
                    ClientLocationLatitudine = 1050,
                    ClientLocationLongitudine = 1090,
                    DestinationLocation = "Coresi"
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 5,
                    ClientId = 3,
                    DriverId = 3,
                    ClientLocationLatitudine = 10,
                    ClientLocationLongitudine = 150,
                    DestinationLocation = "Piata Unirii"
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 6,
                    ClientId = 3,
                    DriverId = 2,
                    ClientLocationLatitudine = 150,
                    ClientLocationLongitudine = 120,
                    DestinationLocation = "Piata Sfatului"
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 7,
                    ClientId = 1,
                    DriverId = 2,
                    ClientLocationLatitudine = 150,
                    ClientLocationLongitudine = 120,
                    DestinationLocation = "Gara Brasov"
                };
                Database.Insert(request);
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
            AddRequests();
        }

        #endregion
    }
}
