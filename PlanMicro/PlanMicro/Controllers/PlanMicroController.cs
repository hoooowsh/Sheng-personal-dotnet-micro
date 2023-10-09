
using Microsoft.AspNetCore.Mvc;
using PlanMicro.Contracts.PlanMicro;
using PlanMicro.Models;

namespace PlanMicro.Controllers;

[ApiController]
[Route("plan")]
public class PlanController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreatePlan(CreatePlanRequest request)
    {
        // Create plan model from request to save data to database
        var plan = new Plan(
            Guid.NewGuid(),
            request.name,
            request.content,
            request.category,
            DateTime.UtcNow,
            request.startDate,
            request.endDate,
            request.importanceLevel,
            request.percentComplete,
            request.status
        );
        // Database call

        // prepare response using planResponse contract
        var response = new PlanResponse(
            plan.Id,
            plan.Name,
            plan.Content,
            plan.Category,
            plan.InsertDate,
            plan.StartDate,
            plan.EndDate,
            plan.ImportanceLevel,
            plan.PercentComplete,
            plan.Status
        );
        return CreatedAtAction(actionName: nameof(GetPlan), routeValues: new { id = plan.Id }, value: response);
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