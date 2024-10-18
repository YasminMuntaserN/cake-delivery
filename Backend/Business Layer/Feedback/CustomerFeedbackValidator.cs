using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Feedback
{
    public class CustomerFeedbackValidator : BaseValidator<CustomerFeedback>
    {
        public override ValidationResult Validate(CustomerFeedback feedback)
        {
            if (!HasValidCustomerID(feedback.CustomerID))
                AddError("CustomerID is invalid.");

            if (!HasValidFeedback(feedback.Feedback))
                AddError("Feedback cannot be empty.");

            if (!HasValidFeedbackDate(feedback.FeedbackDate))
                AddError("FeedbackDate cannot be in the future.");

            return Result;
        }

        private bool HasValidCustomerID(int customerId) => customerId > 0;

        private bool HasValidFeedback(string feedback)
        {
            return !string.IsNullOrWhiteSpace(feedback);
        }

        private bool HasValidFeedbackDate(DateTime feedbackDate) => feedbackDate <= DateTime.Now;
    }
}

