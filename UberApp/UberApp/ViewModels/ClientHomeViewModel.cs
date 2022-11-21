using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UberApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace UberApp.ViewModels
{
    public class ClientHomeViewModel:NotifyPropertyChangedService
    {
        private Position _pinPosition;

        public Position PinPosition
        {
            get { return _pinPosition; }
            set { 
                _pinPosition = value;
                OnPropertyChanged("PinPosition");
            }
        }
       
        public ClientHomeViewModel()
        {
            var location = Geolocation.GetLocationAsync();
            
            this.PinPosition = new Position(location.Result.Latitude, (double)location.Result.Longitude);
        }
    }
}
