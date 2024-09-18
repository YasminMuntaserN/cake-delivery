namespace DTOs
{
    /// <summary>
    /// DTO Used when updating an existing order item or retrieving details of an order item
    /// </summary>
    /// 
    public record OrderItemUpdateFindRequestDTO(
        int OrderItemID,
        int OrderID,
        int CakeID,
        int Quantity,
        decimal PricePerItem
    );
}

