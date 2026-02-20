using System.ComponentModel.DataAnnotations;

namespace Mission06_Evans.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Copied to Plex is required")]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
    }
}