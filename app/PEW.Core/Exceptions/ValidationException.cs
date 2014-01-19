using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PEW.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, IEnumerable<ValidationResult> results) : base(message)
        {
            ValidationResults = results;
        }

        public ValidationException(string message, IEnumerable<ValidationResult> results, Exception innerException) : base(message, innerException)
        {
            ValidationResults = results;
        }

        public IEnumerable<ValidationResult> ValidationResults { get; private set; }
    }
}
