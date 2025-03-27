using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MovieManager.Models;

public class Review
{
    [BindNever]
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Reviewer { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Message { get; set; }
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    public int MovieId { get; set; }
}
