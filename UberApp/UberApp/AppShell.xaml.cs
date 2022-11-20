using System;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ResetPasswordPageWithGradient), typeof(ResetPasswordPageWithGradient));
            Routing.RegisterRoute(nameof(ForgotPasswordPageWithGradient), typeof(ForgotPasswordPageWithGradient));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
        }
    }
}
