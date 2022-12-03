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

        public ResetPasswordVM()
        {
            InitializeProperties();
            AddValidationRules();
        }

        #endregion

        #region Commands

        private Command _resetPasswordCommand;
        public Command ResetPasswordCommand
        {
            get
            {
                _resetPasswordCommand ??= new(LoginService.ResetPasswordClicked);
                return _resetPasswordCommand;
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
            bool isPassword = Password.Validate();
            return isPassword;
        }

        public override void InitializeProperties()
        {
            Password = new ValidatablePair<string>();
        }

        public override void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password" });
        }

        #endregion
    }
}