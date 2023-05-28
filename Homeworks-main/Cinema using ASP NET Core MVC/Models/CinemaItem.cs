using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class CinemaItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CinemaTitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        public ICollection<SessionItem> Sessions { get; set; } = new List<SessionItem>();
    }
}
