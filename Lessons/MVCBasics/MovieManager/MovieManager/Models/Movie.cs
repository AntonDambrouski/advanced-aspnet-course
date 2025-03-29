using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MovieManager.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Genre { get; set; }
    [Required]
    [Range(1900, 2025)]
    public int Year { get; set; }
}
