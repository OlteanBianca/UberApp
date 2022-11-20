using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ResetPasswordViewModel : BaseLoginViewModel
    {
        #region Fields

        private ValidatablePair<string> _password;

        #endregion

        #region Public property

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

        #region Constructor 

        public ResetPasswordViewModel()
        {
            InitializeProperties();
            AddValidationRules();
        }

        #endregion

        #region Command

        private Command _resetPasswordCommand;
        public Command ResetPasswordCommand
        {
            get
            {
                _resetPasswordCommand ??= new(LoginService.ResetPasswordClicked);
                return _resetPasswordCommand;
            }
        }

        #endregion

        #region Methods

        public bool AreFieldsValid()
        {
            bool isPassword = this.Password.Validate();
            return isPassword;
        }

        private new void InitializeProperties()
        {
            Password = new ValidatablePair<string>();
        }
        private new void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password" });
        }

        #endregion
    }
}