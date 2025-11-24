using System.ComponentModel.DataAnnotations;

namespace SalesTracker.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public float? Discount { get; set; }

        // Навигационные свойства
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
