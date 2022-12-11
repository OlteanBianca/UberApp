using UberApp.Models;
using UberApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderFlowPage : ContentPage
    {
        public OrderFlowPage(Request request)
        {
            InitializeComponent();
            BindingContext = new OrderFlowVM(request);
        }
    }
}