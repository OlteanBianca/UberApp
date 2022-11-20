namespace UberApp.Validators
{
    public interface IValidationRule<T>
    {
        #region Property

        string ValidationMessage { get; set; }

        #endregion

        #region Method

        bool Check(T value);

        #endregion
    }
}