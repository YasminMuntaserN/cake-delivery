using Business_Layer;
using Business_Layer.Cake;
using Business_Layer.Order;
using CakeDeliveryDTO.CakeDTOs;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly clsOrderValidator _validator = new clsOrderValidator();


        // GET: api/orders/all
        [HttpGet("all", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDTO>> GetAllOrders()
            => GetAllEntities(() => clsOrder.All());


        // GET: api/orders/{id}
        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> GetOrderById(int id)
        => GetEntityByIdentifier(id, clsOrder.FindOrderById, entity => Ok(entity));


        // POST: api/orders
        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderDTO> AddOrder([FromBody] OrderCreateDTO newOrderDTO)
        {
            if (newOrderDTO == null || newOrderDTO.CustomerID < 1)
            {
                return BadRequest("Invalid order data.");
            }

            clsOrder orderInstance = new clsOrder(
                new OrderDTO(null, newOrderDTO.CustomerID, DateTime.Now, newOrderDTO.TotalAmount, newOrderDTO.PaymentStatus, newOrderDTO.DeliveryStatus),
                clsOrder.enMode.AddNew
            );
            // Validate the order instance
            var validationResult = _validator.Validate(orderInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }


            if (orderInstance.Save())
            {
                return CreatedAtRoute("GetOrderById", new { id = orderInstance.OrderID }, newOrderDTO);
            }
            return BadRequest("Unable to create order.");
        }


        // PUT: api/orders/{id}
        [HttpPut("{id}", Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> UpdateOrder(int id, OrderDTO updatedOrder)
        {
            if (id < 1 || updatedOrder == null || updatedOrder.OrderID < 1)
            {
                return BadRequest("Invalid order data.");
            }

            OrderDTO? existingOrder = clsOrder.FindOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            clsOrder orderInstance = new clsOrder(updatedOrder, clsOrder.enMode.Update);

            // Validate the order instance
            var validationResult = _validator.Validate(orderInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (orderInstance.Save())
            {
                return Ok(orderInstance.ToOrderDto());
            }

            return StatusCode(500, new { message = "Error updating order." });
        }


        // DELETE: api/orders/{id}
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteOrder(int id)
        {
            return DeleteEntity<clsOrder>(
                id,
                clsOrder.Delete,
                "Order"
            );
        }



        [HttpGet("Order/{customerId}", Name = "GetOrdersByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<OrderDTO>> GetOrdersByCustomerID(int customerId)
        {
            return GetAllEntitiesBy<clsOrder, OrderDTO, int>(
                customerId,
                clsOrder.FindOrdersByCustomerId,
                "Order"
            );
        }
    }
}
