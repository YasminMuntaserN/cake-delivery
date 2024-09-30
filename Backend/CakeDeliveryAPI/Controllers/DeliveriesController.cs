using Business_Layer.Cake;
using Business_Layer.Delivery;
using Business_Layer.Order;
using CakeDeliveryDTO.DeliveryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/deliveries")]
    [ApiController]
    public class DeliveriesController : BaseController
    {
        private readonly clsDeliveryValidator _validator = new clsDeliveryValidator();

        // GET: api/deliveries/all
        [HttpGet("All", Name = "GetAllDeliveries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DeliveryDTO>> GetAllDeliveries()
            => GetAllEntities(() => clsDelivery.All());

        // GET: api/deliveries/{id}
        [HttpGet("{id}", Name = "GetDeliveryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeliveryDTO> GetDeliveryById(int id)
            => GetEntityByIdentifier(id, clsDelivery.FindDeliveryById, delivery => Ok(delivery));

        // POST: api/deliveries
        [HttpPost(Name = "AddDelivery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DeliveryDTO> AddDelivery([FromBody] DeliveryCreateDTO newDeliveryDTO)
        {
            if (newDeliveryDTO == null || string.IsNullOrEmpty(newDeliveryDTO.DeliveryAddress))
            {
                return BadRequest("Invalid delivery data.");
            }

            clsDelivery deliveryInstance = new clsDelivery(
                new DeliveryDTO(null, newDeliveryDTO.OrderID, newDeliveryDTO.DeliveryAddress, newDeliveryDTO.DeliveryCity, newDeliveryDTO.DeliveryPostalCode, newDeliveryDTO.DeliveryCountry, newDeliveryDTO.DeliveryDate,  newDeliveryDTO.DeliveryStatus),
                clsDelivery.enMode.AddNew
            );

            var validationResult = _validator.Validate(deliveryInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (deliveryInstance.Save())
            {
                return CreatedAtRoute("GetDeliveryById", new { id = deliveryInstance.DeliveryID }, newDeliveryDTO);
            }

            return BadRequest("Unable to create delivery.");
        }

      
        // PUT: api/deliveries/{id}
        [HttpPut("{id}", Name = "UpdateDelivery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeliveryDTO> UpdateDelivery(int id, DeliveryDTO updatedDelivery)
        {
            if (id < 1 || updatedDelivery == null || string.IsNullOrEmpty(updatedDelivery.DeliveryAddress))
            {
                return BadRequest("Invalid delivery data.");
            }

            DeliveryDTO? existingDelivery = clsDelivery.FindDeliveryById(id);
            if (existingDelivery == null)
            {
                return NotFound($"Delivery with ID {id} not found.");
            }

            clsDelivery deliveryInstance = new clsDelivery(updatedDelivery, clsDelivery.enMode.Update);

            var validationResult = _validator.Validate(deliveryInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (deliveryInstance.Save())
            {
                return Ok(deliveryInstance.ToDeliveryDto());
            }

            return StatusCode(500, new { message = "Error updating delivery." });
        }

       
        
        // DELETE: api/deliveries/{id}
        [HttpDelete("{id}", Name = "DeleteDelivery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteDelivery(int id)
            => DeleteEntity<clsOrder>(id, clsDelivery.Delete, "Delivery");

    }
}