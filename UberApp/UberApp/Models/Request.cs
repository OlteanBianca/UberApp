using SQLite;
using SQLiteNetExtensions.Attributes;

namespace UberApp.Models
{
    [Table("Requests")]
    public class Request
    {
        #region Public Properties

        [PrimaryKey, AutoIncrement]
        public int RequestId { get; set; }

        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(typeof(Driver))]
        public int DriverId { get; set; }

        public double ClientLocationLatitudine { get; set; }

        public double ClientLocationLongitudine { get; set; }

        public string DestinationLocation { get; set; }

        public bool Finished { get; set; } = false;

        [OneToOne]
        public Client Client { get; set; }

        [OneToOne]
        public Driver Driver { get; set; }

        #endregion

        #region Constructors

        public Request() { }

        public Request(int clientId, int driverId, double clientLocationLatitudine, double clientLocationLongitudine, string destinationLocation, bool finished)
        {
            ClientId = clientId;
            DriverId = driverId;
            ClientLocationLatitudine = clientLocationLatitudine;
            ClientLocationLongitudine = clientLocationLongitudine;
            DestinationLocation = destinationLocation;
            Finished = finished;
        }

        #endregion
    }
}
