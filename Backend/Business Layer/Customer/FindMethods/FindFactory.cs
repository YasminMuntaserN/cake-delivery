using CakeDeliveryDTO.CustomerDTOs;

namespace Business_Layer.Customer.FindMethods
{
    internal static class FindFactory
    {
        public static IFind<CustomerDTO?>? GetFinder(clsCustomer.enFindBy findBy)
        {
            return findBy switch
            {
                clsCustomer.enFindBy.CustomerID => new FindCustomerByCustomerId(),
                clsCustomer.enFindBy.Name => new FindCustomerByCustomerName(),
                _ => null,
            };
        }
    }
}
