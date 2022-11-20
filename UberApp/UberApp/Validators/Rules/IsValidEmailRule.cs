using Xamarin.Forms.Internals;

namespace UberApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        #region Properties

        public string ValidationMessage { get; set; }

        #endregion

        #region Method

        public bool Check(T value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress($"{value}");
                return addr.Address == $"{value}";
            }
            catch
            {
                return false;
                throw;
            }
        }
        #endregion
    }
}
