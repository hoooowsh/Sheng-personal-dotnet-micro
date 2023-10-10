
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PlanMicro.Contracts.PlanMicro;
using PlanMicro.Models;
using PlanMicro.ServiceErrors;
using PlanMicro.Services;

namespace PlanMicro.Controllers;


public class PlanController : ApiController
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
        ErrorOr<Plan> requestToPlanResult = Plan.Create(
            request.name,
            request.content,
            request.category,
            request.startDate,
            request.endDate,
            request.importanceLevel,
            request.percentComplete,
            request.status
        );
        if (requestToPlanResult.IsError)
        {
            return Problem(requestToPlanResult.Errors);
        }
        var plan = requestToPlanResult.Value;

        // Database call
        ErrorOr<Created> createPlanResult = _planService.CreatePlan(plan);
        return createPlanResult.Match(
            created => CreatedAsGetPlan(plan),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetPlan(Guid id)
    {
        // get the plan from database
        ErrorOr<Plan> getPlanResult = _planService.GetPlan(id);

        return getPlanResult.Match(
            plan => Ok(MapPlanResponse(plan)),
            errors => Problem(errors)
        );
    }



    [HttpPost("/list")]
    public IActionResult GetPlans(GetPlanListRequest request)
    {
        return Ok(request);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertPlan(Guid id, UpsertPlanRequest request)
    {
        ErrorOr<Plan> requestToPlanResult = Plan.Create(
            request.name,
            request.content,
            request.category,
            request.startDate,
            request.endDate,
            request.importanceLevel,
            request.percentComplete,
            request.status,
            id
        );

        if (requestToPlanResult.IsError)
        {
            return Problem(requestToPlanResult.Errors);
        }
        var plan = requestToPlanResult.Value;

        // update in database
        ErrorOr<UpsertedPlan> upsertedPlanResult = _planService.UpsertPlan(plan);

        return upsertedPlanResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAsGetPlan(plan) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePlan(Guid id)
    {
        ErrorOr<Deleted> deletedPlanResult = _planService.DeletePlan(id);
        return deletedPlanResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static PlanResponse MapPlanResponse(Plan plan)
    {
        return new PlanResponse(
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
    }

    private CreatedAtActionResult CreatedAsGetPlan(Plan plan)
    {
        return CreatedAtAction(
            actionName: nameof(GetPlan),
            routeValues: new { id = plan.Id },
            value: MapPlanResponse(plan)
        );
    }
}