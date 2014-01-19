using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PEW.Core.Interfaces
{
    public interface IValidator
    {
        IEnumerable<ValidationResult> Validate<T>(T obj) where T : class;
    }
}
