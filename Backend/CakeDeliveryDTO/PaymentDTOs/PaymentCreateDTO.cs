namespace CakeDeliveryDTO.PaymentDTOs
{
    /// <summary>Used when creating a new payment.Used to delete a delivery
    /// </summary>
    /// 
    public record PaymentCreateDTO(
    int? OrderID,
    string PaymentMethod,
    decimal AmountPaid,
    string PaymentStatus
);
}
