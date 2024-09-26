using BusinessLayer;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/orders/all
        [HttpGet("all", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDTO>> GetAllOrders()
        {
            List<OrderDTO> ordersList = clsOrder.All();
            if (ordersList.Count == 0)
            {
                return NotFound("No Orders Found!");
            }
            return Ok(ordersList);
        }

    
        // GET: api/orders/{id}
        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> GetOrderById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            OrderDTO? order = clsOrder.FindOrderById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return Ok(order);
        }

    
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
                new OrderDTO(null, newOrderDTO.CustomerID,DateTime.Now, newOrderDTO.TotalAmount, newOrderDTO.PaymentStatus, newOrderDTO.DeliveryStatus),
                clsOrder.enMode.AddNew
            );

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
            if (id < 1 || updatedOrder == null || updatedOrder.CustomerID < 1)
            {
                return BadRequest("Invalid order data.");
            }

            OrderDTO? existingOrder = clsOrder.FindOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            clsOrder orderInstance = new clsOrder(updatedOrder, clsOrder.enMode.Update);
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
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (clsOrder.Delete(id))
            {
                return Ok($"Order with ID {id} has been deleted.");
            }

            return NotFound($"Order with ID {id} not found. No rows deleted!");
        }

    
        // GET: api/orders/customer/{customerId}
        [HttpGet("customer/{customerId}", Name = "GetOrdersByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> GetOrderByCustomerId(int customerId)
        {
            if (customerId < 1)
            {
                return BadRequest($"Not accepted customerId {customerId}");
            }

            OrderDTO? order = clsOrder.FindOrderByCustomerId(customerId);
            if (order == null)
            {
                return NotFound($"Order with customer Id {customerId} not found.");
            }

            return Ok(order);
        }
    }

}
