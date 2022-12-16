
using System;
using System.Collections.Generic;
using System.Text;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class ProfilePageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly ProfilePageVM _profilePageVM;

        #endregion

        #region Constructors

        public ProfilePageService(ProfilePageVM vm)
        {
            _profilePageVM = vm;
            _dataBaseService = new();
        }

        #endregion

        #region Public Methods

        public void BackButtonClicked()
        {
            if(_profilePageVM.Driver != null)
            {
                DriverHomePage driverHomePage = new(_profilePageVM.Driver);
                Application.Current.MainPage = driverHomePage;
                return;
            }
            if (_profilePageVM.Client != null)
            {
                ClientHomePage clientHomePage = new(_profilePageVM.Client);
                Application.Current.MainPage = clientHomePage;
            }
        }

        public void EditClicked()
        {

        }

        #endregion
    }
}
