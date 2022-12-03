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

        #endregion

        #region Constructors

        public Client() { }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        #endregion
    }
}
