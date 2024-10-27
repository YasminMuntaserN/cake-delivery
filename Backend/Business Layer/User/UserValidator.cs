using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.User
{
    public class UserValidator : BaseValidator<Users>
    {
        public override ValidationResult Validate(Users user)
        {
            if (!HasValidEmail(user.Email))
                AddError("Email is not valid.");


            if (!HasValidPassword(user.Password))
                AddError("Password must be bigger than 8.");

            return Result;
        }

        private bool HasValidPassword(string Password) => !string.IsNullOrWhiteSpace(Password) && Password.Length >= 8;

        private bool HasValidEmail(string email)
            => !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");

    }

}
