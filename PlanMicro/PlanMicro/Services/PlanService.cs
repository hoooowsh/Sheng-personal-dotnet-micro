using ErrorOr;
using PlanMicro.Models;
using PlanMicro.ServiceErrors;

namespace PlanMicro.Services;

public class planService : IPlanService
{
    private static readonly Dictionary<Guid, Plan> _plans = new();
    public void CreatePlan(Plan plan)
    {
        _plans.Add(plan.Id, plan);
    }

    public void DeletePlan(Guid id)
    {
        _plans.Remove(id);
    }

    public ErrorOr<Plan> GetPlan(Guid id)
    {
        if (_plans.TryGetValue(id, out var plan))
        {
            return plan;
        }
        return Errors.Plan.NotFound;
    }

    public void UpsertPlan(Plan plan)
    {
        _plans[plan.Id] = plan;
    }
}