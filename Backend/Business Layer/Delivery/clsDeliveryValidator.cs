using Business_Layer.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Customer
{
    public class clsDeliveryValidator : BaseValidator<clsDelivery>
    {
        public override ValidationResult Validate(clsDelivery delivery)
        {
            if (!HasValidOrderID(delivery.OrderID))
                AddError("OrderID is invalid.");

            if (!HasValidDelivery(delivery.DeliveryAddress))
                AddError("DeliveryAddress is invalid.");

            if (!HasValidDelivery(delivery.DeliveryCity))
                AddError("DeliveryCity is invalid.");

            if (!HasValidDelivery(delivery.DeliveryPostalCode))
                AddError("DeliveryPostalCode is invalid.");

            if (!HasValidDelivery(delivery.DeliveryCountry))
                AddError("DeliveryCountry is invalid.");

            if (!HasValidDeliveryDate(delivery.DeliveryDate))
                AddError("DeliveryDate cannot be in the future.");

            if (!IsValidDeliveryStatus(delivery.DeliveryStatus))
                AddError("Invalid DeliveryStatus.");

            return Result;
        }

        private bool HasValidOrderID(int? orderID) => orderID.HasValue && orderID > 0;

        private bool HasValidDelivery(string value)
            => !string.IsNullOrWhiteSpace(value) ;

        private bool HasValidDeliveryDate(DateTime deliveryDate)
            => deliveryDate <= DateTime.Now;

        private bool IsValidDeliveryStatus(string deliveryStatus)
        {
            return !string.IsNullOrWhiteSpace(deliveryStatus) &&
                   (deliveryStatus == "Scheduled" ||
                    deliveryStatus == "In Transit" ||
                    deliveryStatus == "Delivered" ||
                    deliveryStatus == "Cancelled");
        }
    }


}
