using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    /// <summary>
    /// A base class for creating validators for specific entity types.
    /// Provides common functionality for adding errors to validation results.
    /// </summary>
    /// <typeparam name="T">The type of entity being validated.</typeparam>
    public abstract class BaseValidator<T>
    {
        protected ValidationResult Result { get; private set; } = new ValidationResult();

        public abstract ValidationResult Validate(T entity);

        protected void AddError(string error)
        {
            Result.AddError(error);
        }
    }

}
