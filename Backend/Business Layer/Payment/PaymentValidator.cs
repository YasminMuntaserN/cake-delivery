using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Payment
{
    public class PaymentValidator : BaseValidator<Payment>
    {
        public override ValidationResult Validate(Payment payment)
        {
            if (!HasValidPaymentID(payment.OrderID))
                AddError("OrderID is invalid.");

            if (!HasValidPaymentMethod(payment.PaymentMethod))
                AddError("PaymentMethod is invalid.");

            if (!HasValidPaymentDate(payment.PaymentDate))
                AddError("PaymentDate cannot be in the future.");

            if (!HasValidAmountPaid(payment.AmountPaid))
                AddError("AmountPaid must be greater than zero.");

            if (!IsValidPaymentStatus(payment.PaymentStatus))
                AddError("Invalid PaymentStatus.");

            return Result;
        }

        private bool HasValidPaymentID(int? orderID) => orderID > 0;

        private bool HasValidPaymentMethod(string paymentMethod)
        {
            return !string.IsNullOrWhiteSpace(paymentMethod) &&
                   (paymentMethod == "Credit Card" || paymentMethod == "PayPal" || paymentMethod == "Bank Transfer");
        }

        private bool HasValidPaymentDate(DateTime paymentDate) => paymentDate <= DateTime.Now;

        private bool HasValidAmountPaid(decimal amountPaid) => amountPaid > 0;

        private bool IsValidPaymentStatus(string paymentStatus)
        {
            return !string.IsNullOrWhiteSpace(paymentStatus) &&
                   (paymentStatus == "Failed" || paymentStatus == "Completed" || paymentStatus == "Pending");
        }
    }

}
