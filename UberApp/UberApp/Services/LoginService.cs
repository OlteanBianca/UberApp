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

        public void ResetPasswordClicked()
        {
            // Do something
        }

        public void CloseApplicationClicked()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void OpenResetPasswordPageClicked()
        {
            ResetPasswordPage resetPasswordPage = new();
            Xamarin.Forms.Application.Current.MainPage = resetPasswordPage;
        }

        public void OpenSignUpPageClicked()
        {
            SignUpPage signUpPage = new ();
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
