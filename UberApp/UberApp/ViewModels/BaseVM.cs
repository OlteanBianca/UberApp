using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UberApp.Services;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class BaseVM : NotifyPropertyChangedService
    {
        #region Protected Methods

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
