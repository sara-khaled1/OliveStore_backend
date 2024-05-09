using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controller;

public class OrderController : BaseController
{
    private IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderReadDto>> FindAll()
    {
        return Ok(_orderService.FindAll());
    }

    [HttpGet("{id}")]
    public ActionResult<OrderReadDto?> FindOne([FromRoute] Guid id)
    {
        return Ok(_orderService.FindOne(id));
    }

    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public ActionResult<OrderReadDto> CreateOne([FromBody] OrderCreateDto order)
    // {
    //     if (order is not null)
    //     {
    //         var createdOrder = _orderService.CreateOne(order);
    //         return CreatedAtAction(nameof(CreateOne), createdOrder);
    //     }
    //     return BadRequest();
    // }

    // [Authorize(Roles = "Admin,Customer")]
    [HttpPost("checkout")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderReadDto> Checkout([FromBody] CheckoutDto checkoutList)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (checkoutList is null) return BadRequest();
        return CreatedAtAction(nameof(Checkout), _orderService.Checkout(checkoutList, userId!));
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderReadDto> UpdateOne(Guid id, [FromBody] Order order)
    {
        OrderReadDto? updatedOrder = _orderService.UpdateOne(id, order);
        if (updatedOrder is null) return BadRequest();
        return CreatedAtAction(nameof(UpdateOne), updatedOrder);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne([FromRoute] Guid id)
    {
        bool isDeleted = _orderService.DeleteOne(id);
        if (!isDeleted) return NotFound();
        return NoContent();

    }
}
