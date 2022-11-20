using UberApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ForgotPasswordViewModel : BaseLoginViewModel
    {
        #region Constructor

        public ForgotPasswordViewModel() : base()
        {
        }

        #endregion

        #region Commands

        private Command _forgotPasswordCommand;
        public Command ForgotPasswordCommand
        {
            get
            {
                _forgotPasswordCommand ??= new(LoginService.ForgotPasswordClicked);
                return _forgotPasswordCommand;
            }
        }

        #endregion
    }
}