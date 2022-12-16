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
           // _database.Table<Client>().Delete(val => true);

            if (_database.Table<Client>().Count() == 0)
            {
                Client newClient = new("client1", "mail1@gmail.com", "pass1");
                _database.Insert(newClient);

                newClient = new("client2", "mail2@gmail.com", "pass2");
                _database.Insert(newClient);

                newClient = new("client3", "mail3@gmail.com", "pass3");
                _database.Insert(newClient);
            }
        }

        private void AddDrivers()
        {
            //_database.Table<Driver>().Delete(var => true);

            if (_database.Table<Driver>().Count() == 0)
            {
                Driver newDriver = new("default", "default", "default", "", "");
                _database.Insert(newDriver);

                newDriver = new("driver1", "pass1", "driverMail1@gmail.com", "B74ACN", "Toyota");
                _database.Insert(newDriver);

                newDriver = new("driver2", "pass2", "driverMail2@gmail.com", "AB07LBC", "Sedan");
                _database.Insert(newDriver);

                newDriver = new("driver3", "pass3", "driverMail3@gmail.com", "BV89NMB", "Audi");
                _database.Insert(newDriver);
            }
        }

        private void AddRequests()
        {
            _database.Table<Request>().Delete(var => true);

            if (_database.Table<Request>().Count() == 0)
            {
                Request request = new()
                {
                    RequestId = 1,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client1").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "driver1").DriverId,
                    ClientLocationLongitude = 25.5f,
                    ClientLocationLatitude = 45.6f,
                    DestinationLongitude = 25.5840f,
                    DestinationLatitude = 45.6384f,
                    DestinationName = "Colegiul National Andrei Saguna",
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 2,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client2").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "driver2").DriverId,
                    ClientLocationLongitude = 25.62f,
                    ClientLocationLatitude = 45.6f,
                    DestinationLongitude = 25.609160f,
                    DestinationLatitude = 45.654096f,
                    DestinationName = "Colegiul National Dr. Ioan Mesota",
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 3,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client3").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "driver3").DriverId,
                    ClientLocationLongitude = 25.64f,
                    ClientLocationLatitude = 45.5f,
                    DestinationLongitude = 25.610608f,
                    DestinationLatitude = 45.650185f,
                    DestinationName = "Afi",
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 4,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client1").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "driver1").DriverId,
                    ClientLocationLongitude = 25.9f,
                    ClientLocationLatitude = 45.15f,
                    DestinationLongitude = 25.616820f,
                    DestinationLatitude = 45.672854f,
                    DestinationName = "Coresi",
                    Finished = true
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 5,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client2").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "driver2").DriverId,
                    ClientLocationLongitude = 25.48f,
                    ClientLocationLatitude = 45.4f,
                    DestinationLongitude = 25.580211f,
                    DestinationLatitude = 45.635816f,
                    DestinationName = "Piata Unirii",
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 6,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client3").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "default").DriverId,
                    ClientLocationLongitude = 25.27f,
                    ClientLocationLatitude = 45.43f,
                    DestinationLongitude = 25.589346f,
                    DestinationLatitude = 45.642212f,
                    DestinationName = "Piata Sfatului",
                };
                Database.Insert(request);

                request = new()
                {
                    RequestId = 7,
                    ClientId = _database.Table<Client>().First(var => var.Name == "client1").ClientId,
                    DriverId = _database.Table<Driver>().First(var => var.Name == "default").DriverId,
                    ClientLocationLongitude = 25.33f,
                    ClientLocationLatitude = 45.6f,
                    DestinationLongitude = 25.613573f,
                    DestinationLatitude = 45.661057f,
                    DestinationName = "Gara Brasov"
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
