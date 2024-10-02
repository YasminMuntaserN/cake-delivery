using DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Orders
{
    public class clsOrderItem
    {
        public enum enFindBy
        {
            OrderItemID,
            OrderID,
            CakeID
        };

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int CakeID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

       
        public clsOrderItem(OrderItemDTO orderItemDto, enMode mode = enMode.AddNew)
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
            OrderItemID = clsOrderItemData.Add(new OrderItemCreateDTO(OrderID, CakeID, SizeID, Quantity, PricePerItem));
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
                        return true;
                    }
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

        public static bool Exists<T>(T data, enFindBy findBy)
        {
            switch (findBy)
            {
                case enFindBy.OrderItemID:
                    if (data is int orderItemId)
                    {
                        var orderItem = clsOrderItemData.GetOrderItemById(orderItemId);
                        return orderItem != null;
                    }
                    break;

                case enFindBy.OrderID:
                    if (data is int orderId)
                    {
                        var orderItems = clsOrderItemData.GetOrderItemsByOrderId(orderId);
                        return orderItems.Count > 0;
                    }
                    break;

                case enFindBy.CakeID:
                    if (data is int cakeId)
                    {
                        var orderItems = clsOrderItemData.GetOrderItemsByCakeId(cakeId);
                        return orderItems.Count > 0;
                    }
                    break;
            }

            return false;
        }

        public static List<OrderItemDTO> AllByCakeID(int cakeId)
            => clsOrderItemData.GetOrderItemsByCakeId(cakeId);

        public static List<OrderItemDTO> AllByOrderID(int orderId)
            => clsOrderItemData.GetOrderItemsByOrderId(orderId);

        public static List<OrderItemDTO> AllOrderItems()
            => clsOrderItemData.GetAllOrderItems();



    }
}

