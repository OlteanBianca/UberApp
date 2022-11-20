using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : BaseLoginViewModel
    {
        #region Fields

        private ValidatablePair<string> _password;

        #endregion

        #region Property

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

        public SignUpPageViewModel() : base()
        {
            InitializeProperties();
            AddValidationRules();
        }
        #endregion

        #region Commands

        private Command _signUpCommand;
        public Command SignUpCommand
        {
            get
            {
                _signUpCommand ??= new(LoginService.SignUpClicked);
                return _signUpCommand;
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

        #region Methods

        public bool AreFieldsValid()
        {
            bool isEmail = Email.Validate();
            bool isNameValid = Name.Validate();
            bool isPasswordValid = Password.Validate();
            return isPasswordValid && isNameValid && isEmail;
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