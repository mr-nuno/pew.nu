using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PEW.Core.Interfaces;

namespace PEW.Core.Validation
{
    public class Validator : IValidator
    {
        public IEnumerable<ValidationResult> Validate<T>(T obj) where T : class
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, results, true);
            return results;
        }
    }
}
