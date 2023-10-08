namespace PlanMicro.Contracts.PlanMicro;

public record GetPlanListRequest(
    DateTime from,
    DateTime to
);