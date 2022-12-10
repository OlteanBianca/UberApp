using System.Runtime.CompilerServices;
using UberApp.Models;
using UberApp.Services;

namespace UberApp.ViewModels
{
    public class OrderFlowVM:NotifyPropertyChangedService
    {
        private readonly OrderFlowPageService _orderFlowPageService;
        private Driver _driver;

        public Driver Driver
        {
            get { return _driver; }
            set { _driver = value;
                OnPropertyChanged();

            }
        }

        private Request _request;
        public Request Request
        {
            get { return _request; }
            set { _request = value;
                OnPropertyChanged();
            }
        }

        private bool _clientPicked = false;

        public bool ClientPicked
        {
            get { return _clientPicked; }
            set { _clientPicked = value;
                OnPropertyChanged();
            }
        }

        private bool _requestFinished = false;

        public bool RequestFinished
        {
            get { return _requestFinished; }
            set
            {
                _requestFinished = value;
                OnPropertyChanged();
            }
        }

        public OrderFlowVM(Driver driver, Request request)
        {
            Driver = driver;
            Request = request;
            _orderFlowPageService = new(this); 
        }


    }
}
