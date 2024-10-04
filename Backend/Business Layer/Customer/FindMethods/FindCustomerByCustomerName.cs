using CakeDeliveryDTO.CustomerDTOs;
using DataAccessLayer;

namespace Business_Layer.Customer.FindMethods
{
    internal class FindCustomerByCustomerName : IFind<CustomerDTO?>
    {
        public CustomerDTO? Find(object? data)
        {
            if (data is string name)
            {
                return clsCustomerData.GetCustomerByName(name);
            }

            return null;
        }
    }
}
