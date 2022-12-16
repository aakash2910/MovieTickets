using MovieTickets.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public MovieCategory Category { get; set; }
    }
}
