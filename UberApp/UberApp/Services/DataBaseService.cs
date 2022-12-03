using System.Collections.Generic;
using UberApp.Models;

namespace UberApp.Services
{
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

        public List<Request> GetActiveRequests()
        {
            return _db.Database.Table<Request>().Where(x => x.Finished == false).ToList();
        }

        public Client AddClient(Client client)
        {
            _db.Database.Insert(client);
            return _db.Database.Table<Client>().First(val => val.Email == client.Email && val.Name == client.Name);
        }

        public Client CheckIfUserIsClient(string email)
        {
            return _db.Database.Table<Client>().Where(val => val.Email == email).FirstOrDefault();
        }

        public Driver CheckIfUserIsDriver(string email)
        {
            return _db.Database.Table<Driver>().Where(val => val.Email == email).FirstOrDefault();
        }

        public Driver CheckDriverCredentials(string email, string password)
        {
            return _db.Database.Table<Driver>().FirstOrDefault(val => val.Email == email && val.Password == password);
        }

        #endregion
    }
}
