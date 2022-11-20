using UberApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : BaseLoginViewModel
    {
        #region Constructor

        public LoginPageViewModel() : base()
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

        #endregion

        #region methods

        public bool AreFieldsValid()
        {
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            return isEmailValid && isPasswordValid;
        }

        #endregion
    }
}