using UberApp.Models;
using UberApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientHomePage : ContentPage
    {
        public ClientHomePage(Client client)
        {
            InitializeComponent();
            BindingContext = new ClientHomeVM(client);
        }
    }
}