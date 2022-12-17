using UberApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAccountPage : ContentPage
    {
        public EditAccountPage(object value)
        {
            InitializeComponent();
            BindingContext = new EditAccountVM(value);
        }
    }
}