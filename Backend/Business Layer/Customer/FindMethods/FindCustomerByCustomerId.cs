using CakeDeliveryDTO.CustomerDTOs;
using DataAccessLayer;

namespace Business_Layer.Customer.FindMethods
{
    internal class FindCustomerByCustomerId : IFind<CustomerDTO?>
    {
        public CustomerDTO? Find(object? data)
        {
            if (data is int id)
            {
                return clsCustomerData.GetCustomerById(id);
            }

            return null;
        }
    }
}
