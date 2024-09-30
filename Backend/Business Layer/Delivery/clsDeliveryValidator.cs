using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Customer
{
    public class clsDeliveryValidator : BaseValidator<clsCustomer>
    {
        public override ValidationResult Validate(clsCustomer customer)
        {
            if (!HasValidCustomerID(customer.CustomerID))
                AddError("CustomerID must be a positive integer.");

            if (!HasValidFirstName(customer.FirstName))
                AddError("FirstName is required.");

            if (!HasValidLastName(customer.LastName))
                AddError("LastName is required.");

            if (!HasValidEmail(customer.Email))
                AddError("Email is not valid.");

            if (!HasValidPhoneNumber(customer.PhoneNumber))
                AddError("PhoneNumber must be a valid phone number.");

            return Result;
        }

        private bool HasValidCustomerID(int? customerID) => !customerID.HasValue || customerID > 0;

        private bool HasValidFirstName(string firstName) => !string.IsNullOrWhiteSpace(firstName);

        private bool HasValidLastName(string lastName) => !string.IsNullOrWhiteSpace(lastName);

        private bool HasValidEmail(string email)
            => !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");

        private bool HasValidPhoneNumber(string phoneNumber)
            => !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit); // Basic validation for digits only

    }

}
