using ErrorOr;

namespace PlanMicro.ServiceErrors;

public static class Errors
{
    public static class Plan
    {
        public static Error NotFound => Error.NotFound(
            code: "Plan.NotFound",
            description: "Description Not Found"
        );
    }
}