namespace CakeDeliveryDTO.DeliveryDTO
{
    /// <summary>
    /// DTO Used when updating an existing payment orUsed to retrieve details of a payment. 
    /// </summary>
    /// 
    public record PaymentUpdateFindDTO(
        int PaymentID,
        int OrderID,
        string PaymentMethod,
        DateTime PaymentDate,
        decimal AmountPaid,
        string PaymentStatus
    );
}
