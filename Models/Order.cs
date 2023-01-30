﻿using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set;}
    }
}