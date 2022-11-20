using Xamarin.Forms.Internals;

namespace UberApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the validation Message.
        /// </summary>
        public string ValidationMessage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Check the Email has null or empty
        /// </summary>
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
