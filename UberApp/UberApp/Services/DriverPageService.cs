using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class DriverPageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly DriverHomeVM _driverHomeVM;

        #endregion

        #region Constructors

        public DriverPageService(DriverHomeVM vm)
        {
            _dataBaseService = new();
            _driverHomeVM = vm;
        }

        #endregion

        #region Public Methods

        public void RefreshOrders()
        {
            var requests = _dataBaseService.GetActiveRequests();
            _driverHomeVM.Requests.Clear();
            foreach (var request in requests)
            {
                _driverHomeVM.Requests.Add(request);
            }
        }

        public void GoToOrderFlowPage(object obj)
        {
            if (obj is not Request request) return;
            request.Driver = _driverHomeVM.Driver;
            request.DriverId = _driverHomeVM.Driver.DriverId;

            _dataBaseService.UpdateRequest(request);

            OrderFlowPage orderFlowPage = new(request);
            Application.Current.MainPage = orderFlowPage;
        }

        public void OpenLoginPageClicked()
        {
            LoginPage loginPage = new();
            Application.Current.MainPage = loginPage;
        }

        #endregion
    }
}
