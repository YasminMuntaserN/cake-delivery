namespace CakeDeliveryDTO.DeliveryDTO
{
    /// <summary>
    /// DTO Used to update an existing delivery or retrieve details of a delivery.
    /// </summary>
    /// 
    public record DeliveryUpdateFindRequestDTO(
        int DeliveryID,
        int OrderID,
        string DeliveryAddress,
        string DeliveryCity,
        string DeliveryPostalCode,
        string DeliveryCountry,
        DateTime DeliveryDate,
        string DeliveryStatus
    );

}
