using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace UberApp.ViewModels
{
    public class ClientHomeViewModel
    {
        private Position _pinPosition;

        public Position PinPosition
        {
            get { return _pinPosition; }
            set { _pinPosition = value; }
        }
       
        public ClientHomeViewModel()
        {
            this.PinPosition= new Position(45.648300, 25.604586);
        }
    }
}
