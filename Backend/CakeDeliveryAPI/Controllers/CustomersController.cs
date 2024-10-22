using Business_Layer.Cake;
using Business_Layer.Customer;
using Business_Layer.Order;
using CakeDeliveryDTO.CustomerDTOs;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.Net;

namespace CakeDeliveryAPI.Controllers
{

    [Route("api/customers")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly CustomerValidator _validator = new CustomerValidator();

        // GET: api/customers/all
        [HttpGet("all", Name = "GetAllcustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllcustomers()
             => GetAllEntities(() => Customer.All());

        
        // GET: api/customers/{id}
        [HttpGet("{id:int}", Name = "GetcustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetcustomerById(int id)
              => GetEntityByIdentifier(id, key =>Customer.Find(key, Customer.enFindBy.Id), Customer => Ok(Customer));
       

      
        // GET: api/customers/search?name={name}
        [HttpGet("searchByName", Name = "GetcustomerByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetcustomerByName(string name)
         => GetEntityByIdentifier(name, key => Customer.Find(key, Customer.enFindBy.Name), customer => Ok(customer));



        // POST: api/customers
        [HttpPost(Name = "Addcustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerDTO> Addcustomer([FromBody] CustomerCreateDTO newCustomerDTO)
        {
            if (newCustomerDTO == null)
            {
                return BadRequest("Invalid customer data.");
            }

            Customer customerInstance = new Customer(
                new CustomerDTO(
                    null,
                    newCustomerDTO.FirstName,
                    newCustomerDTO.LastName,
                    string.Concat(newCustomerDTO.FirstName, " ", newCustomerDTO.LastName),
                    newCustomerDTO.Email,
                    newCustomerDTO.PhoneNumber,
                    newCustomerDTO.Address,
                    newCustomerDTO.City,
                    newCustomerDTO.PostalCode,
                    newCustomerDTO.Country
                ),
                Customer.enMode.AddNew
            );

            var validationResult = _validator.Validate(customerInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (customerInstance.Save())
            {
                var locationUrl = Url.Link("GetcustomerById", new { id = customerInstance.CustomerID });

                return Ok(locationUrl);
            }

            return BadRequest("Unable to create customer.");
        }


        // PUT: api/customers/{id}
        [HttpPut("{id}", Name = "Updatecustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> Updatecustomer(int id, CustomerDTO updatedcustomer)
        {
            if (id < 1 || updatedcustomer == null )
            {
                return BadRequest("Invalid customer data.");
            }

            CustomerDTO? existingcustomer = Customer.Find(id ,Customer.enFindBy.Id);
            if (existingcustomer == null)
            {
                return NotFound($"customer with ID {id} not found.");
            }

            Customer customerInstance = new Customer(updatedcustomer, Customer.enMode.Update);

            // Validate the customer instance
            var validationResult = _validator.Validate(customerInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (customerInstance.Save())
            {
                return Ok(customerInstance.TocustomerDto());
            }

            return StatusCode(500, new { message = "Error updating customer." });
        }


        // DELETE: api/customers/{id}
        [HttpDelete("{id}", Name = "Deletecustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Deletecustomer(int id)
             => DeleteEntity<Customer>(id, Customer.Delete, "Customer");

    }
}
