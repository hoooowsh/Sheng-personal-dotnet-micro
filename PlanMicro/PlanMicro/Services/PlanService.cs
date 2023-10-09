using PlanMicro.Models;

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

    public Plan GetPlan(Guid id)
    {
        return _plans[id];
    }

    public void UpsertPlan(Plan plan)
    {
        _plans[plan.Id] = plan;
    }
}