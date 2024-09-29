using Business_Layer.Cake;
using Business_Layer.Customer;
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
    public class CustomersController : ControllerBase
    {
        private readonly clsCustomerValidator _validator = new clsCustomerValidator();

        // GET: api/customers/all
        [HttpGet("all", Name = "GetAllcustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllcustomers()
        {
            List<CustomerDTO> customersList = clsCustomer.All();
            if (!customersList.Any())
            {
                Console.WriteLine("the problem here in contoller");
                return NotFound("No customers Found!");
            }
            return Ok(customersList);
        }

        
        // GET: api/customers/{id}
        [HttpGet("{id:int}", Name = "GetcustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetcustomerById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            CustomerDTO? customer = clsCustomer.FindCustomerById(id);
            if (customer == null)
            {
                return NotFound($"customer with ID {id} not found.");
            }

            return Ok(customer);
        }

      
        // GET: api/customers/search?name={name}
        [HttpGet("search", Name = "GetcustomerByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetcustomerByName( string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            CustomerDTO? customer = clsCustomer.FindCustomerByName(name);
            if (customer == null)
            {
                return NotFound($"Customer with Name '{name}' not found.");
            }

            return Ok(customer);
        }


      
        // POST: api/customers
        [HttpPost(Name = "Addcustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerDTO> Addcustomer([FromBody] CustomerCreateDTO newCustomerDTO)
        {
            if (newCustomerDTO == null)
            {
                return BadRequest("Invalid customer data.");
            }
            clsCustomer customerInstance = new clsCustomer(
                new CustomerDTO(null, newCustomerDTO.FirstName, newCustomerDTO.LastName,string.Concat(newCustomerDTO.FirstName, " ", newCustomerDTO.LastName)
                , newCustomerDTO.Email, newCustomerDTO.PhoneNumber, newCustomerDTO.Address, newCustomerDTO.City, newCustomerDTO.PostalCode, newCustomerDTO.Country),
            clsCustomer.enMode.AddNew
            );

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
                return CreatedAtRoute("GetcustomerById", new { id = customerInstance.CustomerID }, newCustomerDTO);
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

            CustomerDTO? existingcustomer = clsCustomer.FindCustomerById(id);
            if (existingcustomer == null)
            {
                return NotFound($"customer with ID {id} not found.");
            }

            clsCustomer customerInstance = new clsCustomer(updatedcustomer, clsCustomer.enMode.Update);

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
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (clsCustomer.Delete(id))
            {
                return Ok($"customer with ID {id} has been deleted.");
            }

            return NotFound($"customer with ID {id} not found. No rows deleted!");
        }



    }
}
