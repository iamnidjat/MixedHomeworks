namespace NotePad.Models
{
    public class NotePadItem
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public string Tags { get; set; } = string.Empty;
    }
}
