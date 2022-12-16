using SQLite;

namespace UberApp.Models
{
    public class Client
    {
        #region Public Properties

        [PrimaryKey, AutoIncrement]
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructors

        public Client() { }

        public Client(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        #endregion
    }
}
