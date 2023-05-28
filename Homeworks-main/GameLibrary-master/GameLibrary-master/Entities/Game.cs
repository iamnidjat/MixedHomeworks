using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string? Title { get; set; }
        [MaxLength(450)]
        public string? Category { get; set; }
        [Required]
        public int Price { get; set; }

        public ObservableCollection<Game>? Games { get; set; } = new();

        public GameCharacteristics? gameCharacteristics { get; set; }
    }
}
