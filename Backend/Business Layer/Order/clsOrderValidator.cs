using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Order
{
    public class clsOrderValidator : BaseValidator<clsOrder>
    {
        public override ValidationResult Validate(clsOrder order)
        {
            if (!HasValidCustomerID(order.CustomerID))
                AddError("CustomerID is invalid.");

            if (!HasValidOrderDate(order.OrderDate))
                AddError("OrderDate cannot be in the future.");

            if (!HasValidTotalAmount(order.TotalAmount))
                AddError("TotalAmount must be greater than zero.");

            if (!IsValidStatus(order.PaymentStatus, order.DeliveryStatus))
                AddError("Invalid PaymentStatus or DeliveryStatus.");

            return Result;
        }

        private bool HasValidCustomerID(int? customerID) => customerID.HasValue && customerID > 0;

        private bool HasValidOrderDate(DateTime orderDate) => orderDate <= DateTime.Now;

        private bool HasValidTotalAmount(decimal totalAmount) => totalAmount > 0;

        private bool IsValidStatus(string paymentStatus, string deliveryStatus)
        {
            return !string.IsNullOrWhiteSpace(paymentStatus) &&
                   (deliveryStatus == "Pending" || deliveryStatus == "Delivered");
        }
    }
}
