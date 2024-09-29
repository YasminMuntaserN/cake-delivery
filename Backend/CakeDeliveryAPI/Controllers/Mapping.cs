using Business_Layer.Order;
using DTOs;

namespace CakeDeliveryAPI.Controllers
{
    public class Mapping
    {
        public static OrderDTO ConvertToDto(clsOrder entity)
        {
            return new OrderDTO(
                // Map properties from entity to DTO
                OrderID: null,
                CustomerID: entity.CustomerID,
                OrderDate: entity.OrderDate,
                TotalAmount: entity.TotalAmount,
                PaymentStatus: entity.PaymentStatus,
                DeliveryStatus: entity.DeliveryStatus
            );
        }

    }
}
