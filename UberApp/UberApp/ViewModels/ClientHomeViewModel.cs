using UberApp.Services;
using Xamarin.Forms.Maps;

namespace UberApp.ViewModels
{
    public class ClientHomeViewModel : NotifyPropertyChangedService
    {
        #region Private Fields

        private Position _pinPosition;

        #endregion

        #region Properties

        public Position PinPosition
        {
            get { return _pinPosition; }
            set
            {
                _pinPosition = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public ClientHomeViewModel()
        {
            //var location = Geolocation.GetLocationAsync();

            //PinPosition = new Position(location.Result.Latitude, (double)location.Result.Longitude);
        }

        #endregion
    }
}
