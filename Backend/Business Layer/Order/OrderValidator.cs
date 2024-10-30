using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Order
{
    public class OrderValidator : BaseValidator<Order>
    {
        public override ValidationResult Validate(Order order)
        {
            if (!HasValidOrderID(order.CustomerID))
                AddError("CustomerID is invalid.");

            if (!HasValidOrderDate(order.OrderDate))
                AddError("OrderDate cannot be in the future.");

            if (!HasValidTotalAmount(order.TotalAmount))
                AddError("TotalAmount must be greater than zero.");

            if (!IsValidDeliveryStatus( order.DeliveryStatus))
                AddError("Invalid DeliveryStatus.");

            if (!IsValidPaymentStatus(order.PaymentStatus))
                AddError("Invalid PaymentStatus ");

            return Result;
        }

        private bool HasValidOrderID(int? CustomerID) => CustomerID.HasValue && CustomerID > 0;

        private bool HasValidOrderDate(DateTime orderDate) => orderDate <= DateTime.Now;

        private bool HasValidTotalAmount(decimal totalAmount) => totalAmount > 0;

        private bool IsValidDeliveryStatus( string deliveryStatus)
        {
            return !string.IsNullOrWhiteSpace(deliveryStatus) &&
             (deliveryStatus == "Cancelled" || deliveryStatus == "Delivered" || deliveryStatus == "In Transit" || deliveryStatus == "Pending");
        }

        private bool IsValidPaymentStatus(string paymentStatus)
        {
            return !string.IsNullOrWhiteSpace(paymentStatus) &&
             (paymentStatus == "Failed" || paymentStatus == "Completed" || paymentStatus == "Pending");
        }
    }
}
