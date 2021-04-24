using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FlexTesting.Core.Contract.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateAndThrow(object o)
        {
            var context = new ValidationContext(o);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(o, context, results, true))
            {
                return;
            }
            
            var errors = results
                .Select(result => result.ErrorMessage);
            throw new ValidationException(string.Join(", ",errors));
        }
    }
}