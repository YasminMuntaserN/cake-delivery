public class OrderItemDTO
{
    public OrderItemDTO(int? orderItemId, int? orderId, int? cakeId, int quantity, decimal pricePerItem)
    {
        this.OrderItemID = orderItemId;
        this.OrderID = orderId;
        this.CakeID = cakeId;
        this.Quantity = quantity;
        this.PricePerItem = pricePerItem;
    }

    public int? OrderItemID { get; set; }
    public int? OrderID { get; set; }
    public int? CakeID { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerItem { get; set; }
}

