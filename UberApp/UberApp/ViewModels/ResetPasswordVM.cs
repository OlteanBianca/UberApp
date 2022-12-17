using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ResetPasswordVM : BaseLoginVM
    {
        #region Private Fields

        private ValidatablePair<string> _password;

        #endregion

        #region Public Properties

        public new ValidatablePair<string> Password
        {
            get => _password;
            set
            {
                if (_password == value)
                {
                    return;
                }
                SetProperty(ref _password, value);
            }
        }

        #endregion

        #region Constructors 

        public ResetPasswordVM(ValidatableObject<string> email) : base()
        {
            Email = email;
        }

        #endregion

        #region Commands

        private Command _resetPasswordCommand;
        public Command ResetPasswordCommand
        {
            get => _resetPasswordCommand ??= new(LoginService.ResetPasswordClicked);
        }

        private Command _openSignUpPageCommand;
        public Command OpenSignUpPageCommand
        {
            get => _openSignUpPageCommand ??= new(LoginService.OpenSignUpPageClicked);
        }

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get => _openLoginPageCommand ??= new(LoginService.OpenLoginPageClicked);
        }

        #endregion

        #region Public Methods

        public override bool AreFieldsValid()
        {
            bool isPassword = Password.Validate();
            bool isName = Name.Validate();
            return isPassword && isName;
        }

        public override void InitializeProperties()
        {
            Password = new ValidatablePair<string>();
            Name = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password" });
            Password.Validations.Add(new IsValidPasswordRule<string> { });

            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is required" });
        }

        #endregion
    }
}