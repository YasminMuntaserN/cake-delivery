namespace CakeDeliveryDTO.CustomerDTOs
{
    /// <summary>
    /// DTO  Used when updating an existing customer's details or retrieving customer details.
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
