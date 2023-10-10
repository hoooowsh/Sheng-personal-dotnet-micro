using ErrorOr;

namespace PlanMicro.ServiceErrors;

public static class Errors
{
    public static class Plan
    {
        public static Error InvalidName => Error.Validation(
           code: "Plan.InvalidName",
           description: $"Plan name must be at least {Models.Plan.MinNameLength} characters long and at most {Models.Plan.MaxNameLength} characters long."
       );
        public static Error NotFound => Error.NotFound(
            code: "Plan.NotFound",
            description: "Description Not Found"
        );
    }
}