using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    [Index("Mail", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string? FirstName { get; set; }
        [MaxLength(450)]
        public string? LastName { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? Gender { get; set; }
    }
}
