using System.Collections.Generic;
using System.Linq;
using UberApp.Services;
using Xamarin.Forms.Internals;

namespace UberApp.Validators
{
    [Preserve(AllMembers = true)]
    public class ValidatableObject<T> : NotifyPropertyChangedService, IValidatable<T>
    {
        #region Private Fields

        private bool isValid = true;

        private List<string> errors = new();

        private bool cleanOnChange = true;

        private T value;

        #endregion

        #region Public Properties

        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        public List<string> Errors
        {
            get => errors;
            private set
            {
                errors = value;
                OnPropertyChanged();
            }
        }

        public bool CleanOnChange
        {
            get => cleanOnChange;
            set
            {
                cleanOnChange = value;
                OnPropertyChanged();
            }
        }

        public T Value
        {
            get => value;
            set
            {
                this.value = value;

                if (CleanOnChange)
                {
                    IsValid = true;
                }
            }
        }

        public bool IsValid
        {
            get => isValid;
            set
            {
                isValid = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public virtual bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        #endregion
    }
}
