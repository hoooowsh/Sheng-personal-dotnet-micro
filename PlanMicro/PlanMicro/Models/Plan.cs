using ErrorOr;
using PlanMicro.ServiceErrors;

namespace PlanMicro.Models;

public class Plan
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public Guid Id { get; }
    public string Name { get; }
    public string Content { get; }
    public string Category { get; }
    public DateTime InsertDate { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int ImportanceLevel { get; }
    public double PercentComplete { get; }
    public string Status { get; }

    private Plan(Guid id, string name, string content, string category, DateTime insertDate, DateTime startDate, DateTime endDate, int importanceLevel, double percentComplete, string status)
    {
        Id = id;
        Name = name;
        Content = content;
        Category = category;
        InsertDate = insertDate;
        StartDate = startDate;
        EndDate = endDate;
        ImportanceLevel = importanceLevel;
        PercentComplete = percentComplete;
        Status = status;
    }

    public static ErrorOr<Plan> Create(
        string name,
        string content,
        string category,
        DateTime startDate,
        DateTime endDate,
        int importanceLevel,
        double percentComplete,
        string status,
        Guid? id = null)
    {
        List<Error> errors = new();
        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Plan.InvalidName);
        }

        // if there are errors
        if (errors.Count > 0)
        {
            return errors;
        }

        return new Plan(id ?? Guid.NewGuid(), name, content, category, DateTime.UtcNow, startDate, endDate, importanceLevel, percentComplete, status);
    }
}
