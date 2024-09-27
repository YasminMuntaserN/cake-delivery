﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Order
{
    public class clsCustomerValidator : BaseValidator<clsCustomer>
    {
        public override ValidationResult Validate(clsCustomer order)
        {
            if (!HasValidCustomerID(order.CustomerID))
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

        private bool HasValidCustomerID(int? customerID) => customerID.HasValue && customerID > 0;

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