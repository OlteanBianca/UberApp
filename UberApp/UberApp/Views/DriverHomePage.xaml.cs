using UberApp.Models;
using UberApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverHomePage : ContentPage
    {
        public DriverHomePage(Driver driver)
        {
            InitializeComponent();
            BindingContext = new DriverHomeVM(driver);
        }
    }
}