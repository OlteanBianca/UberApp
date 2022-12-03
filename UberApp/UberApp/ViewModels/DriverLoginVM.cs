using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class DriverLoginVM : BaseLoginVM
    {
        #region Constructors

        public DriverLoginVM(ValidatableObject<string> email) : base()
        {
            Email = email;
            AddValidationRules();
        }

        #endregion

        #region Commands

        private Command _driverLoginCommand;
        public Command DriverLoginCommand
        {
            get
            {
                _driverLoginCommand ??= new(LoginService.DriverLoginClicked);
                return _driverLoginCommand;
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

        private Command _openResetPasswordPageCommand;
        public Command OpenResetPasswordPageCommand
        {
            get
            {
                _openResetPasswordPageCommand ??= new(LoginService.OpenResetPasswordPageClicked);
                return _openResetPasswordPageCommand;
            }
        }

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get
            {
                _openLoginPageCommand ??= new(LoginService.OpenLoginPageClicked);
                return _openLoginPageCommand;
            }
        }

        #endregion

        #region Public Methods

        public override bool AreFieldsValid()
        {
            bool isPasswordValid = Password.Validate();
            return isPasswordValid;
        }

        public override void InitializeProperties()
        {
            Password = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password required!" });
        }

        #endregion
    }
}