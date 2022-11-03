namespace WebApi.ModelsDTO
{
    public class ComputerDto
    {
        public int ComputerId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
