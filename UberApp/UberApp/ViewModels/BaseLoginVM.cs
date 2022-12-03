using UberApp.Services;
using UberApp.Validators;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public abstract class BaseLoginVM : BaseVM
    {
        #region Private Fields

        private ValidatableObject<string> _email;
        private ValidatableObject<string> _name;
        private ValidatableObject<string> _password;

        private readonly LoginService _loginService;

        #endregion

        #region Public Properties

        public ValidatableObject<string> Email
        {
            get => _email;
            set
            {
                if (_email == value)
                {
                    return;
                }
                SetProperty(ref _email, value);
            }
        }

        public ValidatableObject<string> Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }
                SetProperty(ref _name, value);
            }
        }

        public ValidatableObject<string> Password
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

        public LoginService LoginService => _loginService;

        #endregion

        #region Constructors

        public BaseLoginVM()
        {
            InitializeProperties();
            AddValidationRules();
            _loginService = new(this);
        }

        #endregion

        #region Public Methods

        public abstract bool AreFieldsValid();

        public abstract void InitializeProperties();

        public abstract void AddValidationRules();

        #endregion

        #region Commands

        private Command _closeApplicationCommand;
        public Command CloseApplicationCommand
        {
            get
            {
                _closeApplicationCommand ??= new(LoginService.CloseApplicationClicked);
                return _closeApplicationCommand;
            }
        }

        #endregion
    }
}
