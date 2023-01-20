using MovieTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")] 
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 characters long")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
