﻿using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string LogoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set;}
    }
}
