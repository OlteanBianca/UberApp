using UberApp.Services;
using UberApp.Validators.Rules;
using UberApp.Validators;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ForgotPasswordVM : BaseLoginVM
    {
        #region Constructor

        public ForgotPasswordVM() : base()
        {
        }

        #endregion

        #region Methods

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

        #region Commands

        private Command _openResetPasswordPageCommand;
        public Command OpenResetPasswordPageCommand
        {
            get
            {
                _openResetPasswordPageCommand ??= new(LoginService.OpenResetPasswordPageClicked);
                return _openResetPasswordPageCommand;
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
    }
}