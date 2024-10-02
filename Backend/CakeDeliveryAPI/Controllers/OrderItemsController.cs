using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Business_Layer.Order;
using DTOs;
using Business_Layer.OrderItem;
using Business_Layer.Orders;
using CakeDeliveryAPI.Controllers;
using Business_Layer.Cake;
using CakeDeliveryDTO.CakeDTOs;

[Route("api/orderItems")]
[ApiController]
public class OrderItemsController : BaseController
{
    private readonly clsOrderItemValidator _validator = new clsOrderItemValidator();

    // GET: api/cakes/all
    [HttpGet("All", Name = "GetAllOrderItems")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<OrderItemDTO>> GetAllOrderItems()
        => GetAllEntities(() => clsOrderItem.AllOrderItems());


    // GET: api/orderItems/{id}
    [HttpGet("{id}", Name = "GetOrderItemById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderItemDTO> GetOrderItemById(int id)
        => GetEntityByIdentifier(id, clsOrderItem.FindOrderItemById, orderItem => Ok(orderItem));

    // POST: api/orderItems
    [HttpPost(Name = "AddOrderItem")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemDTO> AddOrderItem([FromBody] OrderItemCreateDTO newOrderItemDTO)
    {
        if (newOrderItemDTO == null || newOrderItemDTO.Quantity <= 0)
        {
            return BadRequest("Invalid order item data.");
        }

        clsOrderItem orderItemInstance = new clsOrderItem(
            new OrderItemDTO(null, newOrderItemDTO.OrderID, newOrderItemDTO.CakeID, newOrderItemDTO.SizeID, newOrderItemDTO.Quantity, newOrderItemDTO.PricePerItem),
            clsOrderItem.enMode.AddNew
        );

        var validationResult = _validator.Validate(orderItemInstance);
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Success = false,
                Errors = validationResult.Errors
            });
        }

        if (orderItemInstance.Save())
        {
            return CreatedAtRoute("GetOrderItemById", new { id = orderItemInstance.OrderItemID }, newOrderItemDTO);
        }

        return BadRequest("Unable to create order item.");
    }

    // PUT: api/orderItems/{id}
    [HttpPut("{id}", Name = "UpdateOrderItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderItemDTO> UpdateOrderItem(int id, OrderItemDTO updatedOrderItem)
    {
        if (id < 1 || updatedOrderItem == null || updatedOrderItem.Quantity <= 0)
        {
            return BadRequest("Invalid order item data.");
        }

        OrderItemDTO? existingOrderItem = clsOrderItem.FindOrderItemById(id);
        if (existingOrderItem == null)
        {
            return NotFound($"Order item with ID {id} not found.");
        }

        clsOrderItem orderItemInstance = new clsOrderItem(updatedOrderItem, clsOrderItem.enMode.Update);

        var validationResult = _validator.Validate(orderItemInstance);
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Success = false,
                Errors = validationResult.Errors
            });
        }

        if (orderItemInstance.Save())
        {
            return Ok(orderItemInstance.ToOrderItemDto());
        }

        return StatusCode(500, new { message = "Error updating order item." });
    }

    // DELETE: api/orderItems/{id}
    [HttpDelete("{id}", Name = "DeleteOrderItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOrderItem(int id)
        => DeleteEntity<clsOrderItem>(id, clsOrderItem.Delete, "OrderItem");

   
    // GET: api/orderItems/order/{orderId}
    [HttpGet("order/orderId/{orderId}", Name = "GetOrderItemsByOrderId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<OrderItemDTO>> GetOrderItemsByOrderId(int orderId)
        => GetAllEntitiesBy<int, OrderItemDTO, int>(orderId, clsOrderItem.AllByOrderID, "OrderItem");

   
    // GET: api/orderItems/order/{cakeId}
    [HttpGet("order/cakeId/{cakeId}", Name = "GetOrderItemsBycakeId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<OrderItemDTO>> GetOrderItemsBycakeId(int cakeId)
        => GetAllEntitiesBy<int, OrderItemDTO, int>(cakeId, clsOrderItem.AllByCakeID, "OrderItem");


}
