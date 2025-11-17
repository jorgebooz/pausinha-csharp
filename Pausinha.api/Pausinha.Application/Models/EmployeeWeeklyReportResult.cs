namespace Pausinha.Application.Models
{
    public class EmployeeWeeklyReportResult
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;

        public int TotalBreaks { get; set; }
        public int TotalMinutes { get; set; }
        public double AverageBreakMinutes { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
