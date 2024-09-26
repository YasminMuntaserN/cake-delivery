using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class clsValidationResult
    {
        public bool IsValid { get; private set; } = true;
        public List<string> Errors { get; } = new List<string>();

        public void AddError(string error)
        {
            IsValid = false;
            Errors.Add(error);
        }
    }
}
