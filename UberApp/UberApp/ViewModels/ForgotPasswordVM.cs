using UberApp.Services;
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