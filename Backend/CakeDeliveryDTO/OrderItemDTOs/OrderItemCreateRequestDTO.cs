namespace DTOs
{
    /// <summary>
    /// Used when creating a new order item
    /// </summary>
    /// 
    public record OrderItemCreateRequestDTO(
    int OrderID,
    int CakeID,
    int Quantity,
    decimal PricePerItem
);
}

