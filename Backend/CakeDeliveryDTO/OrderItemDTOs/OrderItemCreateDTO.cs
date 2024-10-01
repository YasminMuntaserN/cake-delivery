namespace DTOs
{
    /// <summary>
    /// Used when creating a new order item
    /// </summary>
    /// 
    public record OrderItemCreateDTO(
    int OrderID,
    int CakeID,
    int Quantity,
    int size,
    decimal PricePerItem
);
}

