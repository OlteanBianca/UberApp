using System.Collections.Generic;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class LoginService
    {
        private readonly BaseLoginVM _viewModel;
        private readonly DataBaseService _dataBaseService;

        public LoginService(BaseLoginVM viewModel)
        {
            _viewModel = viewModel;
            _dataBaseService = new();
        }

        public void LoginClicked()
        {
            if (_viewModel.AreFieldsValid())
            {
                var client = _dataBaseService.CheckIfUserIsClient(_viewModel.Email.Value);
                if (client != null)
                {
                    ClientHomePage clientHomePage = new(client);
                    Application.Current.MainPage = clientHomePage;
                    return;
                }
                if (_dataBaseService.CheckIfUserIsDriver(_viewModel.Email.Value) != null)
                {
                    DriverLoginPage driverLoginPage = new(_viewModel.Email);
                    Application.Current.MainPage = driverLoginPage;
                    return;
                }
                _viewModel.Email.Errors.Clear();
                _viewModel.Email.Errors.Add("There is no account with this email address!");
                _viewModel.Email.IsValid = false;
            }
        }

        public void DriverLoginClicked()
        {
            if(_viewModel.AreFieldsValid())
            {
                var driver = _dataBaseService.CheckDriverCredentials(_viewModel.Email.Value, _viewModel.Password.Value);
                if (driver != null)
                {
                    DriverHomePage driverHomePage = new(driver);
                    Application.Current.MainPage = driverHomePage;
                    return;
                }
                _viewModel.Password.Errors.Add("Invalid Password!");
            }
            
            //DriverLoginPage driverLoginPage = new(_viewModel.Email);
            //Application.Current.MainPage = driverLoginPage;
        }

        public void SignUpClicked(object obj)
        {
            if(_viewModel.AreFieldsValid())
            {

            }
        }

        public void ResetPasswordClicked()
        {
            if (_viewModel.AreFieldsValid())
            {

            }
        }


        public void CloseApplicationClicked()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void OpenResetPasswordPageClicked()
        {
            if (_viewModel.AreFieldsValid())
            {
                ResetPasswordPage resetPasswordPage = new();
                Application.Current.MainPage = resetPasswordPage;
            } 
        }

        public void OpenSignUpPageClicked()
        {
            SignUpPage signUpPage = new ();
            Application.Current.MainPage = signUpPage;
        }

        public void OpenLoginPageClicked()
        {
            LoginPage loginPage = new();
            Application.Current.MainPage = loginPage;
        }

        public void OpenForgotPasswordPageClicked()
        {
            ForgotPasswordPage forgotPasswordPage = new();
            Application.Current.MainPage = forgotPasswordPage;
        }
    }
}
