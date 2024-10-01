namespace DTOs
{
    /// <summary>
    /// DTO Used when updating an existing order item or retrieving details of an order item
    /// </summary>
    /// 
    public record OrderItemDTO(
        int? OrderItemID,
        int OrderID,
        int CakeID,
        int SizeID,
        int Quantity,
        decimal PricePerItem
    );
}

