using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public abstract class clsBaseValidator<T>
    {
        protected clsValidationResult Result { get; private set; } = new clsValidationResult();

        public abstract ValidationResult Validate(T entity);

        protected void AddError(string error)
        {
            Result.AddError(error);
        }
    }

}
