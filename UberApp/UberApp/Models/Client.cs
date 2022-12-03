using SQLite;

namespace UberApp.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public Client() { }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
