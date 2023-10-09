using PlanMicro.Models;

namespace PlanMicro.Services;

public interface IPlanService
{
    void CreatePlan(Plan request);
}
