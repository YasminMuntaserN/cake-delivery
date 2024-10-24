using DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Orders
{
    public class OrderItem
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int CakeID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

       
        public OrderItem(OrderItemDTO orderItemDto, enMode mode = enMode.AddNew)
        {
            OrderItemID = orderItemDto.OrderItemID;
            OrderID = orderItemDto.OrderID;
            CakeID = orderItemDto.CakeID;
            SizeID = orderItemDto.SizeID;
            Quantity = orderItemDto.Quantity;
            PricePerItem = orderItemDto.PricePerItem;

            Mode = mode;
        }

      
        public OrderItemDTO ToOrderItemDto() =>
            new OrderItemDTO(OrderItemID, OrderID, CakeID, SizeID, Quantity, PricePerItem);
      
        private bool _Add()
        {
            OrderItemID = clsOrderItemData.Add(new OrderItemCreateDTO(OrderID, CakeID,  Quantity, SizeID, PricePerItem));
            return OrderItemID.HasValue;
        }

        private bool _Update()
            => clsOrderItemData.UpdateOrderItem(ToOrderItemDto());

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        Console.WriteLine("the error not in save function");
                        return true;
                    }
                    Console.WriteLine("the error in save function");
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
      
        public static OrderItemDTO? FindOrderItemById(int orderItemId)
            => clsOrderItemData.GetOrderItemById(orderItemId);
       
        public static bool Delete(int orderItemId)
            => clsOrderItemData.DeleteOrderItem(orderItemId);

      
        public static List<OrderItemDTO> AllByCakeID(int cakeId)
            => clsOrderItemData.GetOrderItemsByCakeId(cakeId);

        public static List<OrderItemDTO> AllByOrderID(int orderId)
            => clsOrderItemData.GetOrderItemsByOrderId(orderId);

        public static List<OrderItemDTO> AllOrderItems()
            => clsOrderItemData.GetAllOrderItems();



    }
}

