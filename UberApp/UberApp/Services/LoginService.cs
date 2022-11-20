using UberApp.ViewModels;
using UberApp.Views;

namespace UberApp.Services
{
    public class LoginService
    {
        private readonly BaseLoginViewModel _viewModel;

        public LoginService(BaseLoginViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void LoginClicked(object obj)
        {
            //if (_viewModel.AreFieldsValid())
            //{
            //    // Do Something
            //}
        }

        public void SignUpClicked(object obj)
        {
            // Do Something
        }

        public void ForgotPasswordClicked(object obj)
        {
            // Do something
        }

        public void ResetPasswordClicked(object obj)
        {
            // Do something
        }

        public void OpenSignUpPageClicked(object obj)
        {
            SignUpPageViewModel signUpPageViewModel = new ();
            SignUpPage signUpPage = new ();
            Xamarin.Forms.Application.Current.MainPage = signUpPage;
        }

        public void OpenLoginPageClicked(object obj)
        {
            LoginPageViewModel loginPageViewModel = new();
            LoginPage loginPage = new();
            Xamarin.Forms.Application.Current.MainPage = loginPage;
        }
    }
}
