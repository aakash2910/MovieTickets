using MovieTickets.Data.Base;
using MovieTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public MovieCategory Category { get; set; }

        [Display(Name = "Actors")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Cinemas")]
        public int CinemaId { get; set; }

        [Display(Name = "Producers")]
        public int ProducerId { get; set; }        
    }
}
