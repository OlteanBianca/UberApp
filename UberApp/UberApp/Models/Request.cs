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

        public double ClientLocationLatitude { get; set; }

        public double ClientLocationLongitude { get; set; }

        public double DestinationLatitude { get; set; }

        public double DestinationLongitude { get; set; }

        public string DestinationName { get; set; }

        public bool Finished { get; set; } = false;

        [OneToOne]
        public Client Client { get; set; }

        [OneToOne]
        public Driver Driver { get; set; }

        #endregion

        #region Constructors

        public Request() { }

        public Request(int clientId, int driverId, double clientLocationlatitude, double clientLocationlongitude, string destinationLocation, bool finished)
        {
            ClientId = clientId;
            DriverId = driverId;
            ClientLocationLatitude = clientLocationlatitude;
            ClientLocationLongitude = clientLocationlongitude;
            DestinationName = destinationLocation;
            Finished = finished;
        }

        #endregion
    }
}
