using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class SignUpVM : BaseLoginVM
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

        public SignUpVM() : base()
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

        #region Public Methods

        public override bool AreFieldsValid()
        {
            bool isEmail = Email.Validate();
            bool isNameValid = Name.Validate();
            bool isPasswordValid = Password.Validate();
            return isPasswordValid && isNameValid && isEmail;
        }

        public override void InitializeProperties()
        {
            Password = new ValidatablePair<string>();
            Name = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required!" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password!" });
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email required!" });
            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name required!" });
            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is already used!" });
            Password.Validations.Add(new IsValidPasswordRule<string> { });
        }

        #endregion
    }
}