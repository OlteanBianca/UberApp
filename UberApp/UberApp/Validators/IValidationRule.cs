
namespace UberApp.Validators
{
    public interface IValidationRule<T>
    {
        #region Properties

        string ValidationMessage { get; set; }

        #endregion

        #region Methods

        bool Check(T value);

        #endregion
    }
}