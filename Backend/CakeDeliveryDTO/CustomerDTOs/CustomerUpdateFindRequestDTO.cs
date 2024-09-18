namespace CakeDeliveryDTO.CustomerDTOs
{
    /// <summary>
    /// DTO for Update or Find a customer.
    /// </summary>
    /// 
    public record CustomerUpdateFindRequestDTO(
        int CustomerID,
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
