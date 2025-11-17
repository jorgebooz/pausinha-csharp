namespace Pausinha.Domain.Entities
{
    public class BreakSession
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string BreakType { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        public Employee Employee { get; set; } = null!;

        // Cálculo automático para relatórios
        public int DurationMinutes => (int)(EndedAt - StartedAt).TotalMinutes;
    }
}
