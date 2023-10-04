using System;

namespace PlanMicro.Models
{
    public class Plan
    {
        public required string Title { get; set; }
        public string? Content { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public required double Percentage { get; set; }
    }
}