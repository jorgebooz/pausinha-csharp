namespace Pausinha.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }        // FK
        public string Name { get; set; } = null!;
        public string WorkMode { get; set; } = "HomeOffice"; // "HomeOffice" ou "Escritorio"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;

        public ICollection<BreakSession> BreakSessions { get; set; } = new List<BreakSession>();
    }
}
