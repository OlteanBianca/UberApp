using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class NotifyPropertyChangedService : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
