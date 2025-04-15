using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models;

public class Review
{
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string Reviewer { get; set; }

    [Required]
    [Range(1, 10)]
    public int Rating { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 5)]
    public string ReviewText { get; set; }

    public int HotelId { get; set; }

}
