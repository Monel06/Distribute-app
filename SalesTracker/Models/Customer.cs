using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTracker.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsActive { get; set; }

        public decimal? Balance { get; set; }

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; }
    }
}
