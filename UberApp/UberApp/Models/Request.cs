using SQLite;


namespace UberApp.Models
{
    public class Request
    {
        [PrimaryKey,AutoIncrement]
        public int RequestId { get; set; }

        public int UserId { get; set; }

        public int DriverId { get; set; } = -1;

        public double ClientLocationLatitudine { get; set; }

        public double ClientLocationLongitudine { get; set; }

        public string DestinationLocation { get; set; }

        public bool Finished { get; set; } = false;
    }
}
