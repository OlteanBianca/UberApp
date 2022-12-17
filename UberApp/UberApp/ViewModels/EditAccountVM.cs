using UberApp.Models;
using UberApp.Services;
using UberApp.Validators;
using UberApp.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class EditAccountVM : BaseLoginVM
    {
        #region Private Fields

        private bool _isDriver;
        private Client _client;
        private Driver _driver;
        private ValidatablePair<string> _password;
        private ValidatableObject<string> _licensePlate;
        private ValidatableObject<string> _carModel;
        private readonly EditAccountPageService _editAccountPageService;

        #endregion

        #region Public Properties

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
                _carModel = value;
                SetProperty(ref _carModel, value);
            }
        }

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

        public bool IsDriver
        {
            get => _isDriver;
            set
            {
                _isDriver = value;
                OnPropertyChanged();
            }
        }

        public Client Client { get => _client; }

        public Driver Driver { get => _driver; }

        #endregion

        #region Private Methods

        private void Initialization(object value)
        {
            switch (value)
            {
                case Models.Client:
                    {
                        _client = (Client)value;
                        IsDriver = false;
                        Password.Item1.Value = _client.Password;
                        Password.Item2.Value = _client.Password;
                        Name.Value = _client.Name;
                        Email.Value = _client.Email;
                        return;
                    }
                case Models.Driver:
                    {
                        _driver = (Driver)value;
                        IsDriver = true;
                        Password.Item1.Value = _driver.Password;
                        Password.Item2.Value = _driver.Password;
                        Name.Value = _driver.Name;
                        LicensePlate.Value = _driver.LicensePlate;
                        CarModel.Value = _driver.CarModel;
                        Email.Value = _driver.Email;
                        break;
                    }
            }
        }

        private bool AreFieldsValidForClient()
        {
            bool isNameValid = true;
            bool isPasswordValid = true;

            if (Name.Value != _client.Name)
            {
                isNameValid = Name.Validate();
            }

            if (Password.Item1.Value != Password.Item2.Value || Password.Item1.Value != _client.Password)
            { 
                isPasswordValid= Password.Validate();
            }
            return isNameValid && isPasswordValid;
        }

        private bool AreFieldsValidForDriver()
        {
            bool isNameValid = true;
            bool isPasswordValid = true;
            bool isLicensePlateValid = true;
            bool isCarModelValid = true;

            if (Name.Value != _driver.Name)
            {
                isNameValid = Name.Validate();
            }

            if (Password.Item1 != Password.Item2 || Password.Item1.Value != _driver.Password)
            {
                isPasswordValid = Password.Validate();
            }

            if (LicensePlate.Value != _driver.LicensePlate)
            {
                isLicensePlateValid = LicensePlate.Validate();
            }

            if (CarModel.Value != _driver.CarModel)
            {
                isCarModelValid = CarModel.Validate();
            }

            return isCarModelValid && isLicensePlateValid && isPasswordValid && isNameValid;
        }

        #endregion

        #region Constructors

        public EditAccountVM(object value) : base()
        {
            Initialization(value);
            _editAccountPageService = new(this);
        }

        #endregion

        #region Commands

        private Command _backButtonCommand;
        public Command BackButtonCommand
        {
            get => _backButtonCommand ??= new(_editAccountPageService.BackButtonClicked);
        }

        private Command _saveSettingsCommand;
        public Command SaveSettingsCommand
        {
            get => _saveSettingsCommand ??= new(_editAccountPageService.SaveSettingsClicked);
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
            Email = new ValidatableObject<string>();
            Password = new ValidatablePair<string>();
            Name = new ValidatableObject<string>();
            LicensePlate = new ValidatableObject<string>();
            CarModel = new ValidatableObject<string>();
        }

        public override void AddValidationRules()
        {
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password" });
            Password.Validations.Add(new IsValidPasswordRule<string> { });
            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is required" });

            CarModel.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Car model is required!" });
            LicensePlate.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "License plate is required!" });
        }

        #endregion
    }
}