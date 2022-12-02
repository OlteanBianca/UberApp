using System.Threading.Tasks;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;

namespace UberApp.Services
{
    public class LoginService
    {
        private readonly BaseLoginVM _viewModel;

        public LoginService(BaseLoginVM viewModel)
        {
            _viewModel = viewModel;
        }

        public async void LoginClicked(object obj)
        {
            await Db();

            if (_viewModel.AreFieldsValid())
            {
                ClientHomePage clientHomePage = new();
                Xamarin.Forms.Application.Current.MainPage = clientHomePage;
            }
        }

        public async Task<bool> Db()
        {
            DataBase dataBase = new();
            bool result = false;

            result = await dataBase.Check(_viewModel.Email.Value);

            return result;
        }

        public void SignUpClicked(object obj)
        {
            if (_viewModel.AreFieldsValid())
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
                Xamarin.Forms.Application.Current.MainPage = resetPasswordPage;
            }
        }

        public void OpenSignUpPageClicked()
        {
            SignUpPage signUpPage = new();
            Xamarin.Forms.Application.Current.MainPage = signUpPage;
        }

        public void OpenLoginPageClicked()
        {
            LoginPage loginPage = new();
            Xamarin.Forms.Application.Current.MainPage = loginPage;
        }

        public void OpenForgotPasswordPageClicked()
        {
            ForgotPasswordPage forgotPasswordPage = new();
            Xamarin.Forms.Application.Current.MainPage = forgotPasswordPage;
        }
    }
}
