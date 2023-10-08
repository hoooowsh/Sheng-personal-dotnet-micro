namespace PlanMicro.Contracts.PlanMicro;

public record UpsertPlanRequest(
    string name,
    string content,
    string category,
    DateTime startDate,
    DateTime endDate,
    int impartanceLevel,
    double percentComplete,
    string status
);