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
            get => _loginCommand ??= new(LoginService.LoginClicked);
        }

        private Command _openSignUpPageCommand;
        public Command OpenSignUpPageCommand
        {
            get => _openSignUpPageCommand ??= new(LoginService.OpenSignUpPageClicked);
        }

        private Command _openResetPasswordPageCommand;
        public Command OpenResetPasswordPageCommand
        {
            get => _openResetPasswordPageCommand ??= new(LoginService.OpenResetPasswordPageClicked);
        }

        #endregion

        #region Public Methods

        public override bool AreFieldsValid()
        {
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            return isEmailValid && isPasswordValid;
        }

        public override void InitializeProperties()
        {
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email required!" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password required!" });
        }

        #endregion
    }
}