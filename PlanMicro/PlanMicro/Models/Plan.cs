namespace PlanMicro.Models;

public class Plan
{
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

    public Plan(Guid id, string name, string content, string category, DateTime insertDate, DateTime startDate, DateTime endDate, int importanceLevel, double percentComplete, string status)
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
}
