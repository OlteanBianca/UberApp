using UberApp.Services;
using Xamarin.Forms.Internals;

namespace UberApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;

        #endregion

        #region Public Properties

        public string ValidationMessage { get; set; }

        #endregion

        #region Constructors

        public IsValidEmailRule()
        {
            _dataBaseService = new();
        }

        #endregion

        #region Public Methods

        public bool Check(T value)
        {
            if (_dataBaseService.CheckIfEmailIsAlreadyUsed($"{value}"))
                return false;

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
