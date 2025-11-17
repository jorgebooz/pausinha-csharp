namespace Pausinha.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }              // PK
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navegação
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
