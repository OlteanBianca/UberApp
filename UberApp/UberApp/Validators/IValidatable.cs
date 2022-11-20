using System.Collections.Generic;

namespace UberApp.Validators
{
    public interface IValidatable<T>
    {
        #region Property

        List<IValidationRule<T>> Validations { get; }

        List<string> Errors { get; }

        bool IsValid { get; set; }

        #endregion

        #region Method

        bool Validate();

        #endregion
    }
}
