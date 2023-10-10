using ErrorOr;
using PlanMicro.Models;

namespace PlanMicro.Services;

public interface IPlanService
{
    ErrorOr<Created> CreatePlan(Plan request);
    ErrorOr<Deleted> DeletePlan(Guid id);
    ErrorOr<Plan> GetPlan(Guid id);
    ErrorOr<UpsertedPlan> UpsertPlan(Plan plan);
}
