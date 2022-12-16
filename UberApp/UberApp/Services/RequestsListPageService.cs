using System.Collections.Generic;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class RequestsListPageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly RequestsListVM _requestsListVM;

        #endregion

        #region Constructors

        public RequestsListPageService(RequestsListVM vm)
        {
            _dataBaseService = new();
            _requestsListVM = vm;
        }

        #endregion

        #region Public Methods

        public void RefreshOrders()
        {
            List<Request> requests = new();

            if (_requestsListVM.Client != null)
            {
                requests = _dataBaseService.GetClientRequests(_requestsListVM.Client.ClientId);
            }
            if (_requestsListVM.Driver != null)
            {
                requests = _dataBaseService.GetDriverRequests(_requestsListVM.Driver.DriverId);
            }

            _requestsListVM.Requests.Clear();
            foreach (var request in requests)
            {
                _requestsListVM.Requests.Add(request);
            }
        }

        public void GoBackToProfilePageClicked()
        {
            if (_requestsListVM.Client != null)
            {
                ProfilePage profilePage = new(_requestsListVM.Client);
                Application.Current.MainPage = profilePage;
            }
            if (_requestsListVM.Driver != null)
            {
                ProfilePage profilePage = new(_requestsListVM.Driver);
                Application.Current.MainPage = profilePage;
            }
        }

        public void ContinueRequestClicked(object value)
        {
            if (value is not Request request) return;

            if (_requestsListVM.Client != null)
            {
                ClientHomePage clientHomePage = new(_requestsListVM.Client, request);
                Application.Current.MainPage = clientHomePage;
            }
        }

        #endregion
    }
}
