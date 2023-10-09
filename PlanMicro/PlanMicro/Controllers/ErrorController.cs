using Microsoft.AspNetCore.Mvc;

namespace PlanMicro.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}