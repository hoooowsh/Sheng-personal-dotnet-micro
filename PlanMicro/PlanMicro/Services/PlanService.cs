using ErrorOr;
using PlanMicro.Models;
using PlanMicro.ServiceErrors;

namespace PlanMicro.Services;

public class planService : IPlanService
{
    private static readonly Dictionary<Guid, Plan> _plans = new();
    public ErrorOr<Created> CreatePlan(Plan plan)
    {
        _plans.Add(plan.Id, plan);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeletePlan(Guid id)
    {
        _plans.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Plan> GetPlan(Guid id)
    {
        if (_plans.TryGetValue(id, out var plan))
        {
            return plan;
        }
        return Errors.Plan.NotFound;
    }

    public ErrorOr<UpsertedPlan> UpsertPlan(Plan plan)
    {
        var isNewlyCreated = !_plans.ContainsKey(plan.Id);
        _plans[plan.Id] = plan;
        return new UpsertedPlan(isNewlyCreated);
    }
}