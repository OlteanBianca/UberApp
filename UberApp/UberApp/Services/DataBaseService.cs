using System.Collections.Generic;
using UberApp.Models;
using Xamarin.Forms.Internals;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class DataBaseService
    {
        #region Private Fields

        private readonly DatabaseSqLite _db;

        #endregion

        #region Constructors

        public DataBaseService()
        {
            _db = new();
        }

        #endregion

        #region Public Methods

        public int AddRequest(Request request)
        {
            return _db.Database.Insert(request);
        }

        public Client AddClient(Client client)
        {
            _db.Database.Insert(client);
            return _db.Database.Table<Client>().First(val => val.Email == client.Email);
        }

        public Driver AddDriver(Driver driver)
        {
            _db.Database.Insert(driver);
            return _db.Database.Table<Driver>().First(val => val.Email == driver.Email);
        }


        public int UpdateRequest(Request request)
        {
            return _db.Database.Update(request);
        }

        public Client UpdateClient(Client client)
        {
            _db.Database.Update(client);
            return GetClient(client.ClientId);
        }

        public Driver UpdateDriver(Driver driver)
        {
            _db.Database.Update(driver);
            return GetDriver(driver.DriverId);
        }

        public Driver ResetPassword(Driver driver)
        {
            var value = _db.Database.Table<Driver>().FirstOrDefault(val => val.Email == driver.Email && val.Name == driver.Name);

            if (value != null)
            {
                value.Password = driver.Password;
                if (_db.Database.Update(value) != 0)
                {
                    return _db.Database.Table<Driver>().First(val => val.DriverId == value.DriverId);
                }
            }
            return null;
        }


        public Client GetClient(int id)
        {
            return _db.Database.Table<Client>().FirstOrDefault(val => val.ClientId == id);
        }

        public Driver GetDriver(int id)
        {
            return _db.Database.Table<Driver>().FirstOrDefault(val => val.DriverId == id);
        }

        public List<Request> GetActiveRequests()
        {
            return _db.Database.Table<Request>().Where(x => x.Finished == false).ToList();
        }

        public List<Request> GetClientRequests(int id)
        {
            return _db.Database.Table<Request>().Where(var => var.ClientId == id).ToList();
        }

        public List<Request> GetDriverRequests(int id)
        {
            return _db.Database.Table<Request>().Where(var => var.DriverId == id).ToList();
        }


        public bool CheckIfEmailIsAlreadyUsed(string email)
        {
            return CheckIfUserIsClient(email) != null || CheckIfUserIsDriver(email) != null;
        }

        public Client CheckIfUserIsClient(string email)
        {
            return _db.Database.Table<Client>().Where(val => val.Email == email).FirstOrDefault();
        }

        public Driver CheckIfUserIsDriver(string email)
        {
            return _db.Database.Table<Driver>().Where(val => val.Email == email).FirstOrDefault();
        }

        public Driver CheckCredentialsForDriver(string email, string password)
        {
            return _db.Database.Table<Driver>().FirstOrDefault(val => val.Email == email && val.Password == password);
        }

        public Client CheckCredentialsForClient(string email, string password)
        {
            return _db.Database.Table<Client>().FirstOrDefault(val => val.Email == email && val.Password == password);
        }

        #endregion
    }
}
