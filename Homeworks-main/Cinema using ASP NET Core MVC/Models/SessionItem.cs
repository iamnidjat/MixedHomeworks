using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Cinema.Models
{
    public class SessionItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime ShowDate { get; set; }

        public int CinemaItemId { get; set; }

        public CinemaItem? Cinema { get; set; }
    }
}
