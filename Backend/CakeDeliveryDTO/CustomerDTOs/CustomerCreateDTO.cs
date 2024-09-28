namespace CakeDeliveryDTO.CustomerDTOs
{
    /// <summary>
    /// DTO for Create a new customer.
    /// </summary>
    /// 
    public record CustomerCreateDTO(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address,
    string City,
    string PostalCode,
    string Country
);

}
