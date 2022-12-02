using System;
using System.Collections.ObjectModel;
using System.Linq;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace UberApp.ViewModels
{
    public class ClientHomeViewModel : NotifyPropertyChangedService
    {
        #region Private Fields

        private Pin _pin;

        private String _address;
        #endregion

        #region Public Fields

        public ObservableCollection<Pin> Pins { get; set; }

        #endregion

        #region Properties

        public Pin Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged();
            }
        }

        public String Address
        {
            get
            {
                return _address;
            }
            set
            {
                if(value == null)
                {
                    return;
                    
                }
                _address = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public ClientHomeViewModel()
        {
            this.Pins = new ObservableCollection<Pin>();  
        }

        public Command CallCabCommand
        {
            get
            {
                return new Command( async (e) =>
                {

                    if (Pins.Count != 0)
                    {
                        Pins.RemoveAt(0);
                    }

                    var clientLocation = await Geolocation.GetLocationAsync();

                    var locations = await Geocoding.GetLocationsAsync(this.Address);

                    var location = locations?.FirstOrDefault();

                    if (location != null)
                    {
                        Pin pin = new Pin
                        {
                            Label = this.Address,
                            Address = this.Address,
                            Type = PinType.Generic,
                            Position = new Position(location.Latitude, location.Longitude)
                        };

                        Pins.Add(pin);
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                        Console.WriteLine($"Address is: {Address}");

                        //Should send to db locatio and destination
                    }
                });
            }
        }

        #endregion
    }
}
