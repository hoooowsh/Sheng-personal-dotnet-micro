using ErrorOr;
using PlanMicro.Models;

namespace PlanMicro.Services;

public interface IPlanService
{
    void CreatePlan(Plan request);
    void DeletePlan(Guid id);
    ErrorOr<Plan> GetPlan(Guid id);
    void UpsertPlan(Plan plan);
}
