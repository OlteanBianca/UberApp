using SQLite;
using UberApp.Models;
using UberApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestsListPage : ContentPage
    {
        public RequestsListPage(object client)
        {
            InitializeComponent();
            BindingContext = new RequestsListVM(client);
        }
    }
}