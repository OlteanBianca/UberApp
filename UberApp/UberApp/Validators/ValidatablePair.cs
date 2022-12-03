using System.Collections.Generic;
using System.Linq;
using UberApp.Services;
using Xamarin.Forms.Internals;

namespace UberApp.Validators
{
    [Preserve(AllMembers = true)]
    public class ValidatablePair<T> : NotifyPropertyChangedService, IValidatable<T>
    {
        #region Private Fields

        private bool isValid = true;
        private List<string> _errors = new();

        #endregion

        #region Public Properties

        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        public bool IsValid
        {
            get => isValid;
            set
            {
                isValid = value;
                OnPropertyChanged();
            }
        }

        public List<string> Errors
        {
            get => _errors;
            private set
            {
                _errors = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<T> Item1 { get; set; } = new ValidatableObject<T>();

        public ValidatableObject<T> Item2 { get; set; } = new ValidatableObject<T>();

        #endregion

        #region Public Methods

        public bool Validate()
        {
            var item1IsValid = Item1.Validate();
            var item2IsValid = Item2.Validate();

            if (item1IsValid && item2IsValid)
            {
                if (Item1.Value.ToString() != Item2.Value.ToString())
                {
                    Errors.Clear();
                    Errors = new() { "Passwords are not equal!" };
                    IsValid = false;
                    return IsValid;
                }

                Errors.Clear();
                Errors = Validations.Where(c => !c.Check(Item1.Value)).Select(v => v.ValidationMessage).ToList();
            }

            IsValid = !Item1.Errors.Any() && !Item2.Errors.Any() && !Errors.Any();
            return IsValid;
        }

        #endregion
    }
}
