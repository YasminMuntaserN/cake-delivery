using Business_Layer.Payment;
using CakeDeliveryDTO.PaymentDTOs;
using CakeDeliveryDTO;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        private readonly clsPaymentValidator _validator = new clsPaymentValidator();

        // GET: api/payments/all
        [HttpGet("all", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PaymentDTO>> GetAllPayments()
            => GetAllEntities(() => clsPayment.All());


        // GET: api/payments/{id}
        [HttpGet("{id}", Name = "GetPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PaymentDTO> GetPaymentById(int id)
            => GetEntityByIdentifier(id, clsPayment.FindPaymentById, entity => Ok(entity));

      
        // POST: api/payments
        [HttpPost(Name = "AddPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PaymentDTO> AddPayment([FromBody] PaymentCreateDTO newPaymentDTO)
        {
            if (newPaymentDTO == null || newPaymentDTO.OrderID < 1)
            {
                return BadRequest("Invalid payment data.");
            }

            clsPayment paymentInstance = new clsPayment(
                new PaymentDTO(null, newPaymentDTO.OrderID, newPaymentDTO.PaymentMethod, DateTime.Now, newPaymentDTO.AmountPaid, newPaymentDTO.PaymentStatus),
                clsPayment.enMode.AddNew
            );

            // Validate the payment instance
            var validationResult = _validator.Validate(paymentInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (paymentInstance.Save())
            {
                return CreatedAtRoute("GetPaymentById", new { id = paymentInstance.PaymentID }, newPaymentDTO);
            }
            return BadRequest("Unable to create payment.");
        }

       
        // PUT: api/payments/{id}
        [HttpPut("{id}", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PaymentDTO> UpdatePayment(int id, PaymentDTO updatedPayment)
        {
            if (id < 1 || updatedPayment == null || updatedPayment.PaymentID < 1)
            {
                return BadRequest("Invalid payment data.");
            }

            PaymentDTO? existingPayment = clsPayment.FindPaymentById(id);
            if (existingPayment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            clsPayment paymentInstance = new clsPayment(updatedPayment, clsPayment.enMode.Update);

            // Validate the payment instance
            var validationResult = _validator.Validate(paymentInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (paymentInstance.Save())
            {
                return Ok(paymentInstance.ToPaymentDto());
            }

            return StatusCode(500, new { message = "Error updating payment." });
        }

      
        // DELETE: api/payments/{id}
        [HttpDelete("{id}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePayment(int id)
            => DeleteEntity<clsPayment>(id, clsPayment.Delete, "Payment");

     
        // GET: api/payments/order/{orderId}
        [HttpGet("order/{orderId}", Name = "GetPaymentsByOrderId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PaymentDTO>> GetPaymentsByOrderID(int orderId)
        => GetAllEntitiesBy<clsPayment, PaymentDTO, int>(
                orderId, clsPayment.FindPaymentByOrderId,"Payment" );
    }

}
