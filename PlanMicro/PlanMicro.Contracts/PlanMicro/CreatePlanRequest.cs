namespace PlanMicro.Contracts.PlanMicro;

public record CreatePlanRequest(
    Guid id,
    string name,
    string content,
    string category,
    DateTime insertDate,
    DateTime startDate,
    DateTime endDate,
    int impartanceLevel,
    double percentComplete,
    string status
);