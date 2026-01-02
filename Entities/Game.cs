using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Entities;
public class Game
{
    public int Id { get; set; }
    [Required] // Name is required
    [StringLength(50)] // Maximum length of 50 characters
    public required string Name { get; set; }
    [Required]
    [StringLength(30)] // Maximum length of 30 characters
    public required string Genre { get; set; }

    [Range(1, 100)] // Price must be between 1 and 100
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    [Url] // Must be a valid URL
    [StringLength(100)] // Maximum length of 100 characters
    public required string ImageUri { get; set; }
}
