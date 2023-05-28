using GameLibrary.Entities;
using GameLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models
{
    public class GameCharacteristics
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string? Developer { get; set; }
        [MaxLength(450)]
        public string? Description { get; set; }
        [MaxLength(450)]
        public string? Manufacturer { get; set; }
        [MaxLength(450)]
        public string? Raiting { get; set; }
        [MaxLength(450)]
        public string? Publisher { get; set; }
        [MaxLength(450)]
        public string? Tags { get; set; }
        [MaxLength(450)]
        public string? Comments { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [MaxLength(450)]
        public string? GameTitle { get; set; } 

        public ObservableCollection<GameCharacteristics>? GamesChars { get; set; } = new();

        public int GameId { get; set; }

        public Game? games { get; set; }
    }
}
