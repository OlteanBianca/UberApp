using UberApp.Validators;
using UberApp.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPasswordPage
    {
        public ResetPasswordPage(ValidatableObject<string> email)
        {
            InitializeComponent();
            BindingContext = new ResetPasswordVM(email);
        }
    }
}