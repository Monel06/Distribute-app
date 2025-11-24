using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTracker.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        public DateTime? CreatedAt { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        // Навигационные свойства
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
