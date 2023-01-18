using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class LoginService
    {
        #region Private Fields

        private readonly BaseLoginVM _viewModel;
        private readonly DataBaseService _dataBaseService;

        #endregion

        #region Constructors

        public LoginService(BaseLoginVM viewModel)
        {
            _viewModel = viewModel;
            _dataBaseService = new();
        }

        #endregion

        #region Private Methods

        private void AddNewClient(SignUpVM signUpVM)
        {
            Client client = new()
            {
                Name = signUpVM.Name.Value,
                Email = signUpVM.Email.Value
            };

            client = _dataBaseService.AddClient(client);
            if (client != null)
            {
                ClientHomePage clientHomePage = new(client);
                Application.Current.MainPage = clientHomePage;
            }
        }

        private void AddNewDriver(SignUpVM signUpVM)
        {
            Driver driver = new()
            {
                Name = signUpVM.Name.Value,
                Email = signUpVM.Email.Value,
                Password = signUpVM.Password.Item2.Value,
                LicensePlate = signUpVM.LicensePlate.Value,
                CarModel = signUpVM.CarModel.Value
            };

            driver = _dataBaseService.AddDriver(driver);
            if (driver != null)
            {
                DriverHomePage driverHomePage = new(driver);
                Application.Current.MainPage = driverHomePage;
            }
        }

        private void OpenDriverHomePage(Driver driver)
        {
            DriverHomePage driverHomePage = new(driver);
            Application.Current.MainPage = driverHomePage;
        }

        #endregion

        #region Public Methods

        public void LoginClicked()
        {
            if (_viewModel.AreFieldsValid())
            {
                var client = _dataBaseService.CheckCredentialsForClient(_viewModel.Email.Value, _viewModel.Password.Value);
                if (client != null)
                {
                    ClientHomePage clientHomePage = new(client);
                    Application.Current.MainPage = clientHomePage;
                    return;
                }

                var driver = _dataBaseService.CheckCredentialsForDriver(_viewModel.Email.Value, _viewModel.Password.Value);
                if (driver != null)
                {
                    DriverHomePage driverHomePage = new(driver);
                    Application.Current.MainPage = driverHomePage;
                    return;
                }

                _viewModel.Email.Errors = new() { "There is no account with this email address!" };
                _viewModel.Email.IsValid = false;
            }
        }

        public void SignUpClicked(object value)
        {
            if (value is not SignUpVM signUpVM) return;

            if (_viewModel.AreFieldsValid())
            {
                if (signUpVM.IsDriver)
                {
                    AddNewDriver(signUpVM);
                    return;
                }
                AddNewClient(signUpVM);
            }
        }

        public void ResetPasswordClicked(object value)
        {
            if (value is not ResetPasswordVM resetPasswordVM) return;

            if (resetPasswordVM.AreFieldsValid())
            {
                Driver driver = new()
                {
                    Name = resetPasswordVM.Name.Value,
                    Password = resetPasswordVM.Password.Item2.Value,
                    Email = resetPasswordVM.Email.Value
                };

                driver = _dataBaseService.ResetPassword(driver);
                if (driver != null)
                {
                    OpenDriverHomePage(driver);
                }
                resetPasswordVM.Name.Errors = new() { "Invalid username." };
                resetPasswordVM.Name.IsValid = false;
            }
        }

        public void CloseApplicationClicked()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void OpenResetPasswordPageClicked()
        {
            ResetPasswordPage resetPasswordPage = new(_viewModel.Email);
            Application.Current.MainPage = resetPasswordPage;
        }

        public void OpenSignUpPageClicked()
        {
            SignUpPage signUpPage = new();
            Application.Current.MainPage = signUpPage;
        }

        public void OpenLoginPageClicked()
        {
            LoginPage loginPage = new();
            Application.Current.MainPage = loginPage;
        }

        #endregion
    }
}
