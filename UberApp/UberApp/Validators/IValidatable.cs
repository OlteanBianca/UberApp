using System.Collections.Generic;

namespace UberApp.Validators
{
    public interface IValidatable<T>
    {
        #region Properties

        List<IValidationRule<T>> Validations { get; }

        List<string> Errors { get; }

        bool IsValid { get; set; }

        #endregion

        #region Methods

        bool Validate();

        #endregion
    }
}
