namespace CakeDeliveryDTO.CustomerDTOs
{
    public class CustomerCreateRequestDTO
    {
        public CustomerCreateRequestDTO(int? customerId, string firstName, string lastName, string email, string phoneNumber, string address, string city, string postalCode, string country, DateTime createdAt)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
            CreatedAt = createdAt;
        }

        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
