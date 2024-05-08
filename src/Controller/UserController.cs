using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controller;
public class UserController : BaseController
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IEnumerable<UserReadDto> FindAll()
    {
        return _userService.FindAll();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<UserReadDto?> FindOne(Guid id)
    {

        UserReadDto? foundUser = _userService.FindOne(id);
        if (foundUser is null)
        {
            throw new NullReferenceException();
        }
        return Ok(foundUser);
    }

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<UserReadDto>> SignUp([FromBody] UserCreateDto user)
    {
        if (user is not null)
        {
            var createdUser = _userService.SignUp(user);
            return CreatedAtAction(nameof(SignUp), createdUser);
        }
        return BadRequest();
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<UserReadDto>> SignIn([FromBody] UserSignIn userSign)
    {
        if (userSign is not null)
        {
            var token = _userService.SignIn(userSign);
            if (token is null) return BadRequest();
            return Ok(token);
        }
        return BadRequest();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<UserReadDto> UpdateOne(Guid id, User user)
    {
        UserReadDto? updatedUser = _userService.UpdateOne(id, user);
        if (updatedUser is not null)
        {
            return CreatedAtAction(nameof(UpdateOne), updatedUser);
        }
        else return BadRequest();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid id, User user)
    {
        bool isDeleted = _userService.DeleteOne(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
