namespace Pausinha.Api.DTOs
{
    public class EmployeeCreateDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string WorkMode { get; set; } = "HomeOffice";
    }

    public class EmployeeUpdateDto
    {
        public string Name { get; set; } = null!;
        public string WorkMode { get; set; } = "HomeOffice";
    }

    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string WorkMode { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
