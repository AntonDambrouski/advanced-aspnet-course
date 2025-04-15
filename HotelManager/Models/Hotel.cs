using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models;

public class Hotel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50,  MinimumLength = 1)]
    public string Name { get; set; }

    [Required]
    [Range(1,5)]
    public int NumberOfStars {  get; set; }

    [Required]
    [StringLength(70, MinimumLength = 5)]
    public string Address { get; set; }

}
