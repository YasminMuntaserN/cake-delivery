namespace CakeDeliveryDTO.DeliveryDTO
{
    /// <summary>
    /// DTO Used to create a new delivery
    /// </summary>
    /// 
    public record DeliveryCreateRequestDTO(
     int OrderID,
     string DeliveryAddress,
     string DeliveryCity,
     string DeliveryPostalCode,
     string DeliveryCountry,
     DateTime DeliveryDate,
     string DeliveryStatus
 );
}
