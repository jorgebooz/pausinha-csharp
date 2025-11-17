namespace Pausinha.Api.DTOs
{
    public class BreakSessionCreateDto
    {
        public int EmployeeId { get; set; }
        public string BreakType { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }

    public class BreakSessionUpdateDto
    {
        public string BreakType { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }

    public class BreakSessionResponseDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string BreakType { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public int DurationMinutes { get; set; }
    }
}
