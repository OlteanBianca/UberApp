using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class LoginVM : BaseLoginVM
    {
        #region Constructors

        public LoginVM() : base()
        {
            AddValidationRules();
        }

        #endregion

        #region Commands

        private Command _loginCommand;
        public Command LoginCommand
        {
            get
            {
                _loginCommand ??= new(LoginService.LoginClicked);
                return _loginCommand;
            }
        }

        private Command _openSignUpPageCommand;
        public Command OpenSignUpPageCommand
        {
            get
            {
                _openSignUpPageCommand ??= new(LoginService.OpenSignUpPageClicked);
                return _openSignUpPageCommand;
            }
        }

        #endregion

        #region Public Methods

        public override bool AreFieldsValid()
        {
            bool isEmailValid = Email.Validate();
            return isEmailValid;
        }

        public override void InitializeProperties()
        {
            Email = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email required!" });
        }

        #endregion
    }
}