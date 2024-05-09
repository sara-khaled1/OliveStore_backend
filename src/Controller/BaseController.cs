using Microsoft.AspNetCore.Mvc;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controller;

[ApiController]
[Route("api/v1/[controller]s")]// s removed : Address becomes addresss - category becomes catecorys 😒
public abstract class BaseController : ControllerBase
{
}
