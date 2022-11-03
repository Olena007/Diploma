namespace WebApi.ModelsDTO
{
    public class PhoneDto
    {
        public int PhoneId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
