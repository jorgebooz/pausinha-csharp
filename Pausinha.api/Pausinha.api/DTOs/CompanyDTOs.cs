namespace Pausinha.Api.DTOs
{
    public class CompanyCreateDto
    {
        public string Name { get; set; } = null!;
    }

    public class CompanyUpdateDto
    {
        public string Name { get; set; } = null!;
    }

    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
