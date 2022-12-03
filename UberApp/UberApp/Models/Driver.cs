using SQLite;
using System.ComponentModel;

namespace UberApp.Models
{
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        public int DriverId { get; set; }

        public string Name { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
 
        public string Email { get; set; }

        public string LicensePlate { get; set; }

        public string CarModel { get; set; }

        public Driver() { }

        public Driver(string name, string password, string email, string licensePlate, string carModel)
        {
            Name = name;
            Password = password;
            Email = email;
            LicensePlate = licensePlate;
            CarModel = carModel;
        }
    }
}
