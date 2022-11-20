using System;
using System.Collections.Generic;
using System.Text;

namespace UberApp.Validators.Rules
{
    public class IsValidUsernameRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            string username = value.ToString();

            //if (username)
            return true;
        }
    }
}
