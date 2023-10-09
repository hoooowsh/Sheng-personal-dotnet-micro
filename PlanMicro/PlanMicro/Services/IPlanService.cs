using PlanMicro.Models;

namespace PlanMicro.Services;

public interface IPlanService
{
    void CreatePlan(Plan request);
    void DeletePlan(Guid id);
    Plan GetPlan(Guid id);
    void UpsertPlan(Plan plan);
}
