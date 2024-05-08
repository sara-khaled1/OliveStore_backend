using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Controller;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
namespace sda_onsite_2_csharp_backend_teamwork.src.Controllerl;

public class OrderItemController : BaseController

{
    private IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {


        _orderItemService = orderItemService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderItemReadDto>> FindAll()
    {
        return Ok(_orderItemService.FindAll());
    }

    [HttpGet("{id}")]
    public ActionResult<OrderItemReadDto> FindOne(Guid id)
    {
        return Ok(_orderItemService.FindOne(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemReadDto> CreateOne([FromBody] OrderItemReadDto orderItem)
    {


        if (orderItem is not null)
        {
            var createdOrderItem = _orderItemService.CreateOne(orderItem);
            return CreatedAtAction(nameof(CreateOne), createdOrderItem);
        }
        return BadRequest();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemReadDto> UpdateOne(Guid id, [FromBody] OrderItem orderItem)
    {

        OrderItemReadDto? updatedOrderItem = _orderItemService.UpdateOne(id, orderItem);
        if (updatedOrderItem is not null)
        {
            return CreatedAtAction(nameof(UpdateOne), updatedOrderItem);
        }
        else return BadRequest();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid id)
    {
        bool isDeleted = _orderItemService.DeleteOne(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();

    }
}
