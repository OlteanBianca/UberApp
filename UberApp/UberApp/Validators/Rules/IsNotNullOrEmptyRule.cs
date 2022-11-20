using Xamarin.Forms.Internals;

namespace UberApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        #region Properties

        public string ValidationMessage { get; set; }

        #endregion

        #region Methods

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = $"{value}";
            return !string.IsNullOrWhiteSpace(str);
        }

        #endregion
    }
}
