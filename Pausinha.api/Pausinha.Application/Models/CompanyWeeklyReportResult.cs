namespace Pausinha.Application.Models
{
    public class CompanyWeeklyReportResult
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;

        public int TotalBreaks { get; set; }
        public int TotalMinutes { get; set; }
        public int EmployeesWithBreaks { get; set; }
        public double AverageMinutesPerEmployee { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
