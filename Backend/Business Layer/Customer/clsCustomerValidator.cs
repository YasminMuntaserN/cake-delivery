using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Customer
{
    public class clsCustomerValidator : BaseValidator<clsCustomer>
    {
        public override ValidationResult Validate(clsCustomer customer)
        {


            return Result;
        }

    }
}
