using Business_Layer;
using Business_Layer.Cake;
using Business_Layer.Order;
using CakeDeliveryDTO.CakeDTOs;
using DTOs;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly OrderValidator _validator = new OrderValidator();


        // GET: api/orders/all
        [HttpGet("all", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDTO>> GetAllOrders()
            => GetAllEntities(() => Order.All());


        // GET: api/orders/{id}
        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> GetOrderById(int id)
        => GetEntityByIdentifier(id, Order.FindOrderById, entity => Ok(entity));


        // POST: api/orders
        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderCreateDTO newOrderDTO)
        {
            if (newOrderDTO == null || newOrderDTO.CustomerID < 1)
            {
                return BadRequest("Invalid order data.");
            }

            Order orderInstance = new Order(
                new OrderDTO(null, newOrderDTO.CustomerID, DateTime.Now, newOrderDTO.TotalAmount, newOrderDTO.PaymentStatus, newOrderDTO.DeliveryStatus),
                Order.enMode.AddNew
            );
       
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
                BackgroundJob.Schedule(() => EmailService.SendEmail(newOrderDTO.CustomerID, newOrderDTO.TotalAmount, orderInstance.OrderDate), TimeSpan.FromMinutes(5));
               ;
                var locationUrl = Url.Link("GetOrderById", new { id = orderInstance.OrderID });
                return Ok(locationUrl);
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

            OrderDTO? existingOrder = Order.FindOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            Order orderInstance = new Order(updatedOrder, Order.enMode.Update);

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
          => DeleteEntity<Order>(id,Order.Delete,"Order");




        [HttpGet("Order/{customerId}", Name = "GetOrdersByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<OrderDTO>> GetOrdersByCustomerID(int customerId)
        {
            return GetAllEntitiesBy<Order, OrderDTO, int>(
                customerId,
                Order.FindOrdersByCustomerId,
                "Order"
            );
        }
    }
}
