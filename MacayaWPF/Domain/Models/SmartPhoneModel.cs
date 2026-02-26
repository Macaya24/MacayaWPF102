namespace Domain.Models
{
    public class SmartPhoneModel
    {
        public int SmartPhoneId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Storage { get; set; } = string.Empty;
    }
}
