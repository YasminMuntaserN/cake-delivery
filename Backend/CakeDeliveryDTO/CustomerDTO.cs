namespace DTOs
{
    public class CustomerDTO
    {
        public CustomerDTO(int customerId, string firstName, string lastName, string email, string phoneNumber, string address, string city, string postalCode, string country, DateTime createdAt)
        {
            this.CustomerID = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.City = city;
            this.PostalCode = postalCode;
            this.Country = country;
            this.CreatedAt = createdAt;
        }

        public int CustomerID { get; set; }
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
