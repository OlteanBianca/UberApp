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

        private bool _isPasswordVisible;
        private bool _isDriver;
        private ValidatablePair<string> _password;
        private ValidatableObject<string> _licensePlate;
        private ValidatableObject<string> _carModel;

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

        public ValidatableObject<string> LicensePlate
        {
            get => _licensePlate;
            set
            {
                if (_licensePlate == value)
                {
                    return;
                }
                SetProperty(ref _licensePlate, value);
            }
        }

        public ValidatableObject<string> CarModel
        {
            get => _carModel;
            set
            {
                if (_carModel == value)
                {
                    return;
                }
                SetProperty(ref _carModel, value);
            }
        }

        public bool IsDriver
        {
            get => _isDriver;
            set
            {
                _isDriver = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public SignUpVM() : base()
        {
            IsDriver = false;
        }

        #endregion

        #region Commands

        private Command _signUpCommand;
        public Command SignUpCommand
        {
            get => _signUpCommand ??= new(LoginService.SignUpClicked);
        }

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get => _openLoginPageCommand ??= new(LoginService.OpenLoginPageClicked);
        }

        #endregion

        #region Private Methods

        private bool AreFieldsValidForClient()
        {
            bool isEmail = Email.Validate();
            bool isNameValid = Name.Validate();

            return isNameValid && isEmail;
        }

        private bool AreFieldsValidForDriver()
        {
            bool isPasswordValid = Password.Validate();
            bool isLicensePlateValid = LicensePlate.Validate();
            bool isCarModelValid = CarModel.Validate();
            return isPasswordValid && isCarModelValid && isLicensePlateValid && AreFieldsValidForClient();
        }

        #endregion

        #region Public Methods

        public override bool AreFieldsValid()
        {
            if (IsDriver)
            {
                return AreFieldsValidForDriver();
            }
            return AreFieldsValidForClient();
        }

        public override void InitializeProperties()
        {
            Password = new ValidatablePair<string>();
            Name = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
            LicensePlate = new ValidatableObject<string>();
            CarModel = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is Required!" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password!" });
            Password.Validations.Add(new IsValidPasswordRule<string> { });

            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is required!" });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required!" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email is invalid!" });

            CarModel.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Car model is required!" });
            LicensePlate.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "License plate is required!" });
        }

        #endregion
    }
}