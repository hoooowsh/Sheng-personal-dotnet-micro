
using Microsoft.AspNetCore.Mvc;
using PlanMicro.Contracts.PlanMicro;

namespace PlanMicro.Controllers;

[ApiController]
[Route("plan")]
public class PlanController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreatePlan(CreatePlanRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetPlan(Guid id)
    {
        return Ok(id);
    }

    [HttpPost("/list")]
    public IActionResult GetPlans(GetPlanListRequest request)
    {
        return Ok(request);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertPlan(Guid id, UpsertPlanRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePlan(Guid id)
    {
        return Ok(id);
    }
}