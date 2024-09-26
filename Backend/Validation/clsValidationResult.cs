using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    /// <summary>
    /// Represents the result of a validation process, holding the validity status and any error messages.
    /// </summary>
    public class clsValidationResult
    {
        public bool IsValid { get; private set; } = true;
     
        /// <summary>
        /// A list of error messages collected during validation.
        /// </summary>
        public List<string> Errors { get; } = new List<string>();


        /// <summary>
        /// Adds an error message to the validation result and marks the result as invalid.
        /// </summary>
        /// <param name="error">The error message to add.</param>
        public void AddError(string error)
        {
            IsValid = false;
            Errors.Add(error);
        }
    }
}
