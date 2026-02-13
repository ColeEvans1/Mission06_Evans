using System.ComponentModel.DataAnnotations;

namespace Mission06_Evans.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Category is required")]
        public string? Notes { get; set; }
    }
}
