using Business_Layer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.OrderItem
{

    public class OrderItemValidator : BaseValidator<Orders.OrderItem>
    {
        public override ValidationResult Validate(Orders.OrderItem orderItem)
        {
            if (!HasValidID(orderItem.CakeID))
                AddError("ProductID is invalid.");

            if (!HasValidID(orderItem.OrderID))
                AddError("OrderID is invalid.");

            if (!HasValidID(orderItem.Quantity))
                AddError("Quantity must be greater than zero.");

            if (HasValidPrice(orderItem.PricePerItem))
                AddError("UnitPrice must be greater than zero.");

            return Result;
        }

        private bool HasValidID(int Id) => Id > 0;

        private bool HasValidPrice(decimal Price) => Price < 0;

    }

}
