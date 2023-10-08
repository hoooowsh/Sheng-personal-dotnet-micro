namespace PlanMicro.Contracts.PlanMicro;

public record CreatePlanRequest(
    string name,
    string content,
    string category,
    DateTime startDate,
    DateTime endDate,
    int importanceLevel,
    double percentComplete,
    string status
);