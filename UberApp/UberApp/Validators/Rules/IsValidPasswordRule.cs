using System.Text.RegularExpressions;
using Xamarin.Forms.Internals;

namespace UberApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsValidPasswordRule<T> : IValidationRule<T>
    {
        #region Private Fields

        public string ValidationMessage { get; set; }

        #endregion

        #region Public Methods

        public bool Check(T value)
        {
            string password = value.ToString();

            if (password.Length > 20 || password.Length < 6)
            {
                ValidationMessage = "Password must be less than 20 and more than 8 characters in length.";
                return false;
            }
            if (!Regex.Match(password, @"(.*[A-Z].*)").Success)
            {
                ValidationMessage = "Password must have at least one uppercase character";
                return false;
            }
            if (!Regex.Match(password, @"(.*[a-z].*)").Success)
            {
                ValidationMessage = "Password must have at least one lowercase character";
                return false;
            }
            if (!Regex.Match(password, @"(.*[0-9].*)").Success)
            {
                ValidationMessage = "Password must have at least one number";
                return false;
            }
            if (!Regex.Match(password, @"(.*[@#$%?!].*$)").Success)
            {
                ValidationMessage = "Password must have at least one special characters.";
                return false;
            }
            if (Regex.Match(password, @"(.*[+=.,;].*$)").Success)
            {
                ValidationMessage = "Password can't contain this characters: + = . , ;";
                return false;
            }
            return true;
        }

        #endregion
    }
}
