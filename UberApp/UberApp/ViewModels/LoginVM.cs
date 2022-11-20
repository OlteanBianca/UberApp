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
        #region Constructor

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

        private Command _openForgotPasswordPageCommand;
        public Command OpenForgotPasswordPageCommand
        {
            get
            {
                _openForgotPasswordPageCommand ??= new(LoginService.OpenForgotPasswordPageClicked);
                return _openForgotPasswordPageCommand;
            }
        }

        #endregion

        #region methods

        public override bool AreFieldsValid()
        {
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            return isEmailValid && isPasswordValid;
        }

        public override void InitializeProperties()
        {
            Password = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required!" });
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email required!" });
        }

        #endregion
    }
}