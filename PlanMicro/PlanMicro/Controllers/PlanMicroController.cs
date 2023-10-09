
using Microsoft.AspNetCore.Mvc;
using PlanMicro.Contracts.PlanMicro;
using PlanMicro.Models;
using PlanMicro.Services;

namespace PlanMicro.Controllers;

[ApiController]
[Route("plan")]
public class PlanController : ControllerBase
{
    // init database service helper
    private readonly IPlanService _planService;
    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }

    [HttpPost]
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
        _planService.CreatePlan(plan);

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
        Plan plan = _planService.GetPlan(id);
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
        return Ok(response);
    }

    [HttpPost("/list")]
    public IActionResult GetPlans(GetPlanListRequest request)
    {
        return Ok(request);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertPlan(Guid id, UpsertPlanRequest request)
    {
        // Create plan model from request to save data to database
        var plan = new Plan(
            id,
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

        // update in database
        _planService.UpsertPlan(plan);

        // TODO: return 201 if new plan was created
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePlan(Guid id)
    {
        _planService.DeletePlan(id);
        return Ok(id);
    }
}